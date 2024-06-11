using Cartório21.Business.Entidades;
using Cartório21.Business.Serviços;
using Cartório21.Business.Validadores;
using Cartório21.Business.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartório21
{
    public partial class Form_Titulo : Form
    {
        private Titulo _tituloCarregado;
        private TituloServiços _tituloServiços;
        private OperacaoTitulo _operacaoFormTitulo;
        public Form_Titulo(
            Titulo tituloCarregado = null, 
            OperacaoTitulo operacaoFormTitulo = OperacaoTitulo.Criar)
        {
            InitializeComponent();
            _tituloServiços = new TituloServiços();
            _tituloCarregado = tituloCarregado;
            _operacaoFormTitulo = operacaoFormTitulo;
        }

        private void Form_CriarAlterarTitulo_Load(object sender, EventArgs e)
        {
            if (_tituloCarregado != null)
            {
                txtProtocolo.Text = _tituloCarregado.Protocolo.ToString();
                txtNumeroTitulo.Text = _tituloCarregado.NumeroTitulo.ToString();
                txtValorTitulo.Text = _tituloCarregado.ValorTitulo.ToString();
                cbxEspecieTitulo.Text = _tituloCarregado.EspecieTitulo;
                dtpDataEmissao.Value = _tituloCarregado.DataEmissao;
                txtNomeDevedor.Text = _tituloCarregado.NomeDevedor;
                txtDocumentoDevedor.Text = _tituloCarregado.DocumentoDevedor;
                txtNomeCredor.Text = _tituloCarregado.NomeCredor;
                txtDocumentoCredor.Text = _tituloCarregado.DocumentoCredor;
                txtNomeApresentante.Text = _tituloCarregado.NomeApresentante;
                txtDocumentoApresentante.Text = _tituloCarregado.DocumentoApresentante;
            }

            if (_operacaoFormTitulo == OperacaoTitulo.Alterar)
            {
                Text = "Alterar título - " + _tituloCarregado.Protocolo.ToString();
                btnSalvar.Text = "Alterar título";
                txtProtocolo.ReadOnly = true;
            }
            else if (_operacaoFormTitulo == OperacaoTitulo.Detalhe)
            {
                Text = "Detalhe título - " + _tituloCarregado.Protocolo.ToString();
                btnSalvar.Visible = false;

                foreach (TabPage tabPage in tabControlTitulo.TabPages)
                {
                    foreach (Control control in tabPage.Controls)
                    {
                        if (control is TextBox)
                        {
                            ((TextBox)control).ReadOnly = true;
                        }
                        else if (control is ComboBox)
                        {
                            ((ComboBox)control).Enabled = false;
                        }
                        else if (control is DateTimePicker)
                        { 
                            ((DateTimePicker)control).Enabled = false;
                        }
                    }
                }
            }

            if (_operacaoFormTitulo != OperacaoTitulo.Detalhe)
            {
                txtProtocolo.KeyPress += ValidacaoCamposNumericos;
                txtNumeroTitulo.KeyPress += ValidacaoCamposNumericos;
                txtValorTitulo.KeyPress += ValidacaoCampoValor;
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            decimal valorTitulo;
            decimal valorCustas;
            try
            {
                valorTitulo = decimal.Parse(txtValorTitulo.Text.Replace(".", ","));
                valorCustas = decimal.Parse(txtValorCustas.Text.Replace(".", ","));
            }
            catch (Exception)
            {
                Utils.ExibirMensagemErro("Verifique o valor digitado no valor do titulo", "Dados inválidos");
                return;
            }


            Titulo tituloCampos = new Titulo
            {
                Protocolo = int.Parse(txtProtocolo.Text),
                NumeroTitulo = int.Parse(txtNumeroTitulo.Text),
                ValorTitulo = valorTitulo,
                EspecieTitulo = cbxEspecieTitulo.Text,
                DataEmissao = dtpDataEmissao.Value,
                NomeDevedor = txtNomeDevedor.Text,
                DocumentoDevedor = txtDocumentoDevedor.Text,
                NomeCredor = txtNomeCredor.Text,
                DocumentoCredor = txtDocumentoCredor.Text,
                NomeApresentante = txtNomeApresentante.Text,
                DocumentoApresentante = txtDocumentoApresentante.Text,
                ValorCustas = valorCustas
            };

            if (_tituloCarregado != null && _operacaoFormTitulo == OperacaoTitulo.Alterar)
            {
                if (await ValidarCampos(tituloCampos))
                {
                    await _tituloServiços.AtualizarTitulo(tituloCampos, _tituloCarregado.Protocolo);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else if (_operacaoFormTitulo == OperacaoTitulo.Criar)
            {
                tituloCampos.DataApresentacao = DateTime.Now;

                if (await ValidarCampos(tituloCampos))
                {
                    await _tituloServiços.IncluirTitulo(tituloCampos);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private async Task<bool> ValidarCampos(Titulo campos)
        {
            var errosValidadorTitulo = await new ValidadorTitulo(campos, _operacaoFormTitulo).Validar();

            if (errosValidadorTitulo.Count > 0)
            {
                var mensagemErro = string.Join("\n", errosValidadorTitulo.Select(s => $"[{s}]"));
                Utils.ExibirMensagemErro(mensagemErro, "Não foi possível criar o título, verifique os campos a seguir");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ValidacaoCamposNumericos(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ValidacaoCampoValor(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtValorTitulo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValorTitulo.Text.Length > 0)
                    txtValorCustas.Text = Math.Round((decimal.Parse(txtValorTitulo.Text) * (decimal)0.10), 2).ToString();
            }
            catch (Exception)
            {
                txtValorCustas.Text = "";
            }
        }
    }
}
