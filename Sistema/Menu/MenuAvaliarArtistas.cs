using ScreenSound2.Models.Musicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2.Sistema.Menu
{
    internal class MenuAvaliarArtistas : Menu
    {
        public override void Executar(Dictionary<string, Artista> listaArtistas)
        {
            CabecalhoOpcoes(@"
                █▀▀█ ▀█ █▀ █▀▀█ █    ▀  █▀▀█ █▀▀█ 　  █▀▀█ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
                █▄▄█  █▄█  █▄▄█ █   ▀█▀ █▄▄█ █▄▄▀ 　  █▀▀▄ █▄▄█ █  █ █  █ █▄▄█ ▀▀█ 
                █  █   ▀   ▀  ▀ ▀▀▀ ▀▀▀ ▀  ▀ ▀ ▀▀ 　  █▄▄█ ▀  ▀ ▀  ▀ ▀▀▀  ▀  ▀ ▀▀▀
            ");

            int i = 1;
            foreach (string x in listaArtistas.Keys)
            {
                Console.WriteLine($"Banda {i}: {x}");
                i++;
            }

            Console.Write("\nDigite o nome do artista ou banda que deseja avaliar: ");
            string nomeArtista = Console.ReadLine();

            if (nomeArtista == "0")
            {

            }
            else if (listaArtistas.ContainsKey(nomeArtista))
            {
                Avaliar(listaArtistas, listaArtistas[nomeArtista]);
            }
            else
            {
                Console.WriteLine("\nOpção inválida!");
                Voltar(1000);
                this.Executar(listaArtistas);
            }

            Voltar(200);
        }

        public void Avaliar(Dictionary<string, Artista> listaArtistas, Artista artista)
        {
            CabecalhoOpcoes(@"
                █▀▀█ ▀█ █▀ █▀▀█ █    ▀  █▀▀█ █▀▀█ 　  █▀▀█ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
                █▄▄█  █▄█  █▄▄█ █   ▀█▀ █▄▄█ █▄▄▀ 　  █▀▀▄ █▄▄█ █  █ █  █ █▄▄█ ▀▀█ 
                █  █   ▀   ▀  ▀ ▀▀▀ ▀▀▀ ▀  ▀ ▀ ▀▀ 　  █▄▄█ ▀  ▀ ▀  ▀ ▀▀▀  ▀  ▀ ▀▀▀
            ");

            try
            {
                string objetoFinal = "";

                if(artista.QuantMusicas == 0 & artista.QuantAlbuns == 0)
                {
                    objetoFinal = "artista";
                }
                else
                {
                    artista.ExibirDiscografia();

                    if (artista.QuantMusicas == 0)
                    {
                        Console.Write("\nDigite 1 para avaliar o artista; 2 para álbum: ");
                        int objeto = int.Parse(Console.ReadLine());

                        switch (objeto)
                        {
                            case 0:
                                objetoFinal = "voltar";
                                break;

                            case 1:
                                objetoFinal = "artista";
                                break;

                            case 2:
                                objetoFinal = "álbum";
                                break;
                        } 
                    }
                    else if (artista.QuantAlbuns == 0)
                    {
                        Console.Write("\nDigite 1 para avaliar o artista; 2 para música: ");
                        int objeto = int.Parse(Console.ReadLine());

                        switch (objeto)
                        {
                            case 0:
                                objetoFinal = "voltar";
                                break;

                            case 1:
                                objetoFinal = "artista";
                                break;

                            case 2:
                                objetoFinal = "música";
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("\nDigite 1 para avaliar o artista; 2 para álbum; 3 para música: ");
                        int objeto = int.Parse(Console.ReadLine());

                        switch (objeto)
                        {
                            case 0:
                                objetoFinal = "voltar";
                                break;

                            case 1:
                                objetoFinal = "artista";
                                break;

                            case 2:
                                objetoFinal = "álbum";
                                break;

                            case 3:
                                objetoFinal = "música";
                                break;
                        }
                    }
                }

                switch (objetoFinal)
                {
                    case "voltar":
                        Voltar(200);
                        Executar(listaArtistas);
                        break;

                    case "artista":
                        Console.Write($"\nDigite a nota que deseja atribuir a {artista.Nome}: ");
                        double notaArtista = double.Parse(Console.ReadLine());
                        artista.AddNotas(notaArtista);
                        Console.WriteLine($"\nA nota {notaArtista} foi atribuida a {artista.Nome} com sucesso!");
                        break;

                    case "álbum":
                        AvaliarEspecifico(artista, 2);
                        break;

                    case "música":
                        AvaliarEspecifico(artista, 3);
                        break;

                    default:
                        Console.WriteLine("\nOpção Inválida");
                        Voltar(1000);
                        this.Avaliar(listaArtistas, artista);
                        break;
                }

                Voltar(2000);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nOpção Inválida");
                Voltar(1000);
                this.Avaliar(listaArtistas, artista);
            }
        }


        public void AvaliarEspecifico(Artista artista, int opcao)
        {
            try
            {
                switch (opcao)
                {
                    case 2:
                        Console.Write($"\nDigite o nome do álbum que deseja avaliar: ");
                        string album = Console.ReadLine();

                        if (album == "0")
                        {
                            Voltar(200);
                            AvaliarEspecifico(artista, opcao);
                        }
                        else if (artista.GetAlbum(album) != null)
                        {
                            Album albumEscolhido = artista.GetAlbum(album);

                            Console.Write($"\nDigite a nota que deseja atribuir ao álbum {albumEscolhido.Nome}: ");
                            double notaAlbum = double.Parse(Console.ReadLine());
                            
                            albumEscolhido.AddNotas(notaAlbum);
                            Console.WriteLine($"\nA nota {notaAlbum} foi atribuida a {album} com sucesso!");
                        }
                        break;

                    case 3:
                        Console.Write($"\nDigite o nome da música que deseja avaliar: ");
                        string musica = Console.ReadLine();

                        if (musica == "0")
                        {
                            Voltar(200);
                            AvaliarEspecifico(artista, opcao);
                        }
                        else if (artista.GetMusica(musica) != null)
                        {
                            Musica musicaEscolhida = artista.GetMusica(musica);

                            Console.Write($"\nDigite a nota que deseja atribuir à música {musicaEscolhida.Nome}: ");
                            double notaMusica = double.Parse(Console.ReadLine());

                            musicaEscolhida.AddNotas(notaMusica);
                            Console.WriteLine($"\nA nota {notaMusica} foi atribuida a {musica} com sucesso!");
                        }
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nOpção Inválida");
                Voltar(1000);
                this.AvaliarEspecifico(artista, opcao);
            }
        }
    }
}