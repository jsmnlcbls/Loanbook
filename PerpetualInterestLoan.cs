using System;
using System.Collections.Generic;
using System.Text;

namespace LoanBook
{
	public class PerpetualInterestLoan : Loan
	{
		public PerpetualInterestLoan(Database database)
			: base(database)
		{
			Type = LoanType.InterestOnlyPayment;
		}

		public override decimal TotalPayable
		{
			get { return Principal; }
		}

		public override decimal Balance
		{
			get { return balance(); }
		}

		public override decimal TotalPayments
		{
			get { throw new NotImplementedException(); }
		}

		public override int PaymentCount
		{
			get { throw new NotImplementedException(); }
		}

		public override decimal MonthlyDue
		{
			get { return LoanCalculator.PayableInterest(Principal, InterestRate); }
		}

		public override string ToString()
		{
			return String.Format("Perpetual Interest Loan Of {0} At {1}%", 
								 string.Format("{0:#,##0}", Principal), InterestRate);
		}

		private decimal balance()
		{
			return 0;
		}
	}
}
