using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoanBook
{
	public partial class PaymentHistoryForm : Form
	{
		private Account account;
		private Loan loan;

		public delegate void FormUpdatedEventHandler();
		public event FormUpdatedEventHandler FormUpdated;

		public PaymentHistoryForm(Account account, Loan loan = null)
		{
			this.account = account;
			this.loan = loan;
			InitializeComponent();
			if (loan == null)
			{
				Text = account.Name + " Payment History For All Loans";
				menuStrip.Visible = false;
			}
			else
			{
				Text = account.Name + " Payment History For " + loan.ToString(); 
			}
		}

		private void PaymentHistory_Load(object sender, EventArgs e)
		{
			loadPaymentHistory();
			GridFormatter formatter = new GridFormatter(historyGrid);
			formatter.DefaultFormat();
			orderGridColumns();
		}

		private void orderGridColumns()
		{
			historyGrid.Columns["remarks"].DisplayIndex = historyGrid.Columns.Count - 1;
		}

		private void loadPaymentHistory()
		{
			PaymentHistory history = new PaymentHistory(DatabaseFactory.Default);
			history.StartDate = LoanBookForm.TimelineStartDate;
			history.EndDate = LoanBookForm.TimelineEndDate;
			history.Account = account;
			history.Loan = loan;
			historyGrid.DataSource = history.Summary;
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PaymentForm paymentForm = new PaymentForm(account, loan, selectedPayment());
			paymentForm.Text = "Edit Payment";
			paymentForm.PaymentSaved += new PaymentForm.PaymentSavedEventHandler(paymentForm_PaymentSaved);
			paymentForm.ShowDialog();
		}

		void paymentForm_PaymentSaved(Payment payment)
		{
			loadPaymentHistory();
			dispatchFormUpdatedEvent();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = Message.Confirm("Are you sure you want to delete this payment?", "Confirm Payment Removal");
			if (result == System.Windows.Forms.DialogResult.Yes)
			{
				PaymentHistory history = new PaymentHistory(DatabaseFactory.Default);
				history.Remove(selectedPayment());
				loadPaymentHistory();
				dispatchFormUpdatedEvent();
			}
		}

		private Payment selectedPayment()
		{
			Payment payment = new Payment(DatabaseFactory.Default);
			payment.Id = long.Parse(historyGrid.CurrentCell.OwningRow.Cells["id"].Value.ToString());
			payment.Account = account;
			payment.Loan = loan;
			payment.Load();
			return payment;
		}

		private void dispatchFormUpdatedEvent()
		{
			if (FormUpdated != null)
			{
				FormUpdated();
			}
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PaymentForm paymentForm = new PaymentForm(account, loan);
			paymentForm.PaymentSaved += new PaymentForm.PaymentSavedEventHandler(paymentForm_PaymentSaved);
			paymentForm.ShowDialog();
		}

	}
}
