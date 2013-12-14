using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace LoanBook
{
	public partial class AccountListForm : Form
	{
		private Account currentAccount;

		public AccountListForm()
		{
			InitializeComponent();
		}

		private void AccountListForm_Load(object sender, EventArgs e)
		{
			loadData();
			formatDataGrid();
			accountListGrid.CellEnter += new DataGridViewCellEventHandler(accountListGrid_CellEnter);
		}

		void accountListGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			accountListGrid.Rows[e.RowIndex].Selected = true;
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			Account account = new Account();
			account.Id = (long)accountListGrid.CurrentRow.Cells["id"].Value;
			account.Load(DatabaseFactory.Default);
			currentAccount = account;
			Form accountSaveForm = new AccountSaveForm(account);
			accountSaveForm.FormClosing += new FormClosingEventHandler(accountSaveForm_FormClosing);
			accountSaveForm.ShowDialog();
		}

		void accountSaveForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			accountListGrid.CurrentRow.Cells["name"].Value = currentAccount.Name;
		}

		private void transactionButton_Click(object sender, EventArgs e)
		{
			Account account = new Account();
			account.Id = (long)accountListGrid.CurrentRow.Cells["id"].Value;
			account.Load(DatabaseFactory.Default);

			Form transactionsForm = new TransactionsForm(account);
			transactionsForm.MdiParent = MdiParent;
			transactionsForm.Show();
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			int rowIndex = accountListGrid.CurrentRow.Index;
			int scrollIndex = accountListGrid.FirstDisplayedScrollingRowIndex;
			loadData();
			accountListGrid.Rows[rowIndex].Selected = true;
			accountListGrid.FirstDisplayedScrollingRowIndex = scrollIndex;
		}

		private void loadData()
		{
			AccountList accountList = new AccountList(DatabaseFactory.Default);
			accountListGrid.DataSource = accountList.Summary();	
		}

		private void formatDataGrid()
		{
			accountListGrid.ReadOnly = true;
			accountListGrid.MultiSelect = false;
			accountListGrid.Columns["id"].Visible = false;
			
			DataGridViewColumn nameColumn = accountListGrid.Columns["name"];
			nameColumn.HeaderText = "Account Name";
			nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			nameColumn.MinimumWidth = 200;

			DataGridViewColumn balanceColumn = accountListGrid.Columns["balance"];
			balanceColumn.HeaderText = "Balance";
			balanceColumn.Width = 60;
			balanceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			balanceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		}

	}
}
