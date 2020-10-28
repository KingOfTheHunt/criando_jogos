using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Painel : Panel
    {
        private int fps = 1000 / 20;
        public int px, py;
        public bool jogando = true;

        public Painel()
        {
            // Fazendo o painel ocupar todo o formulário
            this.Dock = DockStyle.Fill;
        }

        public void Inicia()
        {
            long prxAtualizacao = 0;

            while (jogando)
            {
                if (Environment.TickCount >= prxAtualizacao)
                {
                    Invoke(new Action(() => Refresh()));
                    prxAtualizacao = Environment.TickCount + fps;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                e.Graphics.Clear(BackColor);

                int x = Width / 2 - 20 + px;
                int y = Height / 2 - 20 + py;

                // Desenhando o quadrado no centro do form
                e.Graphics.FillRectangle(Brushes.Black, x, y, 40, 40);
                e.Graphics.DrawString("Agora estou em " + x + "X" + y, new Font("Arial", 16),
                    Brushes.Green, 5, 10, new StringFormat());
                /*
                // Criando um objeto que vai armazenar a cor
                Pen pen = new Pen(Color.Red);
                // Desenhando uma linha no meio do painel na horizontal
                e.Graphics.DrawLine(pen, 0, (Height / 2) + ct, Width, (Height / 2) + ct);
                // Desenhando uma linha no meio do painel na vertical
                e.Graphics.DrawLine(pen, (Width / 2) - ct, 0, (Width / 2) - ct, Height);
                // Desenhando um circulo
                e.Graphics.FillEllipse(Brushes.Blue, 220, 240, 220 + ct, 220);
                // Desenhando um retângulo
                e.Graphics.DrawRectangle(pen, 110, 125, 120 - ct, 120 - ct);
                // Atribuindo uma nova cor
                pen.Color = Color.Green;
                // Desenhando um texto
                // Definindo uma fonte
                Font fonte = new Font("Arial", 10);
                // Definindo um formato da string
                StringFormat formato = new StringFormat();

                e.Graphics.DrawString("Eu seria um ótimo score: " + ct,
                    fonte, Brushes.Green, 5, 10, formato); */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        /* public void IniciaAnimacao()
        {
            // Armazena o tempo da próxima atualização
            long prxAtualizacao = 0;

            while (anima)
            {
                // Environment.TickCount pega quantidade de milissegundos desde a iniciação do sistema
                if (Environment.TickCount >= prxAtualizacao)
                {
                    ct++;
                    Invoke(new Action(() => Refresh()));

                    prxAtualizacao = Environment.TickCount + fps;

                    if (ct == 100)
                    {
                        anima = false;
                    }
                }
            }
        }*/
    }
}

