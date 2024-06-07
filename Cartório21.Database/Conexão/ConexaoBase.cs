using System.Data.SqlClient;

namespace Cartório21.Database.Conexão
{
    public class ConexaoBase
    {
        readonly private string _connectionString = "Data Source=Marco\\SQLEXPRESS;Initial Catalog=Cartorio21_Database;Integrated Security=True;Encrypt=False";
        public SqlConnection abrirConexaoBase()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
