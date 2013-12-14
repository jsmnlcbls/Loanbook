using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LoanBook
{
	public class Message
	{
		public static void Error(string message, string caption = "Error")
		{
			MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void Info(string message, string caption = "Information")
		{
			MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static DialogResult Confirm(string message, string caption = "Confirm Action")
		{
			return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
		}
	}
}

