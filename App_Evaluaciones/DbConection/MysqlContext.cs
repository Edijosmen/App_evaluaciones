using MySqlConnector;

namespace App_Evaluaciones.DbConection
{
    public class MysqlContext
    {
        private readonly string _connectionString;

        public MysqlContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbContextMysql");
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                var connection = new MySqlConnection(_connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
