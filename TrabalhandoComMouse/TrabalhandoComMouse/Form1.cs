using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhandoComMouse.Componentes;

namespace TrabalhandoComMouse
{
    public partial class Form1 : Form
    {
        Painel painel = new Painel();

        public Form1()
        {
            // Adicionando o painel
            Controls.Add(painel);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task t = Task.Run(painel.Inicia);
        }
    }
}
