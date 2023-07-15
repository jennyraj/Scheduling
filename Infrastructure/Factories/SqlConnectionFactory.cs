using System.Data.SqlClient;

namespace Scheduling.Infrastructure.Factories
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public SqlConnection SqlConnection()
        {
            return new SqlConnection(this._connectionString);
        }
    }
}