using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace LoanBook
{
	public class SqliteDatabase : Database
	{
		private String databaseFile;

		private SQLiteConnection sqliteConnection;

		private SQLiteTransaction transaction;

		public SqliteDatabase(String databaseFile)
		{
			this.databaseFile = databaseFile;
		}

		public long LastInsertId()
		{
			return connection().LastInsertRowId;
		}

		public void BeginTransaction()
		{
			transaction = connection().BeginTransaction();
		}

		public void Commit()
		{
			if (transaction != null)
			{
				transaction.Commit();
			}
		}

		public void Rollback()
		{
			if (transaction != null)
			{
				transaction.Rollback();
			}
		}

		public DataTable Query(String sql, Dictionary<string, object> parameters = null)
		{
			SQLiteCommand command = new SQLiteCommand();
			if (parameters != null)
			{
				prepareParameters(command, parameters);
			}
			
			DataTable result = new DataTable();

			try
			{
				command.CommandText = sql;
				command.Connection = connection();
				using (SQLiteDataReader reader = command.ExecuteReader())
				{
					result.Load(reader);
				}
				return result;
			}
			catch (SQLiteException exception)
			{
				throw new DatabaseException("Unable to read from database", exception);
			}
		}

		public object QueryScalar(string sql, Dictionary<string, object> parameters = null)
		{
			SQLiteCommand command = new SQLiteCommand();
			if (null != parameters)
			{
				prepareParameters(command, parameters);
			}
			try
			{
				command.CommandText = sql;
				command.Connection = connection();
				return command.ExecuteScalar();
			}
			catch (SQLiteException exception)
			{
				throw new DatabaseException("Unable to read from database", exception);
			}
		}

		public int Execute(String sql, Dictionary<string, object> parameters = null)
		{
			SQLiteCommand command = new SQLiteCommand();
			command.CommandText = sql;

			if (null != parameters)
			{
				prepareParameters(command, parameters);
			}
			try
			{
				command.Connection = connection();
				return command.ExecuteNonQuery();
			}
			catch (SQLiteException exception)
			{
				throw new DatabaseException("Unable to execute query", exception);
			}
		}

		private SQLiteConnection connection()
		{
			if (sqliteConnection == null)
			{
				sqliteConnection = new SQLiteConnection("Data Source="+this.databaseFile);
				sqliteConnection.Open();
			}
			return sqliteConnection;
		}

		private void prepareParameters(SQLiteCommand command, Dictionary<string, object> parameters)
		{
			foreach (KeyValuePair<string, object> param in parameters)
			{
				SQLiteParameter dbParam = new SQLiteParameter(param.Key, param.Value);
				command.Parameters.Add(dbParam);
			}
		}
	}
}
