using Cartório21.Business.Entidades;
using Cartório21.Business.Serviços;
using System;
using System.Windows.Forms;

namespace Cartório21
{
    public partial class Form_Titulo : Form
    {
        private Titulo _tituloAlterar;
        private TituloServiços _tituloServiços = new TituloServiços();
        public Form_Titulo(Titulo tituloAlterar = null)
        {
            InitializeComponent();
            _tituloAlterar = tituloAlterar;
        }

        private void Form_CriarAlterarTitulo_Load(object sender, EventArgs e)
        {
            if (_tituloAlterar != null)
            {
                Text = "Alterar título - " + _tituloAlterar.Protocolo.ToString();
                btnSalvar.Text = "Alterar título";

                txtProtocolo.Text = _tituloAlterar.Protocolo.ToString();
                txtNumeroTitulo.Text = _tituloAlterar.NumeroTitulo.ToString();
                txtValorTitulo.Text = _tituloAlterar.ValorTitulo.ToString();
                cbxEspecieTitulo.Text = _tituloAlterar.EspecieTitulo;
                dtpDataEmissao.Value = _tituloAlterar.DataEmissao;
                txtNomeDevedor.Text = _tituloAlterar.NomeDevedor;
                txtDocumentoDevedor.Text = _tituloAlterar.DocumentoDevedor;
                txtNomeCredor.Text = _tituloAlterar.NomeCredor;
                txtDocumentoCredor.Text = _tituloAlterar.DocumentoCredor;
                txtNomeApresentante.Text = _tituloAlterar.NomeApresentante;
                txtDocumentoApresentante.Text = _tituloAlterar.DocumentoApresentante;
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var valorTitulo = decimal.Parse(txtValorTitulo.Text);

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
                ValorCustas = valorTitulo * (decimal)0.10
            };

            if (_tituloAlterar != null)
            {
                await _tituloServiços.AtualizarTitulo(tituloCampos, _tituloAlterar.Protocolo);
            }
            else
            {
                tituloCampos.DataApresentacao = DateTime.Now;
                await _tituloServiços.IncluirTitulo(tituloCampos);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
