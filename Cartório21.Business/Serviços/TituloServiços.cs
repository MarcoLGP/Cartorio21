using Cartório21.Business.Repositórios;
using Cartório21.Business.Serviços.Abstrações;
using System.Linq;
using System.Threading.Tasks;
using Cartório21.Business.Entidades;
using System;
using Cartório21.Database.Operações;
using Cartório21.Database.Conexão;
using System.Collections.Generic;
using Cartório21.Business.DTOs;

namespace Cartório21.Business.Serviços
{
    public class TituloServiços : ITituloServiços
    {
        private TituloRepositório _tituloRepositório;
        private OperaçõesBase _operaçõesBase;

        public TituloServiços()
        {
            _tituloRepositório = new TituloRepositório();
            _operaçõesBase = new OperaçõesBase();
        }

        public async Task<ImportaXMLRetorno> ImportaXML(string caminhoArquivoXML)
        {
            ImportaXMLRetorno retorno = new ImportaXMLRetorno();
            Titulos titulosXML;

            try
            {
                titulosXML = Utils.DesiralizarXML<Titulos>(caminhoArquivoXML);
            }
            catch (Exception ex)
            {
                retorno.erro = ex.Message;
                return retorno;
            }

            if (titulosXML.Items.Any())
            {
                var conexaoBase = ConexaoBase.AbrirConexaoBase();
                
                await conexaoBase.OpenAsync();
                
                using (var transacao = conexaoBase.BeginTransaction())
                {
                    foreach (var itemTituloXML in titulosXML.Items)
                    {
                        try
                        {
                            var itemProtocolo = int.Parse(itemTituloXML.Protocolo);

                            var ret = await _tituloRepositório.ObterPorProtocolo(itemProtocolo, conexaoBase, transacao);

                            decimal valorTitulo = decimal.Parse(itemTituloXML.ValorTitulo);

                            Titulo novoTitulo = new Titulo
                            {
                                Protocolo = itemProtocolo,
                                NomeDevedor = itemTituloXML.NomeDevedor,
                                DocumentoDevedor = itemTituloXML.DocumentoDevedor,
                                NomeApresentante = itemTituloXML.NomeApresentante,
                                DocumentoApresentante = itemTituloXML.DocumentoApresentante,
                                NomeCredor = itemTituloXML.NomeCredor,
                                DocumentoCredor = itemTituloXML.DocumentoCredor,
                                NumeroTitulo = int.Parse(itemTituloXML.NumeroTitulo),
                                ValorTitulo = valorTitulo,
                                DataEmissao = Convert.ToDateTime(itemTituloXML.DataEmissao),
                                EspecieTitulo = itemTituloXML.EspecieTitulo,
                                DataApresentacao = DateTime.Now,
                                ValorCustas = valorTitulo * (decimal)0.10
                            };

                            if (ret == null)
                            {
                                await _tituloRepositório.Incluir(novoTitulo, conexaoBase, transacao);
                            }
                            else
                            {
                                retorno.TitulosJaCadastrados.Add(novoTitulo);
                            }
                        }
                        catch (Exception ex)
                        {
                            retorno.erro = ex.Message;
                            break;
                        }
                    }

                    if (retorno.erro != string.Empty)
                    {
                        transacao.Rollback();
                        retorno.TitulosJaCadastrados = null;
                    }
                    else
                        transacao.Commit();
                }
            }

            return retorno;
        }
        public async Task<IEnumerable<Titulo>> ObterTodosOsTitulos()
        {
           return await _tituloRepositório.ObterTodos();
        }

        public async Task DeletarTitulo(int protocoloTitulo)
        { 
            await _tituloRepositório.Excluir(protocoloTitulo);
        }

        public async Task AtualizarTitulo(Titulo titulo, int protocoloTituloAlterar)
        {
            await _tituloRepositório.Atualizar(titulo, protocoloTituloAlterar);
        }

        public async Task IncluirTitulo(Titulo titulo)
        {
            await _tituloRepositório.Incluir(titulo);
        }
    }
}
