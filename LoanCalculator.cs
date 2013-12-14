using System;
using System.Collections.Generic;
using System.Text;

namespace LoanBook
{
	public class LoanCalculator
	{
		public static decimal ProcessingFeePercentage(string principal, string processingFee)
		{
			decimal principalValue, processingFeeValue;

			if (!decimal.TryParse(principal, out principalValue))
			{
				throw new ArgumentException("Invalid principal value");
			}
			if (!decimal.TryParse(processingFee, out processingFeeValue))
			{
				throw new ArgumentException("Invalid processing fee value");
			}
			return ProcessingFeePercentage(principalValue, processingFeeValue);
		}

		public static decimal ProcessingFeePercentage(decimal principal, decimal processingFee)
		{
			return (processingFee / principal) * 100;
		}

		public static decimal ReloanFee(decimal principal, decimal unpaidMonths, decimal reloanFeePercentage = 1)
		{
			return Interest(principal, reloanFeePercentage) * unpaidMonths;
		}

		public static decimal ProcessingFee(decimal principal, decimal percentage)
		{
			return Interest(principal, percentage);
		}

		public static decimal ProcessingFee(string principal, string percentageCut)
		{
			decimal principalValue, percentageCutValue;

			if (!decimal.TryParse(principal, out principalValue))
			{
				throw new ArgumentException("Invalid principal value");
			}
			if (!decimal.TryParse(percentageCut, out percentageCutValue))
			{
				throw new ArgumentException("Invalid percetange cut value");
			}
			return ProcessingFee(principalValue, percentageCutValue);
		}

		public static decimal ReleaseAmount(string principal, string percentageCut)
		{
			decimal principalValue, percentageCutValue;
			if (!decimal.TryParse(principal, out principalValue))
			{
				throw new ArgumentException("Invalid principal value");
			}
			if (!decimal.TryParse(percentageCut, out percentageCutValue))
			{
				throw new ArgumentException("Invalid percentage cut value");
			}
			return ReleaseAmount(principalValue, percentageCutValue);
		}

		public static decimal ReleaseAmount(decimal principal, decimal percentageCut)
		{
			return principal - ProcessingFee(principal, percentageCut);
		}

		public static decimal MonthlyDue(Loan.LoanType type, string principal, string interest, string term = "0", bool nearestTenth = true)
		{
			decimal principalValue, interestValue;
			int termValue;

			if (!decimal.TryParse(principal, out principalValue))
			{
				throw new ArgumentException("Invalid principal value");
			}
			if (!decimal.TryParse(interest, out interestValue))
			{
				throw new ArgumentException("Invalid interest value");
			}
			if (type == Loan.LoanType.AmortizedPayment)
			{
				if (!int.TryParse(term, out termValue))
				{
					throw new ArgumentException("Invalid term value");
				}
			}
			else
			{
				termValue = 0;
			}
			return MonthlyDue(type, principalValue, interestValue, termValue, nearestTenth);
		}

		public static decimal MonthlyDue(Loan.LoanType type, decimal principal, decimal interest, int term = 0, bool nearestTenth = true)
		{
			if (type == Loan.LoanType.AmortizedPayment)
			{
				return LoanCalculator.Amortization(principal, term, interest, nearestTenth);
			}
			else if (type == Loan.LoanType.InterestOnlyPayment)
			{
				return LoanCalculator.PayableInterest(principal, interest, nearestTenth);
			}
			throw new ArgumentException("Unsupported loan type");
		}

		public static decimal PayableInterest(string principal, string interest, bool nearestTenth = true)
		{
			decimal principalValue, interestValue;

			if (!decimal.TryParse(principal, out principalValue))
			{
				throw new ArgumentException("Invalid principal amount");
			}
			if (!decimal.TryParse(interest, out interestValue))
			{
				throw new ArgumentException("Invalid interest value");
			}
			return PayableInterest(principalValue, interestValue, nearestTenth);
		}

