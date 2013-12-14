using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	class AccountList
	{
		private Database database;

		public AccountList(Database database)
		{
			this.database = database;
		}

		public DataTable Summary()
		{
			string sql = "SELECT * FROM accounts_summary ORDER BY name";
			return database.Query(sql);
		}
	}
}
