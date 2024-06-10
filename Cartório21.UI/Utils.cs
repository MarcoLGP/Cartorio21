using System.Windows.Forms;

namespace Cartório21
{
    public static class Utils
    {
        public static void ExibirMensagemErro(string mensagem, string titulo = "Ocorreu um erro")
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
