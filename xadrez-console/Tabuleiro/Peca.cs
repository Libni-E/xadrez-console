using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tabuleiro
{
    internal abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int QuantidadeDeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; set; }

        public Peca( Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            Tab = tab;
            QuantidadeDeMovimentos = 0;
        }

        public void IncrementarQteMovimentos()
        {
            QuantidadeDeMovimentos++;
        }

        public void DecrementarQteMovimentos()
        {
            QuantidadeDeMovimentos--;
        }

        public bool ExistemMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPosiveis();
            for (int i = 0; i < Tab.Linhas;  i++)
            {
                for (int j =0; j < Tab.Colunas; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPosiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPosiveis();
        

        

        


    }
}
