using ScreenSound2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region TESTANDO PODCAST
/*
Podcast somNaTela = new("Rodriguinho DJ", "Som na tela");
Episodio ep = new("Remixar Tutorial", somNaTela)
{
    DuracaoEp = 47,
};
ep.AddConvidado("Rafael Aurichi");
ep.AddConvidado("Pondé");
somNaTela.AddEpisodios(ep);

Episodio ep2 = new("Efeitos Sonoros", somNaTela)
{
    DuracaoEp = 68,
};
somNaTela.AddEpisodios(ep2);
ep2.AddConvidado("Hanz Zimer");
ep2.AddConvidado("Tom Jobim");

somNaTela.ExibirDetalhes();
Console.WriteLine();
Console.WriteLine($"{ep.Resumo}");
Console.WriteLine();
Console.WriteLine($"{ep2.Resumo}");
*/
#endregion

#region TESTANDO FAIXAS MUSICAIS
/*
//instancias
Artista queen = new("Queen");

Album albumQueen = new(queen, "A Night At The Opera");

Musica musicaQueen1 = new(queen, "Love of my life")
{
    Duracao = 213,
    GeneroMusical = "Rock",
};

Musica musicaQueen2 = new(queen, "Bohemian Rhapsody")
{
    Duracao = 354,
    GeneroMusical = "Rock",
};

//metodos
albumQueen.AdicionarMusicas(musicaQueen2);
albumQueen.AdicionarMusicas(musicaQueen1);

queen.AddAlbum(albumQueen);

albumQueen.ExibirMusicas();
queen.ExibirDiscografia();

/*
Musica musica1 = new();

musica1.Nome = "Roxane";
musica1.Artista = "The Police";
musica1.Duracao = 270;
musica1.Disponivel = true;
Console.WriteLine(musica1.DescResumida);
musica1.ExibirFichaTecnica();

Musica musica2 = new();

musica2.Nome = "Vertigo";
musica2.Artista = "U2";
musica2.Duracao = 365;
musica2.Disponivel = false;
Console.WriteLine(musica2.DescResumida);
musica2.ExibirFichaTecnica();
*/
#endregion