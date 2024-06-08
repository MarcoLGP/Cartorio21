using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cartório21.Database.Operações
{
    public interface IOperaçõesBase
    {
        Task ExecutaComandoBaseSemRetorno(string sql, object param = null, SqlConnection conexao = null, IDbTransaction transaction = null);
        Task<IEnumerable<T>> ExecutaComandoBaseComRetorno<T>(string sql, object param = null, SqlConnection conexao = null, IDbTransaction transaction = null);
    }
}
