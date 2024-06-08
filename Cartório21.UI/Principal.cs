using System;
using System.Windows.Forms;
using Cartório21.Business.Serviços;

namespace Cartório21
{
    public partial class Principal : Form
    {
        private TituloServiços _tituloServicos;
        public Principal()
        {
            InitializeComponent();
            _tituloServicos = new TituloServiços();
        }

        private async void btnImportaXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Define o filtro para arquivos XML
            openFileDialog.Filter = "Arquivos XML (*.xml)|*.xml";

            // Abre a janela do OpenFileDialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtém o caminho do arquivo selecionado
                string caminhoArquivoXML = openFileDialog.FileName;
                await _tituloServicos.ImportaXML(caminhoArquivoXML);
            }
        }
    }
}
