using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoanBook
{
	public partial class NextMonthPaymentForm : Form
	{
		public NextMonthPaymentForm()
		{
			InitializeComponent();
		}

		private void FutureCashFlowForm_Load(object sender, EventArgs e)
		{
			NextMonthPayments payments = new NextMonthPayments(DatabaseFactory.Default);
			nextPaymentsGrid.DataSource = payments.Summary;

			GridFormatter gridFormatter = new GridFormatter(nextPaymentsGrid);
			gridFormatter.DefaultFormat();

			totalGrid.DataSource = payments.SummaryTotal(nextPaymentsGrid.DataSource as DataTable);
			gridFormatter.TotalGridFormat(totalGrid);
		}
	}
}
