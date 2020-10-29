using PrimeiroJogo.Componentes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroJogo
{
    public partial class Form1 : Form
    {
        Painel painel = new Painel();
        
        public Form1()
        {
            Controls.Add(painel);
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Task t = Task.Run(painel.Atualiza);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            painel.SetaPressionada((int)e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            painel.SetaPressionada((int)e.KeyCode, false);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
                default:
                    break;
            }
        }
    }
}
