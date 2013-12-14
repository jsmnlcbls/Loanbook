using System;
using System.Collections.Generic;
using System.Text;

namespace LoanBook
{
	class Transaction
	{
		private long id = 0;

		private decimal amount;

		private DateTime date;

		private string remarks;

		private Account account;

		public long Id
		{
			get { return id; }
			set { id = value; }
		}

		public decimal Amount
		{
			get { return amount; }
			set { amount = value; }
		}

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		public string Remarks
		{
			get { return remarks; }
			set { remarks = value; }
		}

		public Account Account
		{
			get { return account; }
			set { account = value; }
		}

		public void Save(Database database)
		{
			if (id == 0)
			{
				string sql = "INSERT INTO transactions (account_id, date, amount, remarks) VALUES (:accountId, :date, :amount, :remarks)";
				Dictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add(":accountId", account.Id);
				parameters.Add(":date", date);
				parameters.Add(":amount", amount);
				parameters.Add(":remarks", remarks);
				database.Execute(sql, parameters);
				id = database.LastInsertId();
			}
			else
			{
				string sql = "UPDATE transactions SET amount=:amount, date=:date, remarks=:remarks WHERE id=:id";
				Dictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add(":amount", amount);
				parameters.Add(":date", date);
				parameters.Add(":remarks", remarks);
				parameters.Add(":id", id);
				database.Execute(sql, parameters);
			}
		}

		public void Remove(Database database)
		{
			string sql = "DELETE FROM transactions WHERE id=:id";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(":id", id);
			database.Execute(sql, parameters);
		}
	}
}
