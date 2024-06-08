using Cartório21.Business.Entidades;
using Cartório21.Business.Repositórios.Abstrações;
using Cartório21.Database.Operações;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cartório21.Business.Repositórios
{
    public class TituloRepositório : ITituloRepositório
    {
        private OperaçõesBase _operaçõesBase;

        public TituloRepositório()
        {
            _operaçõesBase = new OperaçõesBase();
        }

        public async Task Incluir(Titulo titulo, SqlConnection conexao = null, DbTransaction transacao = null)
        {
            const string query = @"
                   INSERT INTO Titulos (
                        Protocolo, 
                        NomeDevedor, 
                        DocumentoDevedor, 
                        NomeApresentante, 
                        DocumentoApresentante, 
                        NomeCredor, 
                        DocumentoCredor, 
                        NumeroTitulo, 
                        ValorTitulo,
                        DataEmissao,
                        EspecieTitulo,
                        DataApresentacao,
                        ValorCustas
)
                    VALUES (
                        @Protocolo,
                        @NomeDevedor, 
                        @DocumentoDevedor, 
                        @NomeApresentante, 
                        @DocumentoApresentante, 
                        @NomeCredor, 
                        @DocumentoCredor, 
                        @NumeroTitulo, 
                        @ValorTitulo,
                        @DataEmissao,
                        @EspecieTitulo,
                        @DataApresentacao,
                        @ValorCustas)";

            await _operaçõesBase.ExecutaComandoBaseSemRetorno(query, titulo, conexao, transacao);
        }

        public async Task Excluir(int protocolo, SqlConnection conexao = null, DbTransaction transacao = null)
        { 
            const string query = @"
                  DELETE FROM TITULOS
                  WHERE Protocolo = @Protocolo";

            await _operaçõesBase.ExecutaComandoBaseSemRetorno(query, 
                new { Protocolo = protocolo }, 
                conexao, 
                transacao);
        }

        public async Task Atualizar(Titulo tituloAtualizado, int protocoloTituloAntigo, SqlConnection conexao = null, DbTransaction transacao = null)
        {
            const string query = @"
                  UPDATE Titulos
                  SET Protocolo = @Protocolo,
                      NomeDevedor = @NomeDevedor, 
                      DocumentoDevedor = @DocumentoDevedor, 
                      NomeApresentante = @NomeApresentante, 
                      DocumentoApresentante = @DocumentoApresentante, 
                      NomeCredor = @NomeCredor, 
                      DocumentoCredor = @DocumentoCredor, 
                      NumeroTitulo = @NumeroTitulo, 
                      ValorTitulo = @ValorTitulo,
                      DataEmissao = @DataEmissao,
                      EspecieTitulo = @EspecieTitulo,
                      DataApresentacao = @DataApresentacao,
                      ValorCustas = @ValorCustas
                  WHERE Protocolo = @ProtocoloTituloAntigo";

            await _operaçõesBase.ExecutaComandoBaseSemRetorno(query, 
                Utils.MesclarObjetos<dynamic>(tituloAtualizado, new { ProtocoloTituloAntigo = protocoloTituloAntigo }),
                conexao,
                transacao
            );
        }

        public async Task<IEnumerable<Titulo>> ObterTodos(SqlConnection conexao = null, DbTransaction transacao = null)
        {
            const string query = "SELECT * FROM TITULOS";
            return await _operaçõesBase.ExecutaComandoBaseComRetorno<Titulo>(query, conexao: conexao, transaction: transacao);
        }

        public async Task<Titulo> ObterPorProtocolo(int protocolo, SqlConnection conexao = null, DbTransaction transacao = null)
        {
            const string query = "SELECT * FROM TITULOS WHERE Protocolo = @Protocolo";
            var ret = await _operaçõesBase.ExecutaComandoBaseComRetorno<Titulo>(query, 
                new { Protocolo = protocolo },
                conexao,
                transacao);

            if (ret.Any())
                return ret.First();

            return null;
        }
    }
}
