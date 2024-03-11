using tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }


        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre (Posicao pos)
        {
            return Tab.peca(pos) == null;
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.cor != cor;
        }



        public override bool[,] MovimentosPosiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
                if(Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha - 2 , posicao.Coluna);
                if ( Tab.PosicaoValida(pos) && Livre(pos) && QuantidadeDeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1 );
                if( Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna ] = true;
                }
                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

            }else
            {
                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha + 2, posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QuantidadeDeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

            }

            return mat;
        }
    }
}
