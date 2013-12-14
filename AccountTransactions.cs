using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	public class AccountTransactions
	{
		private Account account;

		public AccountTransactions(Account account)
		{
			this.account = account;
		}

		public DataTable AllTransactions(Database database)
		{
			string sql = "SELECT id, date, amount, remarks FROM transactions WHERE account_id = :id ORDER BY date ASC";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(":id", account.Id);

			return database.Query(sql, parameters);	
		}
	}
}
