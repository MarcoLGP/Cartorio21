using System;
using System.Windows.Forms;
using Cartório21.Business.Serviços;

namespace Cartório21
{
    public partial class Form_Principal : Form
    {
        private TituloServiços _tituloServicos;
        public Form_Principal()
        {
            InitializeComponent();
            _tituloServicos = new TituloServiços();
        }

        private async void btnImportaXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Arquivos XML (*.xml)|*.xml"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivoXML = openFileDialog.FileName;
                await _tituloServicos.ImportaXML(caminhoArquivoXML);
            }
        }

        private void btnCriarTitulo_Click(object sender, EventArgs e)
        {
            Form_CriarAlterarTitulo formCriarTitulo = new Form_CriarAlterarTitulo();
            formCriarTitulo.Show();
        }
    }
}
