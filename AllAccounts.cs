using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;

namespace LoanBook
{
	public class AllAccounts
	{
		private Database database;
		private DateTime startDate = DateTime.MinValue, endDate = DateTime.MaxValue;
		private DatabaseView databaseView;

		public AllAccounts(Database database)
		{
			this.database = database;
			this.databaseView = new DatabaseView(database);
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
			get 
			{
				databaseView.StartDate = StartDate;
				databaseView.EndDate = EndDate;
				return databaseView.Summary(); 
			}
		}

		public void Remove(Account account)
		{
			string sql = "DELETE FROM accounts WHERE id=:id";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters[":id"] = account.Id;
			database.Execute(sql, parameters);
		}

		public DataTable SummaryTotal(DataTable summary)
		{
			DataTable total = new DataTable();
			total.Rows.Add();
			
			foreach (DataColumn column in summary.Columns)
			{
				string columnName = column.ColumnName;
				total.Columns.Add(columnName, column.DataType);
				if (columnName == "name")
				{
					total.Rows[0][columnName] = "Grand Total";
				}
				else if (column.DataType.IsValueType)
				{
					total.Rows[0][columnName] = summary.Compute(string.Format("SUM({0})", columnName), null);
				}
				else
				{
					total.Rows[0][columnName] = 0;
				}
			}
			return total;
		}


	}
}
