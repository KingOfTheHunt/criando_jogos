namespace Entidades
{
    class Elemento
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
        public float Velocidade { get; set; }

        public Elemento(int x, int y, int largura, int altura)
        {
            X = x;
            Y = y;
            Largura = largura;
            Altura = altura;
        }
    }
}
