using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	public class DatabaseView
	{
		private Database database;
		private DateTime startDate = DateTime.MinValue, endDate = DateTime.MaxValue;
		private string paymentViewName = "account_payments",
						loanViewName = "account_loans",
						summaryViewName = "current_accounts_summary";
		private string accountLoanPaymentsViewName = "account_loan_payments",
						accountLoansViewName = "account_loans";
		private string nextMonthPaymentsViewName = "next_month_payments";

		public DatabaseView(Database database = null)
		{
			if (database == null)
			{
				database = DatabaseFactory.Default;
			}
			this.database = database;
		}

		public DateTime StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}

		public DateTime EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}

		public DataTable Summary()
		{
			database.BeginTransaction();
			createSummaryViews();
			string sql = string.Format("SELECT * FROM {0} ORDER BY name", summaryViewName);
			DataTable results = database.Query(sql);
			database.Rollback();
			return results;
		}

		public DataTable AccountLoans(Account account, bool includeClosedLoans = true)
		{
			database.BeginTransaction();
			createAccountLoanViews();

			string[] columns = {"id", "taken_date", "start_date", "principal", "term", "interest", 
								 "monthly_due", "total_payable", "payment_count", 
								 "total_payments", "balance", "processing_fee", "reloan_fee", "profit", "remarks" };
			string columnList = String.Join(", ", columns);

			string condition;
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			constructAccountLoansCondition(account, out condition, parameters, includeClosedLoans);

			string sql = string.Format("SELECT {0} FROM {1} WHERE {2} ORDER BY taken_date", columnList, accountLoansViewName, condition);
			DataTable results = this.database.Query(sql, parameters);
			database.Rollback();
			return results;
		}

		public DataTable NextMonthPayments()
		{
			database.BeginTransaction();
			createNextMonthCashFlowViews();
			string sql = string.Format("SELECT name, next_payment FROM {0} ORDER BY name", nextMonthPaymentsViewName);
			DataTable results = database.Query(sql);
			database.Rollback();
			return results;
		}

		private void createNextMonthCashFlowViews()
		{
			database.Execute(accountLoanPaymentsView());
			database.Execute(accountLoansView());
			database.Execute(nextMonthPaymentsView());
		}

		private void createAccountLoanViews()
		{
			database.Execute(accountLoanPaymentsView());
			database.Execute(accountLoansView());
		}
		
		private void createSummaryViews()
		{
			database.Execute(paymentView());
			database.Execute(loanView());
			database.Execute(summaryView());
		}

		private string nextMonthPaymentsView()
		{
			string view = "SELECT "
						+ "accounts.id AS account_id, "
						+ "accounts.name AS name, "
						+ "taken_date, "
						+ "start_date, "
						+ "total_payments, "
						+ "total_payable, "
						+ "monthly_due, "
						+ "(CASE "
						+ "WHEN date(start_date) > date('now','start of month','+2 month','-1 day') "
						+ "THEN 0 "
						+ "WHEN (total_payable-total_payments) > monthly_due "
						+ "THEN monthly_due "
						+ "ELSE total_payable-total_payments "
						+ "END) AS next_payment "
						+ "FROM accounts "
						+ "LEFT JOIN {view} ON accounts.id={view}.account_id "
						+ "WHERE is_closed != 1 AND (total_payable - total_payments > 0) "
						+ "GROUP BY {view}.id "
						+ "HAVING next_payment > 0";
						
			view = view.Replace("{view}", accountLoansViewName);

			return string.Format("CREATE TEMPORARY VIEW {0} AS {1}", nextMonthPaymentsViewName, view);
		}

		private string accountLoansView()
		{

			string view = "SELECT "
						+ "loans.id AS id, "
						+ "loans.account_id AS account_id, "
						+ "loans.taken_date AS taken_date, "
						+ "loans.start_date AS start_date, "
						+ "loans.principal AS principal, "
						+ "loans.term AS term, "
						+ "loans.interest AS interest, "
						+ "loans.monthly_due AS monthly_due, "
						+ "loans.total_payable AS total_payable, "
						+ "(CASE {view}.payment_count IS NULL WHEN 1 THEN 0 ELSE {view}.payment_count END) AS payment_count, "
						+ "(CASE {view}.total_payments IS NULL WHEN 1 THEN 0 ELSE {view}.total_payments END) AS total_payments, "
						+ "(CASE {view}.total_balance_deductible IS NULL WHEN 1 THEN 0 ELSE {view}.total_balance_deductible END) AS balance_deductible, "
						+ "(CASE loans.is_closed=1 WHEN 1 THEN 0 ELSE (CASE (total_payable - total_balance_deductible) IS NULL WHEN 1 THEN total_payable ELSE (total_payable - total_balance_deductible) END) END) AS balance, "
						+ "loans.processing_fee AS processing_fee, "
						+ "(CASE WHEN loans.reloan_fee IS NULL THEN 0 ELSE loans.reloan_fee END) AS reloan_fee, "
						+ "(CASE WHEN total_interest_payment IS NULL THEN (processing_fee + reloan_fee) ELSE (processing_fee + reloan_fee + total_interest_payment) END) AS profit, "
						+ "loans.remarks, "
						+ "is_closed "
						+ "FROM loans "
						+ "LEFT JOIN {view} ON {view}.loan_id = loans.id "
						+ whereClause(dateCondition("taken_date"))
						+ "GROUP BY loans.id";

			view = view.Replace("{view}", accountLoanPaymentsViewName);

			return string.Format("CREATE TEMPORARY VIEW {0} AS {1}", accountLoansViewName, view);
		}

		private string accountLoanPaymentsView()
		{
			string view = "SELECT "
						+ "payments.loan_id AS loan_id, "
						+ "COUNT(payments.id) AS payment_count, "
						+ "TOTAL(payments.amount) AS total_payments, "
						+ "TOTAL(payments.interest_payment) AS total_interest_payment, "
						+ "TOTAL(payments.balance_deductible) AS total_balance_deductible "
						+ "FROM payments "
						+ whereClause(dateCondition("date_paid"))
						+ "GROUP BY payments.loan_id";

			return string.Format("CREATE TEMPORARY VIEW {0} AS {1}", accountLoanPaymentsViewName, view);
		}

		private string summaryView()
		{
			string view = "SELECT "
						+ "accounts.id AS id, "
						+ "accounts.name AS name, "
						+ "loan_count, "
						+ "total_principal, "
						+ "total_payable, "
						+ "(CASE WHEN payment_count IS NULL THEN 0 ELSE payment_count END) AS payment_count, "
						+ "(CASE WHEN {paymentView}.total_interest_payment IS NULL THEN 0 ELSE {paymentView}.total_interest_payment END) AS total_interest_payment, "
						+ "(CASE WHEN {paymentView}.total_principal_payment IS NULL THEN 0 ELSE {paymentView}.total_principal_payment END) AS total_principal_payment, "
						+ "(CASE WHEN {paymentView}.total_payments IS NULL THEN 0 ELSE {paymentView}.total_payments END) AS total_payments, "
						+ "(CASE WHEN total_deductible_payments IS NULL THEN total_payable ELSE total_payable - total_deductible_payments END) AS balance, "
						+ "(CASE WHEN total_processing_fee IS NULL THEN 0 ELSE total_processing_fee END) AS total_processing_fee, "
						+ "(CASE WHEN total_reloan_fee IS NULL THEN 0 ELSE total_reloan_fee END) AS total_reloan_fee, "
						+ "(CASE WHEN total_interest_payment IS NULL THEN (total_processing_fee + total_reloan_fee) ELSE (total_interest_payment + total_processing_fee + total_reloan_fee) END) AS profit "
						//+ "(total_interest_payment) AS profit "
						+ "FROM accounts "
						+ "LEFT JOIN account_loans ON account_loans.id = accounts.id "
						+ "LEFT JOIN {paymentView} ON {paymentView}.id = accounts.id";
			view = view.Replace("{paymentView}", paymentViewName);
			return string.Format("CREATE TEMPORARY VIEW {0} AS {1}", summaryViewName, view);
		}

		private string paymentView()
		{
			string view = "SELECT "
						+ "accounts.id AS id, "
						+ "accounts.name AS name, "
						+ "COUNT(payments.id) AS payment_count, "
						+ "TOTAL(payments.amount) AS total_payments, "
						+ "TOTAL(payments.balance_deductible) AS total_deductible_payments, "
						+ "TOTAL(payments.interest_payment) AS total_interest_payment, "
						+ "TOTAL(payments.principal_payment) AS total_principal_payment "
						+ "FROM accounts "
						+ "LEFT JOIN payments ON (payments.account_id = accounts.id) "
						+ whereClause(dateCondition("date_paid"))
						+ "GROUP BY accounts.id";
	
			return string.Format("CREATE TEMPORARY VIEW {0} AS {1}", paymentViewName, view);
		}

		private string loanView()
		{
			string view = "SELECT "
						+ "accounts.id AS id, "
						+ "accounts.name AS name, "
						+ "COUNT(loans.id) AS loan_count, "
						+ "TOTAL(loans.principal) AS total_principal, "
						+ "TOTAL(loans.total_payable) AS total_payable, "
						+ "TOTAL(loans.processing_fee) AS total_processing_fee, "
						+ "TOTAL(loans.reloan_fee) AS total_reloan_fee "
						+ "FROM accounts "
						+ "LEFT JOIN loans ON (loans.account_id = accounts.id) "
						+ whereClause(dateCondition("taken_date"))
						+ "GROUP BY accounts.id";
			return string.Format("CREATE TEMPORARY VIEW {0} AS {1}", loanViewName, view);
		}

		private string whereClause(string condition)
		{
			if (!string.IsNullOrEmpty(condition))
			{
				return string.Format(" WHERE {0} ", condition);
			}
			return "";
		}

		private string loanDateCondition()
		{
			return dateCondition("taken_date");
		}

		private string paymentDateCondition()
		{
			return dateCondition("date_paid");
		}

		private string dateCondition(string columnName)
		{
			string format = "yyyy-MM-dd";
			List<string> condition = new List<string>();
			if (StartDate != DateTime.MinValue)
			{
				condition.Add(string.Format("date({0}) >= date('{1}')", columnName, StartDate.ToString(format)));
			}
			if (EndDate != DateTime.MaxValue)
			{
				condition.Add(string.Format("date({0}) <= date('{1}')", columnName, EndDate.ToString(format)));
			}
			return string.Join(" AND ", condition.ToArray());
		}

		private void constructAccountLoansCondition(Account account, out string condition, Dictionary<string, object> parameters, bool includeClosedLoans = true)
		{
			List<string> conditionList = new List<string>();
			conditionList.Add("account_id = :accountId");
			parameters[":accountId"] = account.Id;

			if (!includeClosedLoans)
			{
				conditionList.Add("is_closed != 1");
			}

			condition = string.Join(" AND ", conditionList.ToArray());
		}
	}
}
