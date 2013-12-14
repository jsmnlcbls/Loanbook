using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace LoanBook
{
	public partial class LoanBookForm : Form
	{
		private AllAccounts allAccounts;
		private DataTable summary;

		private static DateTime timelineStartDate = DateTime.MinValue, 
								timelineEndDate = DateTime.Today;
	
		public LoanBookForm()
		{
			InitializeComponent();
		}

		public static DateTime TimelineStartDate
		{
			get { return timelineStartDate; }
		}

		public static DateTime TimelineEndDate
		{
			get { return timelineEndDate; }
		}

		private void LoanBookForm_Load(object sender, EventArgs e)
		{
			totalGrid.ColumnHeadersVisible = false;
			allAccounts = new AllAccounts(DatabaseFactory.Default);
			allAccounts.StartDate = LoanBookForm.TimelineStartDate;
			allAccounts.EndDate = LoanBookForm.TimelineEndDate;
			this.summary = allAccounts.Summary;
			summaryGrid.DataSource = summary;
			summaryGrid.DataSourceChanged += new EventHandler(updateTotalGridDataSource);
			totalGrid.DataSource = allAccounts.SummaryTotal(summaryGrid.DataSource as DataTable);
			formatGrids();
		}

		private void updateTotalGridDataSource(object sender, EventArgs e)
		{
			totalGrid.DataSource = allAccounts.SummaryTotal((sender as DataGridView).DataSource as DataTable);
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AccountSaveForm form = new AccountSaveForm();
			form.AccountSaved += new AccountSaveForm.AccountSavedEventHandler(refreshForm);
			form.ShowDialog();
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form settingsForm = new SettingsForm();
			settingsForm.MdiParent = this;
			settingsForm.Show();
		}

		private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Account account = selectedAccount();
			account.Load(DatabaseFactory.Default);
			Form editAccountForm = new AccountSaveForm(account);
			editAccountForm.Show();
		}

		private void formatGrids()
		{
			GridFormatter summaryFormatter = new GridFormatter(summaryGrid);
			summaryFormatter.DefaultFormat();
			orderGridColumns(summaryGrid);

			GridFormatter totalFormatter = new GridFormatter(totalGrid);
			totalFormatter.TotalGridFormat();
			orderGridColumns(totalGrid);
		}

		private void orderGridColumns(DataGridView grid)
		{
			int index = 0;
			string[] columnNames = {"name", "loan_count", "total_principal", "total_payable",
									"payment_count", "total_interest_payment", "total_principal_payment",
								    "total_payments", "total_processing_fee", "total_reloan_fee", "balance",
								    "profit"};

			foreach (string column in columnNames)
			{
				grid.Columns[column].DisplayIndex = index++;
			}
		}

		private Account selectedAccount()
		{
			Account account = new Account();
			account.Id = long.Parse(summaryGrid.CurrentRow.Cells["id"].Value.ToString());
			account.Name = summaryGrid.CurrentRow.Cells["name"].Value.ToString();
			return account;
		}

		private void refreshForm()
		{
			allAccounts.StartDate = LoanBookForm.TimelineStartDate;
			allAccounts.EndDate = LoanBookForm.TimelineEndDate;
			this.summary = allAccounts.Summary;
			summaryGrid.DataSource = this.summary;
		}

		private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PaymentForm form = new PaymentForm(selectedAccount());
			form.PaymentSaved += new PaymentForm.PaymentSavedEventHandler(form_PaymentSaved);
			form.ShowDialog();
		}

		private void form_PaymentSaved(Payment payment)
		{
			refreshForm();
		}

		private void addLoanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoanSaveForm form = new LoanSaveForm(selectedAccount());
			form.LoanSaved += new LoanSaveForm.LoanSavedEventHandler(refreshForm);
			form.ShowDialog();
		}

		private void viewLoanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoanViewForm form = new LoanViewForm(selectedAccount());
			form.FormUpdated += new LoanViewForm.FormUpdatedEventHandler(form_FormUpdated);
			form.Show();
		}

		void form_FormUpdated()
		{
			refreshForm();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string message = string.Format("Are you sure you want to delete this account: {0}?", selectedAccount().Name);
			DialogResult result = Message.Confirm(message);
			if (result == System.Windows.Forms.DialogResult.Yes)
			{
				try
				{
					AllAccounts allAccounts = new AllAccounts(DatabaseFactory.Default);
					allAccounts.Remove(selectedAccount());
					refreshForm();
				}
				catch (Exception exception)
				{
					Message.Error("Unable to delete account.");
				}
			}
		}

		private void customTimelineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TimelineForm form = new TimelineForm();
			form.TimelineSelected += new TimelineForm.TimelineSelectedEventHandler(customTimelineForm_TimelineSelected);
			form.Show();
		}

		void customTimelineForm_TimelineSelected(DateTime startDate, DateTime endDate)
		{
			setSelectedTimeline(customTimelineToolStripMenuItem);
			LoanBookForm.timelineStartDate = startDate;
			LoanBookForm.timelineEndDate = endDate;
			allAccounts.StartDate = startDate;
			allAccounts.EndDate = endDate;
			refreshForm();
		}

		private void allTimelineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			setSelectedTimeline(sender);
			LoanBookForm.timelineStartDate = DateTime.MinValue;
			LoanBookForm.timelineEndDate = DateTime.MaxValue;
			allAccounts.StartDate = DateTime.MinValue;
			allAccounts.EndDate = DateTime.MaxValue;
			refreshForm();
		}

		private void nextMonthPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NextMonthPaymentForm form = new NextMonthPaymentForm();
			form.Show();
		}

		private void pastToPresentTimelineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			setSelectedTimeline(sender);
			LoanBookForm.timelineStartDate = DateTime.MinValue;
			LoanBookForm.timelineEndDate = DateTime.Today;
			refreshForm();
		}

		private void setSelectedTimeline(object sender)
		{
			foreach (ToolStripMenuItem item in timelineToolStripMenuItem.DropDownItems)
			{
				item.Checked = false;
			}
			(sender as ToolStripMenuItem).Checked = true;
		}
	}
}
