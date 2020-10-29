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
            KeyDown += Painel_KeyDown;
            KeyUp += Painel_KeyUp;
        }

        private void Painel_KeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Painel_KeyDown(object sender, KeyEventArgs e)
        {
            
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

        private void Inicia()
        {
            // Intancia todos os elementos
            tiro = new Elemento(0, 0, 1, 0);
            jogador = new Elemento(0, 0, larg, larg);
            // Adicionando a velocidade ao jogador
            jogador.Velocidade = 5f;
            blocos = new Elemento[5];
            // Adicionando os blocos
            for (int i = 0; i < blocos.Length; i++)
            {
                // Faz com que os blocos tenham 10 pixels de espaço entre eles
                int espaco = i * larg + 10 * (i + 1);
                blocos[i] = new Elemento(espaco, 0, larg, larg);
                blocos[i].Velocidade = 1f;
            }
        }
    }
}
