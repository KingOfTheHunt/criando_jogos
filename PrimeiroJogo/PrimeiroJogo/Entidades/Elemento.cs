namespace Entidades
{
    class Elemento
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Largura { get; private set; }
        public int Altura { get; private set; }
        public float Velocidade { get; private set; }

        public Elemento(int x, int y, int largura, int altura, float velocidade)
        {
            X = x;
            Y = y;
            Largura = largura;
            Altura = altura;
            Velocidade = velocidade;
        }
    }
}
