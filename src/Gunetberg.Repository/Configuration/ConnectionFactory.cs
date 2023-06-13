using System.Data.SqlClient;


namespace Gunetberg.Repository.Configuration
{
    public class ConnectionFactory: IConnectionFactory
    {
        private readonly string _databaseConnectionString;


        public ConnectionFactory(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_databaseConnectionString);
        }
    }
}
