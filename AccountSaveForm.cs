using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoanBook
{
	public partial class AccountSaveForm : Form
	{
		private Account account;

		public delegate void AccountSavedEventHandler();
		public event AccountSavedEventHandler AccountSaved;

		public AccountSaveForm()
		{
			InitializeComponent();
			Text = "New Account";
		}

		public AccountSaveForm(Account account)
		{
			InitializeComponent();
			Text = "Edit Account";
			loadAccount(account);
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			if (account == null)
			{
				account = new Account();
			}
			account.Name = nameInput.Text;
			account.Remarks = remarksInput.Text;
			account.Save(DatabaseFactory.Default);
			if (AccountSaved != null)
			{
				AccountSaved();
			}
			Close();
		}

		private void loadAccount(Account account)
		{
			nameInput.Text = account.Name;
			remarksInput.Text = account.Remarks;
			this.account = account;
		}
	}
}
