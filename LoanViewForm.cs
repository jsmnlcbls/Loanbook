using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoanBook
{
	public partial class LoanViewForm : Form
	{
		private Account account;
		private AccountLoans accountLoans;

		public delegate void FormUpdatedEventHandler();
		public event FormUpdatedEventHandler FormUpdated;

		public LoanViewForm(Account account)
		{
			InitializeComponent();
			this.account = account;
			Text = account.Name + " Loans";
			accountLoans = new AccountLoans(DatabaseFactory.Default, account);
			accountLoans.StartDate = LoanBookForm.TimelineStartDate;
			accountLoans.EndDate = LoanBookForm.TimelineEndDate;
			accountLoans.IncludeClosedLoans = true;
		}

		private void LoanViewForm_Load(object sender, EventArgs e)
		{
			
			loanGrid.DataSource = accountLoans.Summary;
			GridFormatter gridFormatter = new GridFormatter(loanGrid);
			gridFormatter.DefaultFormat();
		}

		private Loan selectedLoan()
		{
			long loanId = long.Parse(loanGrid.CurrentCell.OwningRow.Cells["id"].Value.ToString());
			Loan loan = accountLoans[loanId];
			loan.Load();
			return loan;
		}

		private void form_PaymentSaved(Payment payment)
		{
			form_UpdateForm();
		}
		
		private void form_UpdateForm()
		{
			accountLoans = new AccountLoans(DatabaseFactory.Default, account);
			accountLoans.StartDate = LoanBookForm.TimelineStartDate;
			accountLoans.EndDate = LoanBookForm.TimelineEndDate;
			loanGrid.DataSource = accountLoans.Summary;
			if (FormUpdated != null)
			{
				FormUpdated();
			}
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoanSaveForm form = new LoanSaveForm(account, selectedLoan());
			form.LoanSaved += new LoanSaveForm.LoanSavedEventHandler(form_UpdateForm);
			form.Text = "Edit Loan";
			form.ShowDialog();
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoanSaveForm form = new LoanSaveForm(account);
			form.LoanSaved += new LoanSaveForm.LoanSavedEventHandler(form_UpdateForm);
			form.ShowDialog();
		}

		private void reloanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReloanSaveForm form = new ReloanSaveForm(account, selectedLoan());
			form.ReloanSaved += new ReloanSaveForm.ReloanSavedEventHandler(form_UpdateForm);
			form.ShowDialog();
		}

		private void addPaymentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PaymentForm form = new PaymentForm(account, selectedLoan());
			form.PaymentSaved += new PaymentForm.PaymentSavedEventHandler(form_PaymentSaved);
			form.ShowDialog();
		}

		private void historyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PaymentHistoryForm form = new PaymentHistoryForm(account, selectedLoan());
			form.FormUpdated += new PaymentHistoryForm.FormUpdatedEventHandler(form_UpdateForm);
			form.Show();
		}
	}
}
