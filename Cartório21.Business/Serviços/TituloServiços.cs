using Cartório21.Business.Repositórios;
using Cartório21.Business.Serviços.Abstrações;
using System.Linq;
using System.Threading.Tasks;
using Cartório21.Business.Entidades;
using System;
using Cartório21.Database.Operações;
using Cartório21.Database.Conexão;

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

        public async Task ImportaXML(string caminhoArquivoXML)
        {
            Titulos titulosXML = Utils.DesiralizarXML<Titulos>(caminhoArquivoXML);

            if (titulosXML.Items.Any())
            {
                var ocorreuErro = false;
                
                var conexaoBase = ConexaoBase.AbrirConexaoBase();
                
                await conexaoBase.OpenAsync();
                
                using (var transacao = conexaoBase.BeginTransaction())
                {
                    foreach (var item in titulosXML.Items)
                    {
                        try
                        {
                            var itemProtocolo = int.Parse(item.Protocolo);

                            var ret = await _tituloRepositório.ObterPorProtocolo(itemProtocolo, conexaoBase, transacao);

                            if (ret == null)
                            {
                                decimal valorTitulo = decimal.Parse(item.ValorTitulo);

                                Titulo novoTitulo = new Titulo
                                {
                                    Protocolo = itemProtocolo,
                                    NomeDevedor = item.NomeDevedor,
                                    DocumentoDevedor = item.DocumentoDevedor,
                                    NomeApresentante = item.NomeApresentante,
                                    DocumentoApresentante = item.DocumentoApresentante,
                                    NomeCredor = item.NomeCredor,
                                    DocumentoCredor = item.DocumentoCredor,
                                    NumeroTitulo = int.Parse(item.NumeroTitulo),
                                    ValorTitulo = valorTitulo,
                                    DataEmissao = Convert.ToDateTime(item.DataEmissao),
                                    EspecieTitulo = item.EspecieTitulo,
                                    DataApresentacao = DateTime.Now,
                                    ValorCustas = valorTitulo * (decimal)0.10
                                };

                                await _tituloRepositório.Incluir(novoTitulo, conexaoBase, transacao);
                            }
                        }
                        catch (Exception)
                        {
                            ocorreuErro = true;
                        }
                    }

                    if (ocorreuErro)
                        transacao.Rollback();
                    else
                        transacao.Commit();
                }
            }
        }
    }
}
