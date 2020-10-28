using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Painel p = new Painel();

        public Form1()
        {
            Controls.Add(p);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task t = Task.Run(p.Inicia);
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

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    p.jogando = false;
                    break;
                case Keys.Up:
                    p.py--;
                    break;
                case Keys.Down:
                    p.py++;
                    break;
                case Keys.Left:
                    p.px--;
                    break;
                case Keys.Right:
                    p.px++;
                    break;
                default:
                    break;
            }
        }
    }
}
