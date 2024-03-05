﻿namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linha { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas { get; set; }

        public Tabuleiro(int linha, int colunas)
        {
            Linha = linha;
            Colunas = colunas;
            Pecas = new Peca[Linha ,Colunas];
        }

        public Peca peca (int linha, int coluna)
        {
            return Pecas[linha ,coluna];
        }
    }
}
