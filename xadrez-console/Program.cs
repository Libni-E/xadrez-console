using System;
using tabuleiro;
using xadrez_console;
using xadrez;


try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();
    //Console.Write(ImpressaoDeEntrada());
    //Console.ReadLine();
    Console.WriteLine("Jogo de Xadrez entre com os nomes dos jogadores: ");
    string[] nomes = Console.ReadLine().Split(' ');
    while (!partida.Terminada)
    {
        try
        {
            Console.Clear();
            Console.WriteLine(nomes[0] + " X " + nomes[1] );

            Tela.ImprimirPartida(partida);
            


            Console.WriteLine();
            Console.Write("Origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
            partida.ValidarPosicaoDeOrigem(origem);

            bool[,] posicoesPosiveis = partida.Tab.peca(origem).MovimentosPosiveis();

            Console.Clear();
            Tela.ImprimirTabuleiro(partida.Tab, posicoesPosiveis);

            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
            partida.ValidarPosicaoDeDestino(origem, destino);

            partida.RealizaJogada(origem, destino);
        }catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

    }

    Tela.ImprimirTabuleiro(partida.Tab);


}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);

}

static string ImpressaoDeEntrada()
{
    
    return "-------------------------------------------------------------------------\n" + 
           "------    ----------    -------------------    -------------    ---------\n" +
           "-------    --------    -----            ---  -  -----------  -  -----------\n" +
           "--------    ------    ------    -----------  --  ---------  -  -  ---\n" +
           "---------    ----    -------    -----------  ---  -------  -  --  ---\n" +
           "----------    --    --------         ------  ----  -----  -  ---  --------\n" +
           "----------    --    --------         ------  -----  ---  -  ----  --------\n" +
           "---------    ----    -------    -----------  ------  -  -  -----  ---\n" +
           "--------    ------    ------    -----------  -----------  ------  -----------\n" +
           "-------    --------    -----            ---  ---------     --------  -------\n" +
           "------    ----------    -------------------   ------    ----------  -------------\n" +
           "-------------------------------------------------------------------------------------------------\n";
           
}



