using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	public class Payment
	{
		private long id = 0;
		private Loan loan;
		private Account account;
		private DateTime paymentDate;
		private decimal amount;
		private bool interestPayment, halfPayment;
		private Database database;
		private string remarks;

		public long Id
		{
			get { return id; }
			set { id = value; }
		}

		public Loan Loan
		{
			get { return loan; }
			set { loan = value; }
		}

		public Account Account
		{
			get { return account; }
			set { account = value; }
		}

		public DateTime PaymentDate
		{
			get { return paymentDate; }
			set { paymentDate = value; }
		}

		public decimal Amount
		{
			get 
			{
				if (IsHalfPayment)
				{
					return amount / 2;
				}
				return amount;
			}
			set 
			{
				if (IsHalfPayment)
				{
					amount = 2 * value;
				}
				else
				{
					amount = value;
				}
			}
		}

		public decimal PrincipalAmount
		{
			get { return principalAmount(); }
		}

		public decimal InterestAmount
		{
			get { return interestAmount(); }
		}

		public bool IsInterestPayment
		{
			get { return interestPayment; }
			set { interestPayment = value; }
		}

		public bool IsHalfPayment
		{
			get { return halfPayment; }
			set { halfPayment = value; }
		}

		public string Remarks
		{
			get { return remarks; }
			set { remarks = value; }
		}

		public Payment(Database database)
		{
			this.database = database;
		}

		public void Load()
		{
			if (id == 0)
			{
				return;
			}

			string sql = "SELECT * FROM payments WHERE id = :id";
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters[":id"] = Id;

			DataTable result = database.Query(sql, parameters);

			if (result.Rows.Count != 1)
			{
				throw new ApplicationException("Unable to load payment");
			}

			DataRow row = result.Rows[0];
			PaymentDate = (DateTime)row["date_paid"];
			Amount = (decimal)row["amount"];

			if ((decimal)row["balance_deductible"] == 0)
			{
				IsInterestPayment = true;
			}
			try
			{
				Remarks = (string)row["remarks"];
			}
			catch (InvalidCastException exception)
			{
				Remarks = "";
			}
		}

		public void Save()
		{
			string sql;
			Dictionary<string, object> parameters = new Dictionary<string,object>();
			
			parameters[":datePaid"] = PaymentDate;
			parameters[":amount"] = Amount;
			parameters[":principalPayment"] = PrincipalAmount;
			parameters[":interestPayment"] = InterestAmount;
			parameters[":remarks"] = Remarks;
			if (id == 0)
			{
				parameters[":accountId"] = Account.Id;
				parameters[":loanId"] = Loan.Id;
				sql = "INSERT INTO payments (loan_id, account_id, date_paid, amount, interest_payment, principal_payment, balance_deductible, remarks) "
					+ " VALUES (:loanId, :accountId, :datePaid, :amount, :interestPayment, :principalPayment, :balanceDeductible, :remarks)";
			}
			else
			{
				parameters[":id"] = Id;
				sql = "UPDATE payments SET date_paid=:datePaid, amount=:amount, "
					+ "interest_payment=:interestPayment, principal_payment=:principalPayment, "
					+ "balance_deductible=:balanceDeductible, remarks=:remarks "
					+ "WHERE id=:id";
			}

			decimal balanceDeductible = Amount;
			if (IsInterestPayment)
			{
				balanceDeductible = 0;
			}
			parameters[":balanceDeductible"] = balanceDeductible;
			
			database.Execute(sql, parameters);
		}

		private decimal interestAmount()
		{
			if (IsInterestPayment)
			{
				return Amount;
			}
			if (Loan == null)
			{
				throw new InvalidOperationException("No loan found.");
			}
			return LoanCalculator.InterestPaymentPart(Amount, loan);
		}

		private decimal principalAmount()
		{
			return Amount - InterestAmount;
		}
	}

}
