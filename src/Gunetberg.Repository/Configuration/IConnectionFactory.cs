using System.Data.SqlClient;


namespace Gunetberg.Repository.Configuration
{
    public interface IConnectionFactory
    {
        public SqlConnection GetConnection();
    }
}
