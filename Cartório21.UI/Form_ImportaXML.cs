using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cartório21
{
    public partial class Form_ImportaXML : Form
    {
        private string _mensagem;
        public Form_ImportaXML(string mensagem)
        {
            InitializeComponent();
            _mensagem = mensagem;
        }

        private void Form_ImportaXML_Load(object sender, EventArgs e)
        {
            pictureIcon.Image = SystemIcons.Information.ToBitmap();

            lblMensagem.Text = _mensagem;
        }
    }
}
