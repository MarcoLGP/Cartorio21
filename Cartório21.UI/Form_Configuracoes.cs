using System;
using System.Windows.Forms;
using Cartório21.Business.Serviços;

namespace Cartório21
{
    public partial class Form_Configuracoes : Form
    {
        public Form_Configuracoes()
        {
            InitializeComponent();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtConexaoBancoDados.Text == string.Empty)
            {
                Utils.ExibirMensagemErro("Digite um caminho de conexão para o banco de dados");
                return;
            }

            var sucesso = await BaseDadosServiços.DefinirStringConexaoBaseDados(txtConexaoBancoDados.Text);

            if (sucesso)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Utils.ExibirMensagemErro("Não foi possível se comunicar com a base pelo caminho especificado");
            }
        }
    }
}
