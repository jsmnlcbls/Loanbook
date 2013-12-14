using System;
using System.Collections.Generic;
using System.Text;

namespace LoanBook
{
	class LoanFactory
	{
		private Database database;

		public LoanFactory(Database database)
		{
			this.database = database;
		}

		public Loan Create(Loan.LoanType type)
		{
			if (type == Loan.LoanType.AmortizedPayment)
			{
				return AmortizedLoan();
			}
			else if (type == Loan.LoanType.InterestOnlyPayment)
			{
				return PerpetualInterestLoan();
			}
			throw new ArgumentException("Unsupported loan type");
		}

		public Loan Clone(Loan loan)
		{
			Loan clone;
			if (loan.Type == Loan.LoanType.AmortizedPayment)
			{
				clone = AmortizedLoan();
				copyCommonProperties(loan, clone);
				clone.Term = loan.Term;
			}
			else if (loan.Type == Loan.LoanType.InterestOnlyPayment)
			{
				clone = PerpetualInterestLoan();
				copyCommonProperties(loan, clone);
			}
			else
			{
				throw new ArgumentException("Unsupported loan type");
			}

			return clone;
		}

		public AmortizedLoan AmortizedLoan()
		{
			return new AmortizedLoan(database);
		}

		public PerpetualInterestLoan PerpetualInterestLoan()
		{
			return new PerpetualInterestLoan(database);
		}

		public AmortizedLoan ConvertToAmortizedLoan(PerpetualInterestLoan loan, int term)
		{
			AmortizedLoan outputLoan = AmortizedLoan();
			copyCommonProperties(loan, outputLoan);
			outputLoan.Term = term;
			return outputLoan;
		}

		public PerpetualInterestLoan ConvertToPerpetualInterestLoan(AmortizedLoan loan)
		{
			PerpetualInterestLoan outputLoan = PerpetualInterestLoan();
			copyCommonProperties(loan, outputLoan);
			return outputLoan;
		}

		private void copyCommonProperties(Loan inputLoan, Loan outputLoan)
		{
			outputLoan.Id = inputLoan.Id;
			outputLoan.Account = inputLoan.Account;
			outputLoan.Principal = inputLoan.Principal;
			outputLoan.InterestRate = inputLoan.InterestRate;
			outputLoan.ProcessingFeePercentage = inputLoan.ProcessingFeePercentage;
			outputLoan.TakenDate = inputLoan.TakenDate;
			outputLoan.StartDate = inputLoan.StartDate;
			outputLoan.Remarks = inputLoan.Remarks;
		}
	}
}
