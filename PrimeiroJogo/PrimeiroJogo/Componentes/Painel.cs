using Entidades;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrimeiroJogo.Componentes
{
    class Painel : Panel
    {
        private bool _fimDeJogo = false;
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
                int espaco = i * _larg + 15 * (i + 1);
                _blocos[i] = new Elemento(espaco, 0, _larg, _larg);
                _blocos[i].Velocidade = 1f;
            }

            // Definindo a posição do _jogador
            _jogador.X = 221;
            _jogador.Y = 391;
            _tiro.Altura = Height - _jogador.Altura;
        }

        // Atualiza os dados do jogo
        private void AtualizaJogo()
        {
            if (_fimDeJogo)
            {
                return;
            }

            // Movendo o jogador na horizontal
            if (_controleTeclas[2])
            {
                _jogador.X -= (int)_jogador.Velocidade;
            }
            else if (_controleTeclas[3])
            {
                _jogador.X += (int)_jogador.Velocidade;
            }

            // Fazendo o jogador aparecer do lado oposto
            if (_jogador.X < 0)
            {
                _jogador.X = Width - _jogador.Largura;
            }
            if ((_jogador.X + _jogador.Largura) > Width)
            {
                _jogador.X = 0;
            }

            // Resetando o tiro
            _tiro.Y = 0;
            _tiro.X = _jogador.X + _jogador.Largura / 2;

            // Verificando se algum bloco passou pela linha limite
            foreach (var b in _blocos)
            {
                if (b.Y > _limiteLinha)
                {
                    _fimDeJogo = true;
                    break;
                }

                // Verificando se houve colisão com o tiro
                if (Colide(b, _tiro) && b.Y > 0)
                {
                    // Faz que o tiro volte
                    b.Y -= (int)b.Velocidade * 2;
                    _tiro.Y = b.Y;
                }
                else
                {
                    int sorte = _rand.Next(10);
                    if (sorte == 0)
                    {
                        b.Y += (int)b.Velocidade + 1;
                    }
                    else if (sorte == 5)
                    {
                        b.Y -= (int)b.Velocidade;
                    }
                    else
                    {
                        b.Y += (int)b.Velocidade;
                    }
                }
            }
            // Adicionando os pontos
            _pontuacao += _blocos.Length;
        }

        private bool Colide(Elemento a, Elemento b)
        {
            if (a.X + a.Largura >= b.X && a.X <= b.X + b.Largura)
            {
                return true;
            }

            return false;
        }

        public void SetaPressionada(int tecla, bool pressionada)
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

        public void Atualiza()
        {
            Iniciar();

            int prxAtualizacao = 0;

            while (!_fimDeJogo) 
            {
                if (Environment.TickCount >= prxAtualizacao)
                {
                    AtualizaJogo();
                    Invoke(new Action(() => Refresh()));
                    prxAtualizacao = Environment.TickCount + _fps;
                }
            }
            MessageBox.Show("Sua pontuação: " + _pontuacao, "Fim de jogo!");
        }
    }
}
