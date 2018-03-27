using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SinjulMSBH_RazorPages_Webinar.Services
{
	public interface IConnectionFactory
	{
		IDbConnection CreateConnection ( );
	}

	public class SqlConnectionFactory: IConnectionFactory
	{
		private readonly string _connectionString;

		public SqlConnectionFactory ( string connectionString )
		{
			_connectionString = connectionString;
		}

		public IDbConnection CreateConnection ( )
		{
			return new SqlConnection( _connectionString );
		}
	}
}