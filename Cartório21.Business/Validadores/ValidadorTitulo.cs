using Cartório21.Business.Entidades;
using Cartório21.Business.Repositórios;
using Cartório21.Business.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cartório21.Business.Validadores.Abstrações;

namespace Cartório21.Business.Validadores
{
    public class ValidadorTitulo : IValidadorTitulo
    {
        private Titulo _titulo;
        private List<string> Erros = new List<string>();
        private TituloRepositório _tituloRepositório;
        private OperacaoTitulo _operacaoTitulo;
        public ValidadorTitulo(Titulo titulo, OperacaoTitulo operacaoTitulo) 
        {
            _titulo = titulo;
            _tituloRepositório = new TituloRepositório();
            _operacaoTitulo = operacaoTitulo;
        }

        public async Task<List<string>> Validar()
        {
            await ValidarProtocolo();
            ValidarNomeDevedor();
            ValidarDocumentoDevedor();
            ValidarNomeApresentante();
            ValidarDocumentoApresentante();
            ValidarNomeCredor();
            ValidarDocumentoCredor();
            ValidarNumeroTitulo();
            ValidarValorTitulo();
            ValidarDataEmissao();
            ValidarEspecieTitulo();
            ValidarValorCustas();

            return Erros;
        }

        private async Task ValidarProtocolo()
        {
            if (!int.TryParse(_titulo.Protocolo.ToString(), out int protocolo))
            {
                Erros.Add("Protocolo inválido");
                return;
            }

            var ret = await _tituloRepositório.ObterPorProtocolo(protocolo);

            if (_operacaoTitulo == OperacaoTitulo.Criar && ret != null)
            {
                Erros.Add("Protocolo já cadastrado");
            }
            else if (_operacaoTitulo != OperacaoTitulo.Criar && ret == null)
            {
                Erros.Add("Protocolo não cadastrado");
            }
        }

        private void ValidarNomeDevedor()
        {
            ValidarNome(_titulo.NomeDevedor, 10, 100, "Nome devedor");
        }

        private void ValidarDocumentoDevedor()
        {
            ValidarDocumento(_titulo.DocumentoDevedor.ToString(), "Documento devedor");
        }

        private void ValidarNomeApresentante()
        {
            ValidarNome(_titulo.NomeApresentante, 10, 100, "Nome apresentante");
        }

        private void ValidarDocumentoApresentante()
        {
            ValidarDocumento(_titulo.DocumentoApresentante.ToString(), "Documento apresentante");
        }

        private void ValidarNomeCredor()
        {
            ValidarNome(_titulo.NomeCredor, 10, 100, "Nome credor");
        }

        private void ValidarDocumentoCredor()
        {
            ValidarDocumento(_titulo.DocumentoCredor.ToString(), "Documento Credor");
        }

        private void ValidarNumeroTitulo()
        {
            if (!int.TryParse(_titulo.NumeroTitulo.ToString(), out _))
                Erros.Add("Número título inválido");
        }

        private void ValidarValorTitulo()
        {
            ValidarValores(_titulo.ValorTitulo.ToString(), "Valor titulo");
        }

        private void ValidarDataEmissao()
        {
            bool valido = DateTime.TryParse(_titulo.DataEmissao.ToString(), out _);

            if (!valido)
                Erros.Add("Data emissao inválida");
        }

        private void ValidarEspecieTitulo()
        {
            string[] especiesValidas = new string[] { "cheque", "duplicata", "nota promissória", "boleto" };

            if (!especiesValidas.Contains(_titulo.EspecieTitulo.ToLower()))
                Erros.Add("Espécie titulo inválido");
        }

        private void ValidarValorCustas()
        {
            bool valido = ValidarValores(_titulo.ValorCustas.ToString(), "Valor custas");

            if (valido)
            {
                decimal valorCustasCorreto = Math.Round(_titulo.ValorTitulo * (decimal)0.10, 2);

                if (valorCustasCorreto != _titulo.ValorCustas)
                    Erros.Add("Valor custas deve ser 10% do valor do título\nCorreto: " + valorCustasCorreto + "\n" + "Errado: " + _titulo.ValorCustas);
            }
            else
            {
                Erros.Add("Valor custas inválido");
            }
        }

        private bool ValidarValores(string valor, string nomeCampo)
        {
            bool valido = decimal.TryParse(valor, NumberStyles.Number, CultureInfo.CurrentCulture, out _);

            if (!valido)
            {
                var cultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name)
                {
                    NumberFormat = { NumberDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == "," ? "." : "," }
                };

                bool isValid2 = decimal.TryParse(valor, NumberStyles.Number, cultureInfo, out _);

                if (!isValid2)
                {
                    Erros.Add($"{nomeCampo} inválido");
                    return false;
                }
            }

            return true;
        }

        private void ValidarDocumento(string documento, string nomeCampo)
        {
            string documentoNumeros = Regex.Replace(documento, @"[^\d]", "");

            if (documentoNumeros.Length != 11 && documentoNumeros.Length != 14)
            {
                Erros.Add($"{nomeCampo} inválido");
            }
        }

        private void ValidarNome(string nome, int min, int max, string nomeCampo)
        {
            if (nome.Length < min || nome.Length > max)
            {
                Erros.Add($"{nomeCampo} deve ter entre {min} e {max} caracteres");
            }
        }
    }
}
