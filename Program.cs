using ScreenSound2.Models.Musicas;
using ScreenSound2.Sistema;
using ScreenSound2.Sistema.Menu;
using System.Text.Json;

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

//INSTANCIAS

////artistas

Dictionary<string, Artista> listaArtistas = new();

HttpClient client = new HttpClient();
try
{
    string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
    var artistas = JsonSerializer.Deserialize<List<Artista>>(resposta)!;

    var artistasFiltrados = Linq.LinqDistinctArtista(artistas);

    foreach (var artista in artistasFiltrados)
    {
        listaArtistas.Add(artista.Key, artista.Value);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
/*
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


////notas
beatles.AddNotas(new List<double> { 10, 8, 9 });
acdc.AddNotas(new List<double> { 9, 7, 9 });
ternoRei.AddNotas(new List<double> { 8, 8 });
bentivi.AddNotas(new List<double> { 10 });
guns.AddNotas(new List<double> { 10, 8, 254, -56 });

//albuns
Album beatles1 = new(beatles, "A Hard Day's Night");
Album beatles2 = new(beatles, "The Beatles (\"Álbum Branco\")");
Album beatles3 = new(beatles, "Abbey Road");

Album acdc1 = new(acdc, "Back in Black");
Album acdc2 = new(acdc, "Black Ice");
Album acdc3 = new(acdc, "Rock or Bust");

Album terno1 = new(ternoRei, "Vigilia");
Album terno2 = new(ternoRei, "Violeta");
Album terno3 = new(ternoRei, "Gêmeos");

Album guns1 = new(guns, "Use Your Illusion II");
Album guns2 = new(guns, "Live Era: '87-'93");
Album guns3 = new(guns, "Appetite for Destruction");

//musicas
new Musica(beatles1, "A Hard Day's Night", "Rock")
{
    DuracaoSeg = 154,
};
new Musica(beatles1, "Can't Buy Me Love", "Rock")
{
    DuracaoSeg = 132,
};

new Musica(beatles2, "Ob-La-Di, Ob-La-Da", "Rock")
{
    DuracaoSeg = 132,
};
new Musica(beatles2, "Blackbird", "Rock")
{
    DuracaoSeg = 188,
};

new Musica(beatles3, "Here Comes the Sun", "Rock")
{
    DuracaoSeg = 185,
}; 
new Musica(beatles3, "Come Together", "Rock")
{
    DuracaoSeg = 260,
};

new Musica(acdc1, "Back in Black", "Rock")
{
    DuracaoSeg = 254,
}; 
new Musica(acdc1, "Hells Bells", "Rock")
{
    DuracaoSeg = 310,
};

new Musica(acdc2, "War Machine", "Rock")
{
    DuracaoSeg = 189,
};
new Musica(acdc2, "She Likes Rock 'n' Roll", "Rock")
{
    DuracaoSeg = 233,
};

new Musica(acdc3, "Play Ball", "Rock")
{
    DuracaoSeg = 167,
};
new Musica(acdc3, "Rock or Bust", "Rock")
{
    DuracaoSeg = 183,
};

new Musica(terno1, "Dia de Treino", "Post-Rock, Rock Alternativo, Shoegaze")
{
    DuracaoSeg = 207,
};
new Musica(terno1, "Passagem", "Post-Rock, Rock Alternativo, Shoegaze")
{
    DuracaoSeg = 202,
};

new Musica(terno2, "Solidão de Volta", "Dream Pop, Shoegaze")
{
    DuracaoSeg = 162,
};
new Musica(terno2, "Dia lindo", "Dream Pop, Shoegaze")
{
    DuracaoSeg = 110,
};

new Musica(terno3, "Só Eu Sei", "Indie")
{
    DuracaoSeg = 153,
};
new Musica(terno3, "Olha Só", "Indie")
{
    DuracaoSeg = 166,
};

new Musica(bentivi, "Soliquarto", "Indie")
{
    DuracaoSeg = 256,
};
new Musica(bentivi, "Mais que um minuto", "Indie")
{
    DuracaoSeg = 204,
};
new Musica(bentivi, "Verde limão", "Indie")
{
    DuracaoSeg = 179,
};
new Musica(bentivi, "Odisséia", "Indie")
{
    DuracaoSeg = 237,
};

new Musica(guns1, "Don't Cry", "Rock")
{
    DuracaoSeg = 284,
};
new Musica(guns1, "Pretty Tied Up", "Rock")
{
    DuracaoSeg = 288,
};

new Musica(guns2, "You Could Be Mine", "Rock")
{
    DuracaoSeg = 364,
};
new Musica(guns2, "Yesterdays", "Rock")
{
    DuracaoSeg = 265,
};

new Musica(guns3, "Sweet Child O' Mine", "Rock")
{
    DuracaoSeg = 356,
};
new Musica(guns3, "Welcome to the Jungle", "Rock")
{
    DuracaoSeg = 273,
};
*/
//MENU
ExibirMenu();

void ExibirMenu()
    {
            
        Console.WriteLine(@"
         ██████╗  █████╗  ██████╗  ███████╗ ███████╗ ███╗  ██╗    ██████╗  █████╗  ██╗   ██╗ ███╗  ██╗ ██████╗
        ██╔════╝ ██╔══██╗ ██╔══██╗ ██╔════╝ ██╔════╝ ████╗ ██║   ██╔════╝ ██╔══██╗ ██║   ██║ ████╗ ██║ ██╔══██╗
        ╚█████╗  ██║  ╚═╝ ██████╔╝ █████╗   █████╗   ██╔██╗██║   ╚█████╗  ██║  ██║ ██║   ██║ ██╔██╗██║ ██║  ██║
         ╚═══██╗ ██║  ██╗ ██╔══██╗ ██╔══╝   ██╔══╝   ██║╚████║    ╚═══██╗ ██║  ██║ ██║   ██║ ██║╚████║ ██║  ██║
        ██████╔╝ ╚█████╔╝ ██║  ██║ ███████╗ ███████╗ ██║ ╚███║   ██████╔╝ ╚█████╔╝ ╚██████╔╝ ██║ ╚███║ ██████╔╝
        ╚═════╝   ╚════╝  ╚═╝  ╚═╝ ╚══════╝ ╚══════╝ ╚═╝  ╚══╝   ╚═════╝   ╚════╝   ╚═════╝  ╚═╝  ╚══╝ ╚═════╝
        ");
        Console.WriteLine("Seja bem vindo\n");

        Console.WriteLine("Digite 1 para registrar um(a) artista ou banda");
        Console.WriteLine("Digite 2 para mostrar todas (a)os artistas ou bandas");
        Console.WriteLine("Digite 3 para avaliar um(a) artista (ou banda), álbum ou música");
        Console.WriteLine("Digite 4 para exibir a média de um(a) artista ou banda");
        Console.WriteLine("Digite 0 para sair\n");

        Dictionary<int, Menu> opcoes = new()
        {
            {1, new MenuRegistrarArtistas()},
            {2, new MenuExibirArtistas()},
            {3, new MenuAvaliarArtistas()},
            {4, new MenuMediaArtistas()},
        };

        try
        {
            Console.Write("Digite uma opação: ");
            int opcaoEscolhida = int.Parse(Console.ReadLine()!);

            if (opcoes.ContainsKey(opcaoEscolhida))
            {
                opcoes[opcaoEscolhida].Executar(listaArtistas); 
                ExibirMenu();
            }
            else if (opcaoEscolhida == 0)
            {
                Console.Clear();
                Console.WriteLine("tchau, tchau :)");
            }
            else
            {
                Console.WriteLine("\nOpção Inválida");
                Menu.Voltar(1000);
                ExibirMenu();
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("\nOpção Inválida");
            Menu.Voltar(1000);
            ExibirMenu();
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("\nOpção Inválida");
            Menu.Voltar(1000);
            ExibirMenu();
        }
    }