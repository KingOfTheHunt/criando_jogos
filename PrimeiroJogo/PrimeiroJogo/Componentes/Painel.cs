using Entidades;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrimeiroJogo.Componentes
{
    class Painel : Panel
    {
        private bool _iniciado = false;
        private bool _jogando = true;
        private readonly int _fps = 1000 / 20;
        private Elemento _tiro;
        private Elemento _jogador;
        private Elemento[] _blocos;
        private bool[] _controleTeclas = new bool[4];
        private int _pontuacao = 0;
        // Defifnindo a _largura do jogodor
        private int _larg = 50;
        // Definindo limite
        private int _limiteLinha = 350;
        // Criando um objeto random para poder posicionar de maneira aleatória os _blocos
        private Random _rand = new Random();

        protected override void InitLayout()
        {
            Dock = DockStyle.Fill;
            PreviewKeyDown += Painel_PreviewKeyDown;
            KeyDown += Painel_KeyDown;
            KeyUp += Painel_KeyUp;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                // Limpando a tela
                e.Graphics.Clear(BackColor);
                // Desenhando os objetos
                // _tiro
                e.Graphics.FillRectangle(Brushes.Red, _tiro.X, _tiro.Y, _tiro.Largura, this.Height);
                // _jogador
                e.Graphics.FillRectangle(Brushes.Green, _jogador.X, _jogador.Y, 
                    _jogador.Largura, _jogador.Altura);
                // _blocos
                foreach (var b in _blocos)
                {
                    e.Graphics.FillRectangle(Brushes.Yellow, b.X, b.Y, b.Largura, b.Altura);
                }
                // Linha limite
                e.Graphics.DrawLine(new Pen(Color.DarkBlue), 0, _limiteLinha, Width, _limiteLinha);
                // Pontuação
                e.Graphics.DrawString("Pontuação: " + _pontuacao, new Font("Arial", 10),
                    Brushes.Black, 0, 10);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Painel_KeyUp(object sender, KeyEventArgs e)
        {
            SetaPressionada((int)e.KeyCode, false);
        }

        private void Painel_KeyDown(object sender, KeyEventArgs e)
        {
            SetaPressionada((int)e.KeyCode, true);
        }

        private void Painel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void Iniciar()
        {
            // Intancia todos os elementos
            _tiro = new Elemento(0, 0, 1, 0);
            _jogador = new Elemento(0, 0, _larg, _larg);
            // Adicionando a velocidade ao _jogador
            _jogador.Velocidade = 5f;
            _blocos = new Elemento[5];
            // Adicionando os _blocos
            for (int i = 0; i < _blocos.Length; i++)
            {
                // Faz com que os _blocos tenham 10 pixels de espaço entre eles
                int espaco = i * _larg + 10 * (i + 1);
                _blocos[i] = new Elemento(espaco, 0, _larg, _larg);
                _blocos[i].Velocidade = 1f;
            }

            // Definindo a posição do _jogador
            _jogador.X = Width / 2 - _jogador.X / 2;
            _jogador.Y = Height / 2 - _jogador.Y / 2;
            _tiro.Altura = Height - _jogador.Altura;
        }

        private void SetaPressionada(int tecla, bool pressionada)
        {
            switch (tecla)
            {
                case (int)Keys.Up:
                    _controleTeclas[0] = pressionada;
                    break;
                case (int)Keys.Down:
                    _controleTeclas[1] = pressionada;
                    break;
                case (int)Keys.Left:
                    _controleTeclas[2] = pressionada;
                    break;
                case (int)Keys.Right:
                    _controleTeclas[3] = pressionada;
                    break;
            }
        }
    }
}
