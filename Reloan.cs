using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	class Reloan
	{
		private Database database;
		private Loan originalLoan, reloan;

		public Reloan(Database database, Loan loan)
		{
			this.database = database;
			this.originalLoan = loan;
			LoanFactory factory = new LoanFactory(DatabaseFactory.Default);
			reloan = factory.Clone(loan);
			reloan.IsReloan = true;
		}

		public decimal MonthlyDue
		{
			get 
			{
				return originalLoan.MonthlyDue;	
			}
		}

		public decimal ReleaseAmount
		{
			get
			{
				if (originalLoan.Term <= 12)
				{
					return shortTermReloanReleaseAmount();
				}
				else
				{
					return longTermReloanReleaseAmount();
				}
			}
		}

		public void Save()
		{
			if (originalLoan.Term <= 12)
			{
				shortTermReloanSave();
			}
			else
			{
				longTermReloanSave();
			}
		}

		private void longTermReloanSave()
		{
			LoanFactory factory = new LoanFactory(DatabaseFactory.Default);
			Loan newLoan = factory.Clone(originalLoan);
			newLoan.Id = 0;
			newLoan.IsReloan = true;
			try
			{
				database.BeginTransaction();
				originalLoan.MarkClosed();
				newLoan.Save();
				database.Commit();
			}
			catch (DatabaseException exception)
			{
				database.Rollback();
			}	
		}

		private void shortTermReloanSave()
		{
			Payment payment = new Payment(database);
			payment.Account = originalLoan.Account;
			payment.Loan = originalLoan;
			payment.Amount = originalLoan.Balance;
			payment.PaymentDate = DateTime.Now;
			if (string.IsNullOrEmpty(payment.Remarks))
			{
				payment.Remarks = "Reloan payment";
			}

			if (string.IsNullOrEmpty(reloan.Remarks))
			{
				reloan.Remarks = "Reloan";
			}
			reloan.Id = 0;
			try
			{
				database.BeginTransaction();
				originalLoan.MarkClosed();
				payment.Save();
				reloan.Save();
				database.Commit();
			}
			catch (DatabaseException exception)
			{
				database.Rollback();
			}	
		}

		private decimal longTermReloanReleaseAmount()
		{
			LoanFactory factory = new LoanFactory(DatabaseFactory.Default);
			Loan newLoan = factory.Clone(originalLoan);
			newLoan.InterestRate = originalLoan.InterestRate + 1;

			decimal newInterest = LoanCalculator.InterestPaymentPart(originalLoan.MonthlyDue, originalLoan.Principal, originalLoan.InterestRate+1, originalLoan.MonthlyDue);
			decimal newPrincipal = originalLoan.MonthlyDue - newInterest;
			
			return (newPrincipal * originalLoan.MonthsPaid) - originalLoan.ProcessingFee;
		}

		private decimal shortTermReloanReleaseAmount()
		{
			//original formula
			//decimal reloanBalance = (originalLoan.MonthlyDue - (shortTermReloanMonthlyInterest() - reloan.ReloanFee)) * monthsUnpaid();
			decimal balanceDue = originalLoan.MonthlyDue * monthsUnpaid();
			decimal reloanInterest = LoanCalculator.Interest(originalLoan.Principal, originalLoan.InterestRate) * monthsUnpaid();
			decimal reloanBalance = balanceDue - (reloanInterest - reloan.ReloanFee);
			return originalLoan.Principal - originalLoan.ProcessingFee - reloanBalance;
			//return originalLoan.Principal - originalLoan.ProcessingFee - reloanBalance;
		}

		private decimal shortTermReloanMonthlyInterest()
		{
			return originalLoan.Principal * (originalLoan.InterestRate / 100);
		}

		private decimal monthsUnpaid()
		{
			return originalLoan.Term - originalLoan.MonthsPaid;
		}

	}
}
