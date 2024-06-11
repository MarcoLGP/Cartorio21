using Cartório21.Database.Conexão;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cartório21.Database.Operações
{
    public class OperaçõesBase : IOperaçõesBase
    {
        public async Task ExecutaComandoBaseSemRetorno(string sql, object param = null, SqlConnection conexao = null, IDbTransaction transaction = null)
        {
            if (conexao == null)
            {
                using (conexao = ConexaoBase.AbrirConexaoBase())
                {
                    await conexao.ExecuteAsync(sql, param, transaction);
                }
            }
            else 
                await conexao.ExecuteAsync(sql, param, transaction);
        }
        public async Task<IEnumerable<T>> ExecutaComandoBaseComRetorno<T>(string sql, object param = null, SqlConnection conexao = null, IDbTransaction transaction = null)
        {
            if (conexao == null)
            {
                using (conexao = ConexaoBase.AbrirConexaoBase())
                {
                    await conexao.OpenAsync();
                    return await conexao.QueryAsync<T>(sql, param, transaction);
                }
            }

            return await conexao.QueryAsync<T>(sql, param, transaction);
        }
    }
}
