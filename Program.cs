using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoanBook
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			DatabaseFactory.SetDefault(DatabaseFactory.Sqlite);
			Application.Run(new LoanBookForm());
		}
	}
}
