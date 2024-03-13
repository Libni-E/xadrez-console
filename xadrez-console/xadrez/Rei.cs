using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca


    {

        private PartidaDeXadrez Partida;
        public Rei (Tabuleiro tab, Cor cor, PartidaDeXadrez partida):base(tab, cor)
        {
            Partida = partida;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.QuantidadeDeMovimentos == 0;
        }

        public override bool[,] MovimentosPosiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);

            if(Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Ne
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna +1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Direita
            pos.DefinirValores(posicao.Linha , posicao.Coluna + 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Se
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Abaixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //So
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Esquerda
            pos.DefinirValores(posicao.Linha, posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //No
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            // #Jogadaespecial Roque
            if (QuantidadeDeMovimentos == 0 && !Partida.Xeque)
            {
                //JogadaEspecial roque pequeno
                Posicao posT1 = new Posicao(posicao.Linha, posicao.Coluna + 3);

                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna + 2);
                    if(Tab.peca(p1) == null && Tab.peca(p2) == null)
                    {
                        mat[posicao.Linha, posicao.Coluna + 2] = true;
                    }
                }

                //JogadaEspecial roque grande
                Posicao posT2 = new Posicao(posicao.Linha, posicao.Coluna -4 );

                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna - 2);
                    Posicao p3 = new Posicao(posicao.Linha, posicao.Coluna - 3);

                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                    {
                        mat[posicao.Linha, posicao.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override string ToString()
        {
            return "R";
        }


    }
}
