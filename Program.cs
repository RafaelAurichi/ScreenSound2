using ScreenSound2;
using ScreenSound2.Models.Musicas;
using ScreenSound2.Models.Podcast;
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

//INSTANCIAS

////artistas
Artista beatles = new("The Beatles");
Artista acdc = new("AC/DC");
Artista ternoRei = new("Terno Rei");
Artista bentivi = new("Bentivi");
Artista guns = new("Guns 'n Roses");

Dictionary<string, Artista> listaArtistas = new() {
    { beatles.Nome, beatles },
    { acdc.Nome, acdc },
    { ternoRei.Nome, ternoRei },
    { bentivi.Nome, bentivi },
    { guns.Nome, guns },
};

beatles.AddNotas(10);
beatles.AddNotas(8);
beatles.AddNotas(9);

//MÉTODOS
void ExibirMenu()
{
    Console.WriteLine(@"
        ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
        ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
        ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
        ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
        ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
        ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine("Seja bem vindo\n");

    Console.WriteLine("Digite 1 para registrar um(a) artista ou banda");
    Console.WriteLine("Digite 2 para mostrar todas (a)os artistas ou bandas");
    Console.WriteLine("Digite 3 para avaliar um(a) artista ou banda");
    Console.WriteLine("Digite 4 para exibir a média de um(a) artista ou banda");
    Console.WriteLine("Digite 0 para sair\n");

    try
    {
        Console.Write("Digite uma opação: ");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);

        Console.WriteLine();

        switch (opcaoEscolhida)
        {
            case 1:
                RegistrarBanda();
                break;
            case 2:
                ExibirBandas();
                break;
            case 3:
                AvaliarBanda();
                break;
            case 4:
                MediaNotasbanda();
                break;
            case 0:
                Console.WriteLine("Sessão Encerrada");
                Console.Clear();
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Opção Inválida");
    }

    Console.WriteLine();
}

void CabecalhoOpcoes(string str)
{
    Console.Clear();
    Console.WriteLine(str);
    Console.WriteLine("Caso deseje voltar, didite 0.\n");
}

void Voltar(int time)
{
    Thread.Sleep(time);
    Console.Clear();
    ExibirMenu();
}

void RegistrarBanda()
{
    CabecalhoOpcoes(@"
        ░█▀▀█ █▀▀ █▀▀▀ ─▀─ █▀▀ ▀▀█▀▀ █▀▀█ █▀▀█ 　 █▀▀▄ █▀▀ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
        ░█▄▄▀ █▀▀ █─▀█ ▀█▀ ▀▀█ ──█── █▄▄▀ █──█ 　 █──█ █▀▀ 　 █▀▀▄ █▄▄█ █──█ █──█ █▄▄█ ▀▀█ 
        ░█─░█ ▀▀▀ ▀▀▀▀ ▀▀▀ ▀▀▀ ──▀── ▀─▀▀ ▀▀▀▀ 　 ▀▀▀─ ▀▀▀ 　 ▀▀▀─ ▀──▀ ▀──▀ ▀▀▀─ ▀──▀ ▀▀▀
    ");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeArtista = Console.ReadLine();

    if (string.IsNullOrEmpty(nomeArtista))
    {
        Console.WriteLine("Opção inválida");
    } 
    else if (nomeArtista == "0")
    {
        Voltar(200);
    }
    else
    {
        Artista artista = new(nomeArtista); 
        listaArtistas.Add(artista.Nome, artista);
        Console.WriteLine($"A banda {nomeArtista} foi registrada com sucesso!");
        Console.WriteLine("\nClique qualquer tecla para voltar.");
        Console.ReadLine();
    }

    Voltar(200);
}

void ExibirBandas()
{
    Console.Clear();
    Console.WriteLine(@"
        ░█─── ─▀─ █▀▀ ▀▀█▀▀ █▀▀█ 　 █▀▀▄ █▀▀ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
        ░█─── ▀█▀ ▀▀█ ──█── █▄▄█ 　 █──█ █▀▀ 　 █▀▀▄ █▄▄█ █──█ █──█ █▄▄█ ▀▀█ 
        ░█▄▄█ ▀▀▀ ▀▀▀ ──▀── ▀──▀ 　 ▀▀▀─ ▀▀▀ 　 ▀▀▀─ ▀──▀ ▀──▀ ▀▀▀─ ▀──▀ ▀▀▀
    
    ");

    int i = 1;
    foreach (string x in listaArtistas.Keys)
    {
        Console.WriteLine($"Banda {i}: {x}");
        i++;
    }

    Console.WriteLine("\nClique qualquer tecla para voltar!");
    Console.ReadLine();
    Voltar(200);
}

void AvaliarBanda()
{
    CabecalhoOpcoes(@"
        ─█▀▀█ ▀█─█▀ █▀▀█ █── ─▀─ █▀▀█ █▀▀█ 　 ░█▀▀█ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
        ░█▄▄█ ─█▄█─ █▄▄█ █── ▀█▀ █▄▄█ █▄▄▀ 　 ░█▀▀▄ █▄▄█ █──█ █──█ █▄▄█ ▀▀█ 
        ░█─░█ ──▀── ▀──▀ ▀▀▀ ▀▀▀ ▀──▀ ▀─▀▀ 　 ░█▄▄█ ▀──▀ ▀──▀ ▀▀▀─ ▀──▀ ▀▀▀
    ");

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeArtista = Console.ReadLine()!;

    if (String.IsNullOrEmpty(nomeArtista))
    {
        Console.WriteLine("Opção inválida");
        Voltar(1500);
    }
    else if (nomeArtista == "0")
    {
        Voltar(200);
    }
    else
    {
        if (listaArtistas.ContainsKey(nomeArtista))
        {
            Console.Write("Digite a nota: ");
            int nota = int.Parse(Console.ReadLine()!);

            listaArtistas[nomeArtista].AddNotas(nota);
            Console.WriteLine($"A nota {nota} foi registrada para a banda {nomeArtista} com sucesso!");
            Console.WriteLine("\nClique qualquer tecla para voltar.");
            Console.ReadLine();
        }
    }

    Voltar(200);
}

void MediaNotasbanda()
{
    CabecalhoOpcoes(@"     
        ░█▀▄▀█ █▀▀ █▀▀▄ ─▀─ █▀▀█ 　 █▀▀▄ █▀▀█ █▀▀ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
        ░█░█░█ █▀▀ █──█ ▀█▀ █▄▄█ 　 █──█ █▄▄█ ▀▀█ 　 █▀▀▄ █▄▄█ █──█ █──█ █▄▄█ ▀▀█ 
        ░█──░█ ▀▀▀ ▀▀▀─ ▀▀▀ ▀──▀ 　 ▀▀▀─ ▀──▀ ▀▀▀ 　 ▀▀▀─ ▀──▀ ▀──▀ ▀▀▀─ ▀──▀ ▀▀▀
    ");

    Console.Write("Digite o nome da banda que deseja ver a média: ");
    string nomeArtista = Console.ReadLine()!;

    if (String.IsNullOrEmpty(nomeArtista))
    {
        Console.WriteLine("Opção inválida");
        Voltar(1500);
    }
    else if (nomeArtista == "0")
    {
        Voltar(200);
    }
    else
    {
        Console.WriteLine($"A média da banda {nomeArtista} é: {listaArtistas[nomeArtista].AverageDegree()}");
        Console.WriteLine("\nClique qualquer tecla para voltar.");
        Console.ReadLine();
    }

    Voltar(200);
}

//PROGRAMA
ExibirMenu();

Console.ReadLine();