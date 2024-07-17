using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaVendas.Uteis
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "sistema_venda";
        private static string User = "root";
        private static string Password = "710092600";
        private static string connectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password}; Sslmode=none;CharSet=utf8;";
        private static MySqlConnection Connection;

        public DAL()
        {
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        //Espera um parâmetro do tipo string contendo um comando SQL do tipo SELECT
        public DataTable RetDataTable(string sql)
        {
            DataTable data = new DataTable();
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(Command);
            adapter.Fill(data);
            return data;
        }

        //Espera um parâmetro do tipo string contendo um comando SQL do tipo INSERT, UPDATE e DELETE
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }
    }
}
