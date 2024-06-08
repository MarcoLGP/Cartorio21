using System.Data.SqlClient;

namespace Cartório21.Database.Conexão
{
    public static class ConexaoBase
    {
        readonly private static string _connectionString = "Data Source=Marco\\SQLEXPRESS;Initial Catalog=Cartorio21_Database;Integrated Security=True;Encrypt=False";
        public static SqlConnection AbrirConexaoBase()
        {
           return new SqlConnection(_connectionString);
        }
    }
}
