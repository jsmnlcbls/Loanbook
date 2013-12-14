using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LoanBook
{
	public interface Database
	{
		long LastInsertId();

		void BeginTransaction();

		void Commit();

		void Rollback();

		DataTable Query(String sql, Dictionary<string, object> parameters = null);

		Object QueryScalar(String sql, Dictionary<string, object> parameters = null);

		int Execute(String sql, Dictionary<string, object> parameters = null);
	}
}
