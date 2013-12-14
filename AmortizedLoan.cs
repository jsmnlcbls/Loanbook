using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	public class AmortizedLoan : Loan
	{
		private decimal totalPayments, totalDeductible;
		private bool isPaymentDataLoaded = false;
		int paymentCount;

		public AmortizedLoan(Database database)
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
			get 
			{
				if (Principal > 0 && Term > 0)
				{
					return LoanCalculator.Amortization(Principal, Term, InterestRate);
				}
				return 0;
			}
		}

		public override string ToString()
		{
			return String.Format("Amortized Loan Of {0} At {1}% For {2} Months",
								 string.Format("{0:#,##0}", Principal), InterestRate, Term);
		}

		public DateTime EndDate
		{
			get { return StartDate.AddMonths(Term); }
		}

		public override void Load()
		{
			initializePaymentData();
			base.Load();
		}

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
