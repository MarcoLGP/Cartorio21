using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cartório21.Business.Entidades;
using Cartório21.Business.Serviços;
using Cartório21.Business.Enums;

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
                var ret = await _tituloServicos.ImportaXML(caminhoArquivoXML);

                if (ret.erro != string.Empty)
                {
                    Utils.ExibirMensagemErro(ret.erro);
                    return;
                }

                else if (ret.TitulosJaCadastrados.Count > 0)
                {
                    bool simTodos = false;

                    foreach (var item in ret.TitulosJaCadastrados)
                    {
                        if (simTodos)
                        {
                            await _tituloServicos.AtualizarTitulo(item, item.Protocolo);
                        }
                        else
                        {
                            DialogResult dialogResult = new Form_ImportaXML($"Já existe um título com protocolo {item.Protocolo} cadastrado, deseja atualiza-lo ?").ShowDialog();

                            if (dialogResult == DialogResult.Yes)
                            {
                                await _tituloServicos.AtualizarTitulo(item, item.Protocolo);
                            }
                            else if (dialogResult == DialogResult.OK)
                            {
                                simTodos = true;
                                await _tituloServicos.AtualizarTitulo(item, item.Protocolo);
                            }
                            else if (dialogResult == DialogResult.Ignore)
                            {
                                break;
                            }
                        }
                    }
                }
                
                await AtualizarGridTitulos();
            }
        }

        private async void btnCriarTitulo_Click(object sender, EventArgs e)
        {
            Form_Titulo formCriarTitulo = new Form_Titulo();

            if (formCriarTitulo.ShowDialog() == DialogResult.OK)
                await AtualizarGridTitulos();
        }

        private async Task AtualizarGridTitulos()
        {
            IEnumerable<Titulo> ret = await _tituloServicos.ObterTodosOsTitulos();
            
            gridTitulos.AutoGenerateColumns = false;

            gridTitulos.DataSource = null;
            gridTitulos.DataSource = ret;
            
            gridTitulos.ClearSelection();
        }

        private void ConfigurarGridTitulos()
        {
            gridTitulos.Columns["EspecieTitulo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridTitulos.Columns["DataApresentacao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridTitulos.SelectionChanged += gridTitulos_SelectionChanged;
        }

        private async Task VerificarConexaoBanco()
        {
            var stringConexao = BaseDadosServiços.ObterStringConexaoBaseDados();

            if (stringConexao == string.Empty)
            {
                if (new Form_Configuracoes().ShowDialog() != DialogResult.OK)
                {
                    Utils.ExibirMensagemErro("Não é possível prosseguir sem uma conexão ativa com o banco de dados, por favor tente novamente mais tarde");
                    Close();
                }
            }
            else 
            {
                if (!await BaseDadosServiços.TestarConexao())
                {
                    if(new Form_Configuracoes().ShowDialog() != DialogResult.OK)
                {
                        Utils.ExibirMensagemErro("Não é possível prosseguir sem uma conexão ativa com o banco de dados, por favor tente novamente mais tarde");
                        Close();
                    }
                }
            }
        }

        private async void Form_Principal_Load(object sender, EventArgs e)
        {
            await VerificarConexaoBanco();
            await AtualizarGridTitulos();
            ConfigurarGridTitulos();
        }

        private void gridTitulos_SelectionChanged(object sender, EventArgs e)
        {
            if (gridTitulos.SelectedCells.Count > 0)
            {
                btnAlterarTitulo.Enabled = btnExcluirTitulo.Enabled = btnDetalheTitulo.Enabled = true;
            }
            else
            {
                btnAlterarTitulo.Enabled = btnExcluirTitulo.Enabled = btnDetalheTitulo.Enabled = false;
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
            var tituloSelecionado = ObterTituloSelecionado();            
            
            Form_Titulo formAlterarTitulo = new Form_Titulo(tituloSelecionado, OperacaoTitulo.Alterar);

            if (formAlterarTitulo.ShowDialog() == DialogResult.OK)
            {
                await AtualizarGridTitulos();
            }
        }

        private Titulo ObterTituloSelecionado()
        {
            var linhaSelecionada = gridTitulos.Rows[gridTitulos.CurrentRow.Index];
            Titulo tituloSelecionado = (Titulo)linhaSelecionada.DataBoundItem;

            return tituloSelecionado;
        }

        private void ExibirFormDetalheTituloSelecionado()
        {
            var tituloSelecionado = ObterTituloSelecionado();
            new Form_Titulo(tituloSelecionado, OperacaoTitulo.Detalhe).Show();
        }

        private void btnDetalheTitulo_Click(object sender, EventArgs e)
        {
            ExibirFormDetalheTituloSelecionado();
        }

        private void gridTitulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ExibirFormDetalheTituloSelecionado();
        }

        private async void gridTitulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridTitulos.SelectedCells.Count > 0)
            {
                await ConfirmarDeletarTituloSelecionado();
            }
        }

        private async void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            Form_Configuracoes formConfiguracoes = new Form_Configuracoes();

            if (formConfiguracoes.ShowDialog() == DialogResult.OK)
                await AtualizarGridTitulos();
        }
    }
}
