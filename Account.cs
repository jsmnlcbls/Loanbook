using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	public class Account
	{
		private Database database;

		private long id = 0;

		private string name;

		private string remarks;

		public long Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Remarks
		{
			get { return remarks; }
			set { remarks = value; }
		}

		public Account(Database database = null)
		{
			this.database = database;
		}

		public void Save(Database database)
		{
			if (id == 0)
			{
				string sql = "INSERT INTO accounts (name, remarks) VALUES (:name, :remarks)";
				Dictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add(":name", name);
				parameters.Add(":remarks", remarks);
				database.Execute(sql, parameters);
				id = database.LastInsertId();
			}
			else
			{
				string sql = "UPDATE accounts SET name=:name, remarks=:remarks WHERE id=:id";
				Dictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add(":name", name);
				parameters.Add(":remarks", remarks);
				parameters.Add(":id", id);
				database.Execute(sql, parameters);
			}
		}

		public void Load(Database database)
		{
			string sql = "SELECT * FROM accounts WHERE id=:id";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(":id", Id);
			DataTable results = database.Query(sql, parameters);
			if (results.Rows.Count == 1)
			{
				name = (string)results.Rows[0]["name"];
				remarks = (string)results.Rows[0]["remarks"];
			}
		}

		public DataTable Transactions(Database database)
		{
			string sql = "SELECT id, date, amount, remarks FROM transactions WHERE account_id = :id ORDER BY date ASC";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(":id", id);

			return database.Query(sql, parameters);
		}

		public Dictionary<string, string> Summary(Database database)
		{
			DataTable transactions = Transactions(database);
			decimal totalLoans = 0, totalPayments = 0, balance = 0;
			int loansMade = 0, paymentsMade = 0;
			foreach (DataRow row in transactions.Rows)
			{
				decimal amount;
				if (decimal.TryParse(row["amount"].ToString(), out amount))
				{
					if (amount < 0)
					{
						paymentsMade++;
						totalPayments += amount;
					}
					else if (amount > 0)
					{
						loansMade++;
						totalLoans += amount;
					}
				}
			}
			balance = totalLoans + totalPayments;
			Dictionary<string, string> summary = new Dictionary<string, string>();
			summary["Payments"] = paymentsMade.ToString();
			summary["Loans"] = loansMade.ToString();
			summary["TotalPayments"] = totalPayments.ToString();
			summary["TotalLoans"] = totalLoans.ToString();
			summary["Balance"] = balance.ToString();
			return summary;
		}
	}
}
