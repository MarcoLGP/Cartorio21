using System;

namespace Cartório21.Business.Entidades
{
    public class Titulo
    {
        public int Protocolo { get; set; }
        public string NomeDevedor { get; set; }
        public string DocumentoDevedor { get; set; }
        public string NomeApresentante { get; set; }
        public string DocumentoApresentante { get; set; }
        public string NomeCredor { get; set; }
        public string DocumentoCredor { get; set; }
        public int NumeroTitulo { get; set; }
        public decimal ValorTitulo { get; set; }
        public DateTime DataEmissao { get; set; }
        public string EspecieTitulo { get; set; }
        public DateTime DataApresentacao { get; set; }
        public decimal ValorCustas { get; set; }
    }
}
