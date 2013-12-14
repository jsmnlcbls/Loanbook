using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	class NextMonthPayments
	{
		private Database database;
		private DatabaseView view;

		public NextMonthPayments(Database database)
		{
			this.database = database;
			this.view = new DatabaseView(database);
		}

		public DataTable Summary
		{
			get { return view.NextMonthPayments(); }
		}

		public DataTable SummaryTotal(DataTable summary)
		{
			DataTable total = new DataTable();
			total.Rows.Add();
			total.Columns.Add("name", typeof(string));
			total.Columns.Add("next_payment", typeof(decimal));

			total.Rows[0]["next_payment"] = summary.Compute(string.Format("SUM({0})", "next_payment"), null);
			return total;
		}
	}
}
