using Microsoft.Data.SqlClient;

namespace Student.Data.Layer
{
    public interface IConnectivity
    {
        SqlConnection GetConnection();
    }
    public class DbConnection : IConnectivity
    {
        private string _connectionString;

        public DbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection( _connectionString );
        }
    }
}
