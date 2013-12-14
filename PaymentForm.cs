using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoanBook
{
	public partial class PaymentForm : Form
	{
		private Account account;
		private Loan loan;
		private Payment payment;
		private ErrorProvider paymentError, loanError;

		public delegate void PaymentSavedEventHandler(Payment payment);
		public event PaymentSavedEventHandler PaymentSaved;

		public PaymentForm(Account account, Loan loan = null, Payment payment = null)
		{
			this.account = account;
			this.loan = loan;
			if (payment == null)
			{
				payment = defaultPayment();
			}
			this.payment = payment;
			this.payment.Account = account;
			this.payment.Loan = loan;
			paymentError = new ErrorProvider(this);
			loanError = new ErrorProvider(this);
			InitializeComponent();
			Text = "Payment Form";
		}

		private void PaymentForm_Load(object sender, EventArgs e)
		{
			this.accountName.Text = account.Name;
			loadLoanSelector();
			loadPaymentParts(true);
			loanSelector.SelectedValueChanged += new EventHandler(loanSelector_SelectedValueChanged);
			paymentAmount.TextChanged += new EventHandler(paymentAmount_TextChanged);
			halfPaymentCheckbox.CheckedChanged += new EventHandler(halfPayment_CheckedChanged);
			interestOnlyCheckbox.CheckedChanged += new EventHandler(interestOnlyCheckbox_CheckedChanged);
		}

		private Payment defaultPayment()
		{
			Payment payment = new Payment(DatabaseFactory.Default);
			payment.PaymentDate = DateTime.Now;
			payment.Amount = 0;
			payment.Remarks = "";
			return payment;
		}

		void interestOnlyCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			payment.IsInterestPayment = (interestOnlyCheckbox.Checked) ? true : false;
			loadPaymentParts();
		}

		void paymentAmount_TextChanged(object sender, EventArgs e)
		{
			decimal paymentValue;
			if (decimal.TryParse(paymentAmount.Text, out paymentValue))
			{
				payment.Amount = paymentValue;
				paymentError.Clear();
			}
			else if (String.IsNullOrEmpty(paymentAmount.Text))
			{
				payment.Amount = 0;
			}
			else
			{
				paymentError.SetError(paymentAmount, "Invalid payment amount");
			}
			loadPaymentParts();
		}

		private void halfPayment_CheckedChanged(object sender, EventArgs e)
		{
			payment.IsHalfPayment = (halfPaymentCheckbox.Checked) ? true : false;
			loadPaymentParts(true);
		}

		void loanSelector_SelectedValueChanged(object sender, EventArgs e)
		{
			payment.Loan = (Loan)(sender as ComboBox).SelectedItem;
			loadDefaultPaymentInputs();
		}

		private void loadPaymentParts(bool updatePrincipal = false)
		{
			if (updatePrincipal)
			{
				paymentAmount.Text = string.Format("{0:#,##0}", payment.Amount);
			}
			if (payment.Loan != null)
			{
				principalPayment.Text = string.Format("{0:#,##0}", payment.PrincipalAmount);
				interestPayment.Text = string.Format("{0:#,##0}", payment.InterestAmount);
			}
		}

		void loadDefaultPaymentInputs()
		{
			interestOnlyCheckbox.Checked = (payment.Loan.Type == Loan.LoanType.InterestOnlyPayment) ? true : false;
			halfPaymentCheckbox.Checked = (payment.IsHalfPayment) ? true : false;
			paymentAmount.Text = string.Format("{0:#,##0}", payment.Loan.MonthlyDue);
			paymentDate.Value = payment.PaymentDate;
			remarks.Text = payment.Remarks;
			
		}

		private void loadLoanSelector(Payment initialPayment = null)
		{
			if (this.loan == null)
			{
				AccountLoans loanList = new AccountLoans(DatabaseFactory.Default, account);
				loanList.IncludeClosedLoans = false;
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
			if (!validatePayment())
			{
				return;
			}

			try
			{
				payment.PaymentDate = paymentDate.Value;
				payment.Remarks = remarks.Text;
				payment.Save();
				Close();
				if (PaymentSaved != null)
				{
					PaymentSaved(payment);
				}
			}
			catch (ApplicationException exception)
			{
				Message.Error("Unable to save payment.");	
			}
		}

		private bool validatePayment()
		{
			decimal amount;
			int error = 0;
			if (loanSelector.SelectedItem == null)
			{
				loanError.SetError(loanSelector, "No loan is selected");
				error++;
			}
			if (string.IsNullOrEmpty(paymentAmount.Text.Trim()) ||
				!decimal.TryParse(paymentAmount.Text, out amount))
			{
				paymentError.SetError(paymentAmount, "Invalid payment amount");
				error++;
			}

			if (error == 0)
			{
				return true;
			}
			return false;
		}
	}
}
