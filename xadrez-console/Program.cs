using System;
using tabuleiro;
using xadrez_console;
using xadrez;
using TabuleiroExcecao;

try
{
    Tabuleiro tab = new Tabuleiro(8, 8);

    tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
    tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 7));
    tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4 ));
    tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(5, 3));

    Tela.ImprimirTabuleiro(tab);

    Console.ReadLine();


}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);

}



