using Cartório21.Business.Entidades;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cartório21.Business.Repositórios.Abstrações
{
    public interface ITituloRepositório
    {
        Task Incluir(Titulo titulo, SqlConnection conexao = null, DbTransaction transacao = null);
        Task Excluir(int protocolo, SqlConnection conexao = null, DbTransaction transacao = null);
        Task Atualizar(Titulo tituloAtualizado, int protocoloTituloAlterar, SqlConnection conexao = null, DbTransaction transacao = null);
        Task<IEnumerable<Titulo>> ObterTodos(SqlConnection conexao = null, DbTransaction transacao = null);
        Task<Titulo> ObterPorProtocolo(int protocolo, SqlConnection conexao = null, DbTransaction transacao = null);
    }
}
