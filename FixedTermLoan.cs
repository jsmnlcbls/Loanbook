using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	public class FixedTermLoan : Loan
	{
		private decimal totalPayments, totalDeductible;
		private bool isPaymentDataLoaded = false;
		int paymentCount;

		public FixedTermLoan(Database database)
			: base(database)
		{
			Type = LoanType.AmortizedPayment;
		}
		
		public override decimal TotalPayable
		{
			get { return MonthlyDue * Term; }
		}

		public override decimal Balance
		{
			get
			{
				if (!isPaymentDataLoaded)
				{
					initializePaymentData();
				}
				return TotalPayable - totalDeductible;
			}
		}

		public override int PaymentCount
		{
			get
			{
				if (!isPaymentDataLoaded)
				{
					initializePaymentData();
				}
				return paymentCount;
			}
		}

		public override decimal TotalPayments
		{
			get
			{
				if (!isPaymentDataLoaded)
				{
					initializePaymentData();
				}
				return totalPayments;
			}
		}

		public override decimal MonthlyDue
		{
			get { return LoanCalculator.Amortization(Principal, Term, Interest); }
		}

		public override string ToString()
		{
			return "Fixed Term Loan Of " + Principal + " At " + Interest + "%" + " For " + Term + " Months";
		}

		public DateTime EndDate
		{
			get { return StartDate.AddMonths(Term); }
		}
		/*
		private decimal balance()
		{
			string sql = "SELECT TOTAL(balance_deductible) FROM payments WHERE loan_id=:loanId";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters[":loanId"] = Id;

			decimal deductible;
			object result = base.database.QueryScalar(sql, parameters);
			System.Diagnostics.Debug.Print(result.GetType().ToString());
			if (null != result)
			{
				System.Diagnostics.Debug.Print(result.ToString());
				if (!decimal.TryParse(result.ToString(), out deductible))
				{
					deductible = 0;
				}
				System.Diagnostics.Debug.Print("Deductible: " + deductible);
			}
			else
			{
				deductible = 0;
			}
			
			return TotalPayable - deductible;
		}
		 */

		private void initializePaymentData()
		{
			string sql = "SELECT COUNT(id) AS payment_count, "
						+ "TOTAL(amount) AS total_payments, "
						+ "TOTAL(balance_deductible) AS total_deductible  "
						+ "FROM payments WHERE loan_id=:loanId";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters[":loanId"] = Id;

			DataTable result = base.database.Query(sql, parameters);
			if (result.Rows.Count == 1)
			{
				this.paymentCount = int.Parse(result.Rows[0]["payment_count"].ToString());
				this.totalPayments = decimal.Parse(result.Rows[0]["total_payments"].ToString());
				this.totalDeductible = decimal.Parse(result.Rows[0]["total_deductible"].ToString());
				this.isPaymentDataLoaded = true;
			}
		}
	}
}
