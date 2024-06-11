using Cartório21.Database;
using Cartório21.Database.Conexão;
using System.Threading.Tasks;

namespace Cartório21.Business.Serviços
{
    public static class BaseDadosServiços
    {
        public static string ObterStringConexaoBaseDados()
        {
            return ConexaoBase.ObterStringConexao();
        }

        public static async Task<bool> DefinirStringConexaoBaseDados(string stringConexao)
        {
            var sucesso = await ConexaoBase.TestarConexaoBase(stringConexao);

            if (sucesso)
            {
                ConexaoBase.SalvarStringConexao(stringConexao);
            }

            return sucesso;
        }

        public static async Task<bool> TestarConexao()
        {
            var sucesso = await ConexaoBase.TestarConexaoBase(ObterStringConexaoBaseDados());
            return sucesso;
        }
    }
}
