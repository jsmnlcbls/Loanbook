using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoanBook
{
	public partial class TransactionsForm : Form
	{
		private Account account;

		private DataGridViewCell lastDirtyCell;

		private bool withChanges = false;

		public bool WithChanges
		{
			get { return withChanges; }
		}

		public TransactionsForm(Account account)
		{
			InitializeComponent();
			this.account = account;
			Text = account.Name + " Transaction History";
		}

		private void TransactionsForm_Load(object sender, EventArgs e)
		{
			transactionsGrid.DataSource = account.Transactions(DatabaseFactory.Default);
			formatDataGrid();
			loadSummary(account.Summary(DatabaseFactory.Default));
			attachEvents();
		}

		private void loadSummary(Dictionary<string, string> summary)
		{
			paymentsMade.Text = summary["Payments"];
			loansMade.Text = summary["Loans"];
			totalLoans.Text = summary["TotalLoans"];
			totalPayments.Text = summary["TotalPayments"];
			balance.Text = summary["Balance"];
		}

		private void formatDataGrid()
		{
			transactionsGrid.Columns["id"].Visible = false;
			
			DataGridViewColumn dateColumn = transactionsGrid.Columns["date"];
			dateColumn.HeaderText = "Date";
			dateColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dateColumn.Width = 70;

			DataGridViewColumn amountColumn = transactionsGrid.Columns["amount"];
			amountColumn.HeaderText = "Amount";
			amountColumn.Width = 70;
			amountColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			amountColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			transactionsGrid.Columns["remarks"].HeaderText = "Remarks";
			transactionsGrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}

		private void attachEvents()
		{
			transactionsGrid.CurrentCellDirtyStateChanged += new EventHandler(transactionsGrid_CurrentCellDirtyStateChanged);
			transactionsGrid.CurrentCellChanged += new EventHandler(transactionsGrid_CurrentCellChanged);
			transactionsGrid.UserAddedRow += new DataGridViewRowEventHandler(transactionsGrid_UserAddedRow);
			transactionsGrid.UserDeletingRow += new DataGridViewRowCancelEventHandler(transactionsGrid_UserDeletingRow);
			transactionsGrid.DataError += new DataGridViewDataErrorEventHandler(transactionsGrid_DataError);
		
		}

		void transactionsGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
			if (result == DialogResult.OK)
			{
				long transactionId;
				if (e.Row.Cells["id"].Value != null &&
					long.TryParse(e.Row.Cells["id"].Value.ToString(), out transactionId))
				{
					Transaction transaction = new Transaction();
					transaction.Id = transactionId;
					transaction.Remove(DatabaseFactory.Default);
				}
			}
			else
			{
				e.Cancel = true;
			}
		}

		void transactionsGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
		{
			transactionsGrid.Rows[transactionsGrid.NewRowIndex - 1].Cells["id"].Value = 0;
		}

		void transactionsGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
		{
			DataGridViewRow deletedRow = e.Row;
			
		}

		void transactionsGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			Message.Error("Invalid input data. Check input and try again.", "Input Error");
			e.Cancel = true;
		}

		void transactionsGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			lastDirtyCell = ((DataGridView)sender).CurrentCell;
		}

		void transactionsGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			if (lastDirtyCell != null)
			{
				saveTransactionToDatabase(lastDirtyCell.OwningRow);
				loadSummary(account.Summary(DatabaseFactory.Default));
				lastDirtyCell = null;
			}
		}

		private bool isTransactionDataComplete(DataGridViewRow row)
		{
			decimal transactionAmount;

			if (row.Cells["amount"].Value == null || 
				!decimal.TryParse(row.Cells["amount"].Value.ToString(), out transactionAmount))
			{
				return false;
			}

			DateTime transactionDateTime;
			if (row.Cells["date"].Value == null ||
				!DateTime.TryParse(row.Cells["date"].Value.ToString(), out transactionDateTime))
			{
				return false;
			}
			return true;
		}

		private void saveTransactionToDatabase(DataGridViewRow dirtyRow)
		{
			Transaction transaction = new Transaction();

			transaction.Account = account;

			long transactionId;
			if (dirtyRow.Cells["id"].Value != null &&
				long.TryParse(dirtyRow.Cells["id"].Value.ToString(), out transactionId))
			{
				transaction.Id = transactionId;
			}

			if (isTransactionDataComplete(dirtyRow))
			{
				transaction.Date = DateTime.Parse(dirtyRow.Cells["date"].Value.ToString());
				transaction.Amount = (decimal)dirtyRow.Cells["amount"].Value;
				transaction.Remarks = dirtyRow.Cells["remarks"].Value.ToString();
				transaction.Save(DatabaseFactory.Default);
				dirtyRow.Cells["id"].Value = transaction.Id;
				withChanges = true;
			}
		}
	}
}
