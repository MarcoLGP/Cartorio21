using System.Windows.Forms;

namespace Cartório21
{
    public partial class Form_CriarAlterarTitulo : Form
    {
        private bool _alterarTitulo;
        public Form_CriarAlterarTitulo(bool alterarTitulo = false)
        {
            InitializeComponent();
            _alterarTitulo = alterarTitulo;
        }

        private void Form_CriarAlterarTitulo_Load(object sender, System.EventArgs e)
        {
            if (_alterarTitulo)
            {
                this.Text = "Alterar título - 2626262626262626";
                btnSalvar.Text = "Alterar título";
            }
        }
    }
}