		public static decimal PayableInterest(decimal principal, decimal interest, bool nearestTenthRoundUp = true)
		{
			decimal payable = Math.Round(principal * (interest / 100));
			if (nearestTenthRoundUp)
			{
				payable = roundUp(payable);
			}
			else
			{
				payable = Math.Round(payable, 2);
			}
			return payable;
		}

		public static decimal PrincipalPaymentPart(string amount, Loan loan)
		{
			decimal amountValue;
			if (!decimal.TryParse(amount, out amountValue))
			{
				throw new ArgumentException("Invalid amount.");
			}
			return PrincipalPaymentPart(amountValue, loan);
		}

		public static decimal PrincipalPaymentPart(decimal amount, Loan loan)
		{
			return amount - InterestPaymentPart(amount, loan);
		}

		public static decimal InterestPaymentPart(string amount, Loan loan)
		{
			
			return InterestPaymentPart(convertAmount(amount), loan);
		}

		public static decimal InterestPaymentPart(decimal amount, Loan loan)
		{
			return InterestPaymentPart(amount, loan.Principal, loan.InterestRate, loan.MonthlyDue);
		}

		public static decimal InterestPaymentPart(string amount, string principal, string interest, string monthlyDue)
		{
			decimal amountValue, principalValue, interestValue, monthlyDueValue;
			if (!decimal.TryParse(amount, out amountValue))
			{
				throw new ArgumentException("Invalid amount.");
			}
			if (!decimal.TryParse(principal, out principalValue))
			{
				throw new ArgumentException("Invalid principal.");
			}
			if (!decimal.TryParse(interest, out interestValue))
			{
				throw new ArgumentException("Invalid interest.");
			}
			if (!decimal.TryParse(monthlyDue, out monthlyDueValue))
			{
				throw new ArgumentException("Invalid monthly due.");
			}

			return InterestPaymentPart(amountValue, principalValue, interestValue, monthlyDueValue);
		}

		public static decimal InterestPaymentPart(decimal amount, decimal principal, decimal interest, decimal monthlyDue)
		{
			return Math.Round(amount * (principal * (interest / 100)) / monthlyDue);
		}

		public static decimal Amortization(string principal, string term, string interest, bool nearestTenth = true)
		{
			decimal principalValue, interestValue;
			int termValue;

			if (!decimal.TryParse(principal, out principalValue))
			{
				throw new ArgumentException("Invalid principal amount");
			}

			if (!int.TryParse(term, out termValue))
			{
				throw new ArgumentException("Invalid loan term");
			}

			if (!decimal.TryParse(interest, out interestValue))
			{
				throw new ArgumentException("Invalid interest value");
			}

			return Amortization(principalValue, termValue, interestValue, nearestTenth);
		}

		public static decimal Amortization(decimal principal, int term, decimal interest, bool nearestTenth = true)
		{
			if (principal <= 0)
			{
				throw new ArgumentException("Invalid principal amount");
			}

			if (term <= 0)
			{
				throw new ArgumentException("Invalid loan term");
			}

			if (interest < 0)
			{
				throw new ArgumentException("Invalid interest");
			}

			decimal totalInterest = 1 + ((term * interest) / 100);
			decimal amortization = (principal * totalInterest) / term;

			if (nearestTenth)
			{
				return roundUp(amortization);
			}
			else
			{
				return Math.Round(amortization, 2);
			}
		}

		public static decimal Interest(decimal amount, decimal percentage)
		{
			return Math.Round(amount * (percentage / 100));
		}

		private static decimal convertAmount(String amount)
		{
			decimal amountValue;
			if (!decimal.TryParse(amount, out amountValue))
			{
				throw new ArgumentException("Invalid amount.");
			}
			return amountValue;
		}

		private static decimal roundUp(decimal amount)
		{
			return (Math.Ceiling(amount / 10)) * 10;
		}
	}
}
