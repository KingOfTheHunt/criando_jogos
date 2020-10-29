using Entidades;
using System;
using System.Windows.Forms;

namespace PrimeiroJogo.Componentes
{
    class Painel : Panel
    {
        private bool jogando = true;
        private readonly int fps = 1000 / 20;
        private Elemento tiro;
        private Elemento jogador;
        private Elemento[] blocos;
        private bool[] controleTeclas = new bool[4];
        // Defifnindo a largura do jogodor
        private int larg = 50;
        // Definindo o tamanho do tiro
        private int limiteLinha = 350;
        // Criando um objeto random para poder posicionar de maneira aleatória os blocos
        private Random rand = new Random();

        protected override void InitLayout()
        {
            Dock = DockStyle.Fill;
            PreviewKeyDown += Painel_PreviewKeyDown;
        }

        private void Painel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    jogando = false;
                    break;
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

        public void Inicia()
        {
            // Intancia todos os elementos
            tiro = new Elemento(0, 0, 1, 0, )
        }
    }
}
