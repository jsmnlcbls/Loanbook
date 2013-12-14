using System;
using System.Collections.Generic;
using System.Text;

namespace LoanBook
{
	public class InterestOnlyLoan : Loan
	{
		public InterestOnlyLoan(Database database)
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
			get { return LoanCalculator.PayableInterest(Principal, Interest); }
		}

		public override string ToString()
		{
			return "Interest Only Loan Of " + Principal + " At " + Interest + "%";
		}

		private decimal balance()
		{
			return 0;
		}
	}
}
