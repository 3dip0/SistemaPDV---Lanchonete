using MySql.Data.MySqlClient;
using System.Data.SQLite;

namespace SistemaPDV___Lanchonete
{
    public class SQL
    {
        
        public SQLiteConnection GetConnection()
        {
            string conn = "Data Source = lanche";
            return new SQLiteConnection(conn);

        }
    }
}
