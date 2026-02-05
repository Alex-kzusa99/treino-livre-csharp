using System.Data.SqlClient;

namespace EX009.Conection
{
    public class Connection
    {
        private const string StringConexao = @"Server=KZUSA99;Database=master;Trusted_Connection=True;";
        public Connection()
        {
        }

        public System.Data.SqlClient.SqlConnection CriarConexao()
        {
            using (SqlConnection conn = new SqlConnection(StringConexao))
            {
                return conn;
            }
        }
    }
}





