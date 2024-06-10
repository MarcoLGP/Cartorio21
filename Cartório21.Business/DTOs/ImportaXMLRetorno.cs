using Cartório21.Business.Entidades;
using System.Collections.Generic;

namespace Cartório21.Business.DTOs
{
    public class ImportaXMLRetorno
    {
        public List<Titulo> TitulosJaCadastrados { get; set; }
        public string erro { get; set; }
    }
}
