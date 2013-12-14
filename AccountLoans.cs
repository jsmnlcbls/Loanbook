using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	public class AccountLoans : IEnumerable<Loan>
	{
		private Database database;
		private Dictionary<long, Loan> loanList;
		private Account account;
		private bool includeClosedLoans = true;
		private DateTime startDate, endDate;

		public AccountLoans(Database database, Account account)
		{
			this.database = database;
			this.account = account;
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

		public bool IncludeClosedLoans
		{
			get { return includeClosedLoans; }
			set { includeClosedLoans = value; }
		}

		public Account Account
		{
			get { return account; }
			set { account = value; }
		}

		public DataTable Summary
		{
			get { return summary(); }
		}

		public Loan this[long id]
		{
			get { initializeListFromDatabase();  return loanList[id]; }
			set { loanList[id] = value; }
		}

		IEnumerator<Loan> IEnumerable<Loan>.GetEnumerator()
		{
			initializeListFromDatabase();
			return loanList.Values.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			initializeListFromDatabase();
			return loanList.GetEnumerator();
		}

		private DataTable summary()
		{
			DatabaseView view = new DatabaseView(database);
			view.StartDate = StartDate;
			view.EndDate = EndDate;
			return view.AccountLoans(account, IncludeClosedLoans);
		}

		private void initializeListFromDatabase()
		{
			if (loanList != null)
			{
				return;
			}
			loanList = new Dictionary<long, Loan>();
			string condition;
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			constructCondition(out condition, parameters);
			string sql = string.Format("SELECT * FROM loans WHERE {0} ORDER BY start_date", condition);
			
			DataTable results = this.database.Query(sql, parameters);
			foreach (DataRow row in results.Rows)
			{
				Loan.LoanType type = (Loan.LoanType)int.Parse(row["type"].ToString());
				Loan loan;
				if (type == Loan.LoanType.AmortizedPayment)
				{
					loan = new AmortizedLoan(DatabaseFactory.Default);
					loan.Term = int.Parse(row["term"].ToString());
				}
				else if (type == Loan.LoanType.InterestOnlyPayment)
				{
					loan = new PerpetualInterestLoan(DatabaseFactory.Default);
				}
				else
				{
					throw new ApplicationException("Invalid loan type found in database");
				}

				loan.Account = account;
				loan.Id = long.Parse(row["id"].ToString());
				loan.InterestRate = decimal.Parse(row["interest"].ToString());
				loan.Principal = decimal.Parse(row["principal"].ToString());
				loan.Remarks = row["remarks"].ToString();
				loan.StartDate = DateTime.Parse(row["start_date"].ToString());
				loan.TakenDate = DateTime.Parse(row["taken_date"].ToString());

				loanList.Add(loan.Id, loan);
			}
		}

		private void constructCondition(out string condition, Dictionary<string, object> parameters)
		{
			List<string> conditionList = new List<string>();
			conditionList.Add("account_id = :accountId");
			parameters[":accountId"] = account.Id;
			
			if (!IncludeClosedLoans)
			{
				conditionList.Add("is_closed != 1");
			}

			condition = string.Join(" AND ", conditionList.ToArray());
		}
	}
}
