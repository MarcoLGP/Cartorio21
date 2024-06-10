using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cartório21.Business.Entidades;
using Cartório21.Business.Serviços;

namespace Cartório21
{
    public partial class Form_Principal : Form
    {
        private TituloServiços _tituloServicos = new TituloServiços();
        public Form_Principal()
        {
            InitializeComponent();
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
                var ret = await _tituloServicos.ImportaXML(caminhoArquivoXML);

                if (ret.erro != string.Empty)
                {
                    Utils.ExibirMensagemErro(ret.erro);
                    return;
                }

                else if (ret.TitulosJaCadastrados.Count > 0)
                {
                    foreach (var item in ret.TitulosJaCadastrados)
                    {

                    }
                }

                await AtualizarGridTitulos();
            }
        }



        private void btnCriarTitulo_Click(object sender, EventArgs e)
        {
            Form_Titulo formCriarTitulo = new Form_Titulo();
            formCriarTitulo.Show();
        }

        private async Task AtualizarGridTitulos()
        {
            IEnumerable<Titulo> ret = await _tituloServicos.ObterTodosOsTitulos();
            
            gridTitulos.AutoGenerateColumns = false;

            gridTitulos.DataSource = ret;
            
            gridTitulos.ClearSelection();
            
        }

        private void ConfigurarGridTitulos()
        {
            gridTitulos.Columns["EspecieTitulo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridTitulos.Columns["DataApresentacao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridTitulos.SelectionChanged += gridTitulos_SelectionChanged;
        }

        private async void Form_Principal_Load(object sender, EventArgs e)
        {
            await AtualizarGridTitulos();
            ConfigurarGridTitulos();

            new Form_ImportaXML("O título de protocolo 9898 já existe no sistema, deseja atualizar ?").ShowDialog();
        }

        private void gridTitulos_SelectionChanged(object sender, EventArgs e)
        {
            if (gridTitulos.SelectedCells.Count > 0)
            {
                btnAlterarTitulo.Enabled = true;
                btnExcluirTitulo.Enabled = true;
                btnDetalheTitulo.Enabled = true;
            }
            else
            {
                btnAlterarTitulo.Enabled = false;
                btnExcluirTitulo.Enabled = false;
                btnDetalheTitulo.Enabled = false;
            }
        }

        private async Task ConfirmarDeletarTituloSelecionado()
        {
            var dialogResult = MessageBox.Show(
                    "Deseja realmente excluir o título selecionado ?",
                    "Atenção",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.OK)
            {
                DataGridViewRow linhaSelecionada = gridTitulos.Rows[gridTitulos.CurrentRow.Index];
                int protocolo = int.Parse(linhaSelecionada.Cells["Protocolo"].Value.ToString());

                await _tituloServicos.DeletarTitulo(protocolo);
                await AtualizarGridTitulos();
            }
        }

        private async void btnExcluirTitulo_Click(object sender, EventArgs e)
        {
            await ConfirmarDeletarTituloSelecionado();
        }

        private async void btnAlterarTitulo_Click(object sender, EventArgs e)
        {
            var linhaSelecionada = gridTitulos.Rows[gridTitulos.CurrentRow.Index];
            
            Titulo tituloSelecionado = (Titulo)linhaSelecionada.DataBoundItem;
            
            Form_Titulo formAlterarTitulo = new Form_Titulo(tituloSelecionado);

            if (formAlterarTitulo.ShowDialog() == DialogResult.OK)
            {
                await AtualizarGridTitulos();
            }
        }
    }
}
