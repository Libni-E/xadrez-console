﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    internal class Peca
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

        


    }
}
