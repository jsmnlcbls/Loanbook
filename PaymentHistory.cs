using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	class PaymentHistory
	{
		private Database database;
		private Account account;
		private Loan loan;
		private DateTime startDate, endDate;

		public PaymentHistory(Database database)
		{
			this.database = database;
		}

		public Account Account
		{
			get { return account; }
			set { account = value; }
		}

		public Loan Loan
		{
			get { return loan; }
			set { loan = value; }
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

		public DataTable Summary
		{
			get { return summary(); }
		}

		public void Remove(Payment payment)
		{
			string sql = "DELETE FROM payments WHERE id=:id";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters[":id"] = payment.Id;

			database.Execute(sql, parameters);
		}

		private DataTable summary()
		{
			Dictionary<string, object> parameters = new Dictionary<string,object>();

			List<string> conditions = new List<string>();
			if (null != account)
			{
				conditions.Add("account_id=:accountId");
				parameters[":accountId"] = account.Id;
			}
			if (null != loan)
			{
				conditions.Add("loan_id=:loanId");
				parameters[":loanId"] = loan.Id;
			}
			string format = "yyyy-MM-dd";
			if (StartDate != DateTime.MinValue)
			{
				conditions.Add(string.Format("date(date_paid) >= date('{0}')", StartDate.ToString(format)));
			}
			if (EndDate != DateTime.MaxValue)
			{
				conditions.Add(string.Format("date(date_paid) <= date('{0}')", EndDate.ToString(format)));
			}

			DataTable summary = new DataTable();
			if (conditions.Count > 0)
			{
				string columns = "id, loan_id, account_id, date_paid, interest_payment, principal_payment, amount, balance_deductible, remarks";
				string sql = String.Format("SELECT {0} FROM payments WHERE {1} ORDER BY date_paid ASC",
											columns, 
											String.Join(" AND ", conditions.ToArray()));
				summary = database.Query(sql, parameters);
			}
			addBalanceColumn(summary);
			summary.Columns.Remove("balance_deductible");
			return summary;
		}

		private void addBalanceColumn(DataTable summary)
		{
			AccountLoans loans = new AccountLoans(database, account);
			loans.IncludeClosedLoans = true;

			Dictionary<long, decimal> runningBalance = new Dictionary<long, decimal>();
			Dictionary<long, decimal> runningProfit = new Dictionary<long, decimal>();
			foreach (Loan loan in loans)
			{
				runningBalance[loan.Id] = loan.TotalPayable;
				runningProfit[loan.Id] = (loan.ProcessingFee + loan.ReloanFee);
			}

			summary.Columns.Add("balance", typeof(decimal));
			summary.Columns.Add("profit", typeof(decimal));
			foreach (DataRow row in summary.Rows)
			{
				long loanId = (long)row["loan_id"];
				decimal balanceDeductible =  (decimal)row["balance_deductible"];
				decimal amount = (decimal)row["amount"];
				decimal interestPayment = (decimal)row["interest_payment"];
				decimal currentProfit = runningProfit[loanId] + interestPayment;
				decimal currentBalance = runningBalance[loanId] - balanceDeductible;
				row["balance"] = currentBalance;
				row["profit"] = currentProfit;
				runningBalance[loanId] = currentBalance;
				runningProfit[loanId] = currentProfit;
			}
		}
	}
}
