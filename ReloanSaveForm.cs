using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoanBook
{
	public partial class ReloanSaveForm : Form
	{
		private Account account;
		private Loan loan, originalLoan;
		private Reloan reloan;

		public delegate void ReloanSavedEventHandler();
		public event ReloanSavedEventHandler ReloanSaved;

		public ReloanSaveForm(Account account, Loan loan = null)
		{
			this.account = account;
			this.originalLoan = loan;
			this.loan = cloneOriginalLoan(loan);

			reloan = new Reloan(DatabaseFactory.Default, originalLoan);
			InitializeComponent();
			loadLoanSelector();
		}

		private void ReloanSaveForm_Load(object sender, EventArgs e)
		{
			loadReloanComputations();
			takenDateInput.Value = DateTime.Now;
			startDateInput.Value = takenDateInput.Value.AddMonths(1);
			endDate.Text = startDateInput.Value.AddMonths(loan.Term).ToShortDateString();
		}

		private Loan cloneOriginalLoan(Loan originalLoan)
		{
			LoanFactory factory = new LoanFactory(DatabaseFactory.Default);
			return factory.Clone(originalLoan);
		}

		private void loadReloanComputations()
		{
			
			monthlyDue.Text = string.Format("{0:#,##0}", reloan.MonthlyDue);
			releaseAmount.Text = string.Format("{0:#,##0}", reloan.ReleaseAmount);
		}

		private void loadLoanSelector()
		{
			if (this.loan == null)
			{
				AccountLoans loanList = new AccountLoans(DatabaseFactory.Default, account);
				foreach (Loan loan in loanList)
				{
					loanSelector.Items.Add(loan);
				}
			}
			else
			{
				loanSelector.Items.Add(loan);
				loanSelector.SelectedItem = loan;
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			try
			{
				reloan.Save();
				if (ReloanSaved != null)
				{
					ReloanSaved();
				}
				Close();
			}
			catch (ApplicationException exception)
			{
				Message.Error("Unable to save reloan");
			}
			
		}
	}
}
