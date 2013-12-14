using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	public abstract class Loan
	{
		public enum LoanType
		{
			AmortizedPayment = 1,
			InterestOnlyPayment = 2
		}

		private long id = 0;
		private Account account;
		private LoanType type = LoanType.AmortizedPayment;
		private decimal defaultProcessingFeePercentage = 2;
		private decimal principal, interest, processingFee = 0, processingFeePercentage, reloanFeePercentage = 1;
		private int term;
		private bool isReloan;
		private string remarks;
		private DateTime startDate, takenDate;
		protected Database database;

		public long Id
		{
			get { return id; }
			set { id = value; }
		}

		public Account Account
		{
			get { return account; }
			set { account = value; }
		}

		public LoanType Type
		{
			get { return type; }
			set { type = value; }
		}

		public decimal Principal
		{
			get { return principal; }
			set { principal = value; }
		}

		public decimal InterestRate
		{
			get { return interest; }
			set { if (value >= 0) { interest = value; } }
		}

		public decimal ProcessingFeePercentage
		{
			get 
			{
				if (processingFeePercentage == 0 && processingFee != 0)
				{
					return LoanCalculator.ProcessingFeePercentage(Principal, processingFee);
				}
				return defaultProcessingFeePercentage; 
			}
			set { processingFeePercentage = value; }
		}

		public decimal ReloanFeePercentage
		{
			get { return reloanFeePercentage; }
			set { reloanFeePercentage = value; }
		}

		public bool IsReloan
		{
			get { return isReloan; }
			set { isReloan = value; }
		}

		public abstract decimal MonthlyDue { get; }

		public abstract decimal TotalPayable { get; }

		public abstract decimal Balance { get; }

		public abstract decimal TotalPayments { get; }

		public abstract int PaymentCount { get; }

		public int Term
		{
			get { return term; }
			set { term = value; }
		}

		public DateTime TakenDate
		{
			get { return takenDate; }
			set { takenDate = value; }
		}

		public DateTime StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}

		public decimal ProcessingFee
		{
			get 
			{
				if (processingFee == 0)
				{
					return LoanCalculator.ProcessingFee(Principal, ProcessingFeePercentage); 
				}
				return processingFee;
			}
			set { processingFee = value; }
		}

		public decimal ReloanFee
		{
			get
			{
				if (IsReloan)
				{
					return LoanCalculator.ReloanFee(Principal, Term - MonthsPaid);
				}
				return 0;
			}
		}

		public decimal ReleaseAmount
		{
			get 
			{
				if (Principal > 0)
				{
					return LoanCalculator.ReleaseAmount(Principal, ProcessingFeePercentage);
				}
				return 0;
			}
		}

		public decimal MonthsPaid
		{
			get { return monthsPaid(); }
		}

		public string Remarks
		{
			get { return remarks; }
			set { remarks = value; }
		}

		public Loan(Database database)
		{
			this.database = database;
		}

		public void MarkClosed()
		{
			string sql = "UPDATE loans SET is_closed=1, remarks=(CASE remarks IS NULL WHEN 1 THEN 'Closed' ELSE 'Closed. '  || remarks END) WHERE id=:id";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters[":id"] = Id;

			database.Execute(sql, parameters);
		}

		public void Save()
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			string sql;
			if (id == 0)
			{
				sql = "INSERT INTO loans (account_id, type, principal, term, interest, monthly_due, start_date, taken_date, processing_fee, reloan_fee, total_payable, remarks) "
					+ " VALUES (:accountId, :type, :principal, :term, :interest, :monthlyDue, :startDate, :takenDate, :processingFee, :reloanFee, :totalPayable, :remarks)";
				parameters[":accountId"] = account.Id;
			}
			else
			{
				sql = "UPDATE loans SET type=:type, principal=:principal, term=:term, "
					+ "interest=:interest, monthly_due=:monthlyDue, taken_date=:takenDate, "
					+ "start_date=:startDate, processing_fee=:processingFee, reloan_fee=:reloanFee, "
					+ "total_payable=:totalPayable, remarks=:remarks "
					+ "WHERE id=:id";
				parameters[":id"] = Id;
			}
			parameters[":type"] = Type;
			parameters[":principal"] = Principal;
			parameters[":term"] = Term;
			parameters[":interest"] = InterestRate;
			parameters[":monthlyDue"] = MonthlyDue;
			parameters[":processingFee"] = ProcessingFee;
			parameters[":reloanFee"] = ReloanFee;
			parameters[":totalPayable"] = TotalPayable;
			parameters[":remarks"] = Remarks;
			parameters[":startDate"] = StartDate;
			parameters[":takenDate"] = TakenDate;

			database.Execute(sql, parameters);
		}

		public virtual void Load()
		{
			string sql = "SELECT * FROM loans WHERE id=:id";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters[":id"] = Id;

			DataTable result = database.Query(sql, parameters);
			if (result.Rows.Count == 1)
			{
				DataRow row = result.Rows[0];
				Principal = (decimal)row["principal"];
				Type = (Loan.LoanType)int.Parse(row["type"].ToString());
				if (Type == LoanType.AmortizedPayment)
				{
					Term = int.Parse(row["term"].ToString());
				}
				InterestRate = (decimal)row["interest"];
				
				TakenDate = (DateTime)row["taken_date"];
				StartDate = (DateTime)row["start_date"];
				processingFee = (decimal)row["processing_fee"];
				//reloanFee = (decimal)row["reloan_fee"];
				if (row["remarks"].GetType() != typeof(System.DBNull))
				{
					Remarks = (string)row["remarks"];
				}
				else
				{
					Remarks = "";
				}

				Account loanAccount = new Account();
				loanAccount.Id = (long)row["account_id"];
				loanAccount.Load(database);

				Account = loanAccount;
				return;
			}
			throw new ApplicationException("Unable to load loan");
		}

		public override string ToString()
		{
			return Principal + " At " + InterestRate + "%";
		}

		private decimal monthsPaid()
		{
			string sql = "SELECT TOTAL(balance_deductible) AS total_payments FROM payments WHERE loan_id=:id";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters[":id"] = Id;

			decimal totalPayments = (decimal)(double)database.QueryScalar(sql, parameters);
			return totalPayments / MonthlyDue;
		}
	}
}
