using MySql.Data.MySqlClient;

namespace Shop.Data.Common
{
    public class Connection
    {
        private readonly static string _connectionData =
            @"server=127.0.0.1;
              database=shop
              uid=root
              pwd=1234";
        public static MySqlConnection CreateConnection()
        {
            MySqlConnection connection = new MySqlConnection(_connectionData);
            connection.Open();
            return connection;
        }
        public static MySqlDataReader Query(string sql, MySqlConnection connection)
        {
            return new MySqlCommand(sql, connection).ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
