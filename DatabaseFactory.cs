using System;
using System.Collections.Generic;
using System.Text;

namespace LoanBook
{
	public class DatabaseFactory
	{
		private static Database defaultDb, sqlite;

		public static Database Default
		{
			get { return defaultDb; }
		}

		public static Database Sqlite
		{
			get { return sqliteDatabase(); }
		}

		public static void SetDefault(Database database)
		{
			defaultDb = database;
		}

		private static Database sqliteDatabase()
		{
			if (sqlite == null)
			{
				string databaseFile = "LoanBook.s3db";
				sqlite = new SqliteDatabase(databaseFile);
			}
			return sqlite;
		}
	}
}
