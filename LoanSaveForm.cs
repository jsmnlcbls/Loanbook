using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoanBook
{
	public partial class LoanSaveForm : Form
	{
		private Account account;
		private Loan loan;

		public delegate void LoanSavedEventHandler();
		public event LoanSavedEventHandler LoanSaved;

		private ErrorProvider principalError, termError, interestError, processingFeeError;

		public LoanSaveForm(Account account, Loan loan = null)
		{
			if (loan == null)
			{
				loan = defaultLoan();
			}

			this.account = account;
			this.loan = loan;
			this.loan.Account = account;
			principalError = new ErrorProvider(this);
			termError = new ErrorProvider(this);
			interestError = new ErrorProvider(this);
			processingFeeError = new ErrorProvider(this);
			InitializeComponent();
			loadLoan(loan);
		}

		private void LoanSaveForm_Load(object sender, EventArgs e)
		{
			principalInput.TextChanged += new EventHandler(principalInput_TextChanged);
			processingFee.TextChanged += new EventHandler(processingFee_TextChanged);
			interestInput.TextChanged += new EventHandler(interestInput_TextChanged);
			termInput.TextChanged += new EventHandler(termInput_TextChanged);
			amortizedRadio.CheckedChanged += new EventHandler(amortizedRadio_CheckedChanged);
			startDateInput.ValueChanged += new EventHandler(startDateInput_ValueChanged);

			accountName.Text = account.Name;
			saveButton.Click += new EventHandler(saveButton_Click);
		}

		private void startDateInput_ValueChanged(object sender, EventArgs e)
		{
			loan.StartDate = startDateInput.Value;
			loadDateComputations(loan);
		}

		private void amortizedRadio_CheckedChanged(object sender, EventArgs e)
		{
			if ((sender as RadioButton).Checked)
			{
				toggleLoanType(Loan.LoanType.AmortizedPayment);
			}
			else
			{
				toggleLoanType(Loan.LoanType.InterestOnlyPayment);
				termError.Clear();
			}
			loadLoan(this.loan);
		}

		private void interestInput_TextChanged(object sender, EventArgs e)
		{
			decimal interest;
			if (decimal.TryParse(interestInput.Text, out interest))
			{
				loan.InterestRate = interest;
				loadLoanComputations(loan);
				interestError.Clear();
			}
			else
			{
				interestError.SetError(interestInput, "Invalid interest rate");
			}
		}

		void termInput_TextChanged(object sender, EventArgs e)
		{
			int term;
			if (int.TryParse(termInput.Text, out term))
			{
				loan.Term = term;
				loadLoanComputations(loan);
				loadDateComputations(loan);
				termError.Clear();
			}
			else
			{
				termError.SetError(termInput, "Invalid loan term");
			}
		}

		private void processingFee_TextChanged(object sender, EventArgs e)
		{
			decimal percentage;
			if (decimal.TryParse(processingFee.Text, out percentage))
			{
				loan.ProcessingFeePercentage = percentage;
				loadLoanComputations(loan);
				processingFeeError.Clear();
			}
			else
			{
				processingFeeError.SetError(processingFee, "Invalid processing fee percentage");
			}
		}

		private void principalInput_TextChanged(object sender, EventArgs e)
		{
			decimal principal;
			if (decimal.TryParse(principalInput.Text, out principal))
			{
				loan.Principal = principal;
				loadLoanComputations(loan);
				principalError.Clear();
			}
			else
			{
				principalError.SetError(principalInput, "Invalid principal amount");
			}
		}

		private Loan defaultLoan()
		{
			Loan loan = new AmortizedLoan(DatabaseFactory.Default);
			loan.TakenDate = DateTime.Now;
			loan.StartDate = DateTime.Now.AddMonths(1);
			loan.ProcessingFeePercentage = 2;
			return loan;
		}

		private void loadLoan(Loan loan)
		{
			principalInput.Text = (loan.Principal == 0) ? "" : string.Format("{0:#,##0}", loan.Principal);
			interestInput.Text = loan.InterestRate.ToString();
			processingFee.Text = (loan.ProcessingFeePercentage == 0) ? "" : string.Format("{0:#,##0}", loan.ProcessingFeePercentage);
			takenDateInput.Value = loan.TakenDate;
			startDateInput.Value = loan.StartDate;
			remarks.Text = loan.Remarks;

			if (loan.Type == Loan.LoanType.AmortizedPayment)
			{
				amortizedRadio.Checked = true;
				termInput.Text = (loan.Term == 0) ? "" : loan.Term.ToString();
				termInput.Enabled = true;
			}
			else if (loan.Type == Loan.LoanType.InterestOnlyPayment) 
			{
				monthlyInterestRadio.Checked = true;
				termInput.Enabled = false;
			}
			loadLoanComputations(loan);
			loadDateComputations(loan);
		}

		private void loadLoanComputations(Loan loan)
		{
			monthlyDue.Text = string.Format("{0:#,##0}", loan.MonthlyDue);
			releaseAmount.Text = string.Format("{0:#,##0}", loan.ReleaseAmount);
		}

		private void loadDateComputations(Loan loan)
		{
			endDate.Text = loan.StartDate.AddMonths(loan.Term - 1).ToShortDateString();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			if (!validateLoanInputs())
			{
				return;
			}
			try
			{
				loan.StartDate = startDateInput.Value;
				loan.TakenDate = takenDateInput.Value;
				loan.Save();
				if (LoanSaved != null)
				{
					LoanSaved();
				}
				Close();
			}
			catch (DatabaseException exception)
			{
				throw;
				//Message.Error("Unable to save loan");	
			}
		}

		private bool validateLoanInputs()
		{
			decimal principal;
			if (string.IsNullOrEmpty(principalInput.Text) ||
				!decimal.TryParse(principalInput.Text, out principal))
			{
				Message.Error("Invalid loan principal");
				return false;
			}

			decimal interest;
			if (string.IsNullOrEmpty(interestInput.Text) ||
				!decimal.TryParse(interestInput.Text, out interest))
			{
				Message.Error("Invalid loan interest");
				return false;
			}
			return true;
		}

		private void toggleLoanType(Loan.LoanType type)
		{
			LoanFactory factory = new LoanFactory(DatabaseFactory.Default);

			if (type == Loan.LoanType.AmortizedPayment)
			{
				int term;
				bool parseResult = int.TryParse(termInput.Text, out term);
				term = parseResult ? term : 0;
				loan = factory.ConvertToAmortizedLoan(this.loan as PerpetualInterestLoan, term);
			}
			else if (type == Loan.LoanType.InterestOnlyPayment)
			{
				loan = factory.ConvertToPerpetualInterestLoan(this.loan as AmortizedLoan);
			}
			else
			{
				throw new ArgumentException("Unsupported loan type");
			}
		}
	}
}
