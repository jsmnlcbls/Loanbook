using System;
using System.Collections.Generic;
using System.Text;

namespace LoanBook
{
	class DatabaseException : ApplicationException
	{
		public DatabaseException()
			: base()
		{

		}

		public DatabaseException(string message) : base(message)
		{

		}

		public DatabaseException(string message, Exception innerException)
			: base(message, innerException)
		{

		}
	}
}
