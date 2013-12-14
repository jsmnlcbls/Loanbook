using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LoanBook
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
			setDefaultDatabaseFile();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			databaseFileDialog.ShowDialog();
		}

		private void setDefaultDatabaseFile()
		{
			if (String.IsNullOrEmpty(Settings.Default.DatabaseFile))
			{
				String directory = System.Environment.CurrentDirectory;
				String defaultFile = Settings.Default.DefaultDatabaseFile;
				String file = directory + Path.DirectorySeparatorChar + defaultFile;
				this.databaseFileInput.Text = file;
			}
			else
			{
				this.databaseFileInput.Text = Settings.Default.DatabaseFile;
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			Settings.Default.DatabaseFile = this.databaseFileInput.Text;
			Settings.Default.Save();
			Close();
		}
	}
}
