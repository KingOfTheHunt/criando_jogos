using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrabalhandoComMouse.Componentes
{
    class Painel : Panel
    {
        private readonly int fps = 1000 / 20;
        private int pX, pY;
        public Point mouseClick = new Point();
        private bool jogando = true;

        public Painel()
        {
        }
        
        public void Inicia()
        {
            int proxAtualizacao = 0;

            while (jogando)
            {
                if (Environment.TickCount >= proxAtualizacao)
                {
                    Atualiza();
                    Invoke(new Action(() => Refresh()));
                    // Adicionando o tempo decorrido mais o fps
                    proxAtualizacao = Environment.TickCount + fps;
                }
            }
        }

        // Método responsável por criar o layout
        protected override void InitLayout()
        {
            Dock = DockStyle.Fill;
            BackColor = Color.Gray;
            // Adicionando um listener para o click do mouse
            MouseClick += Painel_MouseClick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (pX > 0 || pY > 0)
                {
                    e.Graphics.FillRectangle(Brushes.Blue, pX - 10, pY - 10, 20, 20);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Atualiza()
        {
            pX = mouseClick.X;
            pY = mouseClick.Y;
        }

        private void Painel_MouseClick(object sender, MouseEventArgs e)
        {
            // Armazenando a posição do mouse
            mouseClick = e.Location;
        }
    }
}
