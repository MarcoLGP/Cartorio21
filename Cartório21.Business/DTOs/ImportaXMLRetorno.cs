using Cartório21.Business.Entidades;
using System.Collections.Generic;

namespace Cartório21.Business.DTOs
{
    public class ImportaXMLretornoImportaXML
    {
        public List<Titulo> TitulosJaCadastrados { get; set; } = new List<Titulo>();
        public string erro { get; set; } = string.Empty;
    }
}
