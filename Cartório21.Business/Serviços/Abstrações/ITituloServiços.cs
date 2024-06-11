using Cartório21.Business.DTOs;
using Cartório21.Business.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cartório21.Business.Serviços.Abstrações
{
    public interface ITituloServiços
    {
        Task<ImportaXMLretornoImportaXML> ImportaXML(string caminhoArquivoXML);
        Task<IEnumerable<Titulo>> ObterTodosOsTitulos();
        Task DeletarTitulo(int protocoloTitulo);
        Task AtualizarTitulo(Titulo titulo, int protocoloTituloAlterar);
        Task IncluirTitulo(Titulo titulo);
    }
}
