using System;

public class Connection
{
    private const string StringConexao = @"Server=KZUSA99;Database=master;Trusted_Connection=True;";

    public Connection()
    {
    }



    public SqlConnection CriarConexao()
    {
        using (SqlConnection conn = new SqlConnection(StringConexao))
        {
            conn.Open();
            return conn;
        }
    }

}


