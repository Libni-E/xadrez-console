using System;
using tabuleiro;
using xadrez_console;
using xadrez;
using TabuleiroExcecao;

try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.Terminada)
    {
        Console.Clear();
        Tela.ImprimirTabuleiro(partida.Tab);

        Console.Write("Origem: ");
        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

        bool[,] posicoesPosiveis = partida.Tab.peca(origem).MovimentosPosiveis();

        Console.Clear();
        Tela.ImprimirTabuleiro(partida.Tab, posicoesPosiveis);

        Console.Write("Destino: ");
        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

        partida.ExecutaMovimento(origem, destino);


    }

    Tela.ImprimirTabuleiro(partida.Tab);


}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);

}



