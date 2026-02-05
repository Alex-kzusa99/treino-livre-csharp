using System.Data.SqlClient;

namespace EX001.Conection
{
    public class Connection
    {
        private const string StringConexao = @"Server=KZUSA99;Database=master;Trusted_Connection=True;";

        public Connection()
        {
        }

        public Sqlco CriarConexao()
        {
            using (SqlConnection conn = new SqlConnection(StringConexao))
            {
                conn.Open();
                return conn;
            }
        }
    }
}





