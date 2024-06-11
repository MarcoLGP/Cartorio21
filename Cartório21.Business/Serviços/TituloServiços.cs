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
using Cartório21.Business.Validadores;
using Cartório21.Business.Enums;

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

        public async Task<ImportaXMLretornoImportaXML> ImportaXML(string caminhoArquivoXML)
        {
            ImportaXMLretornoImportaXML retornoImportaXML = new ImportaXMLretornoImportaXML();
            Titulos titulosXML;

            try
            {
                titulosXML = Utils.DesiralizarXML<Titulos>(caminhoArquivoXML);
            }
            catch (Exception ex)
            {
                retornoImportaXML.erro = ex.Message;
                return retornoImportaXML;
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

                            decimal valorTitulo = decimal.Parse(itemTituloXML.ValorTitulo.Replace(".", ","));

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
                                ValorCustas = Math.Round(valorTitulo * (decimal)0.10, 2)
                            };


                            if (ret == null)
                            {
                                var validador = new ValidadorTitulo(novoTitulo, OperacaoTitulo.Criar);

                                var errosValidador = await validador.Validar();

                                if (errosValidador.Count > 0)
                                {
                                    retornoImportaXML.erro = $"Dados do protocolo [{itemProtocolo}] inválidos:\n\n";
                                    retornoImportaXML.erro += string.Join("\n", errosValidador.Select(s => $"[{s}]"));
                                    break;
                                }

                                await _tituloRepositório.Incluir(novoTitulo, conexaoBase, transacao);
                            }
                            else
                            {
                                var validador = new ValidadorTitulo(novoTitulo, OperacaoTitulo.Alterar);

                                var errosValidador = await validador.Validar();

                                if (errosValidador.Count > 0)
                                {
                                    retornoImportaXML.erro = $"Dados do protocolo [{itemProtocolo}] inválidos:\n\n";
                                    retornoImportaXML.erro += string.Join("\n", errosValidador.Select(s => $"[{s}]"));
                                    break;
                                }

                                retornoImportaXML.TitulosJaCadastrados.Add(novoTitulo);
                            }
                        }
                        catch (Exception ex)
                        {
                            retornoImportaXML.erro = $"Erro ao tentar inserir título de protocolo [{itemTituloXML.Protocolo}]\n[{ex.Message}]";
                            break;
                        }
                    }

                    if (retornoImportaXML.erro != string.Empty)
                    {
                        transacao.Rollback();
                        retornoImportaXML.TitulosJaCadastrados = null;
                    }
                    else
                        transacao.Commit();
                }
            }

            return retornoImportaXML;
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
