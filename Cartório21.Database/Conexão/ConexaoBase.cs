using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cartório21.Database.Conexão
{
    public static class ConexaoBase
    {
        public static SqlConnection AbrirConexaoBase()
        {
           return new SqlConnection(ObterStringConexao());
        }
        public static string ObterStringConexao()
        {
            return Properties.Settings.Default.ConexaoBanco;
        }
        public static void SalvarStringConexao(string stringConexao)
        {
            Properties.Settings.Default.ConexaoBanco = stringConexao;
            Properties.Settings.Default.Save();
        }
        public static async Task<bool> TestarConexaoBase(string stringConexao)
        {
            try
            {
                using (var connection = new SqlConnection(stringConexao))
                {
                    await connection.OpenAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
