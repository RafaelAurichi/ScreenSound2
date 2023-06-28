using ScreenSound2.Models.Musicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ScreenSound2.Sistema.Menu
{
    internal class MenuExibirDetalhesBanda : Menu
    {
        //construtor
        public MenuExibirDetalhesBanda(string artistaEscolhido)
        {
            ArtistaEscolhido = artistaEscolhido;
        }


        //atributos
        private string ArtistaEscolhido;


        //metodos
        public override void Executar(Dictionary<string, Artista> listaArtistas)
        {
            CabecalhoOpcoes(@"
                █▀▀▄  ▀  █▀▀ █▀▀ █▀▀█ █▀▀▀ █▀▀█ █▀▀█ █▀▀  ▀  █▀▀█ 　  █▀▀█ █▀▀█ ▀▀█▀▀  ▀  █▀▀ ▀▀█▀▀ █▀▀█ 
                █  █ ▀█▀ ▀▀█ █   █  █ █ ▀█ █▄▄▀ █▄▄█ █▀▀ ▀█▀ █▄▄█ 　  █▄▄█ █▄▄▀   █   ▀█▀ ▀▀█   █   █▄▄█ 
                █▄▄▀ ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀▀▀▀ ▀ ▀▀ ▀  ▀ ▀   ▀▀▀ ▀  ▀ 　  █  █ ▀ ▀▀   ▀   ▀▀▀ ▀▀▀   ▀   ▀  ▀
            ");

            listaArtistas[ArtistaEscolhido].ExibirDiscografia();

            try
            {

                if (listaArtistas[ArtistaEscolhido].QuantAlbuns != 0 & listaArtistas[ArtistaEscolhido].QuantMusicas != 0)
                {
                    Console.Write("\nCaso queira exibir detalhes de algum álbum ou música específico(a).\n" +
                    "Digite 1 para álbum ou 2 para música: ");
                    int opcao = int.Parse(Console.ReadLine());

                    if (opcao == 1)
                    {
                        DetalhesAlbum(listaArtistas);
                    }
                    else if (opcao == 2)
                    {
                        DetalhesMusica(listaArtistas);
                    }
                    else if (opcao == 0)
                    {
                        MenuExibirArtistas menuExibirArtistas = new();
                        menuExibirArtistas.Executar(listaArtistas);
                    }
                    else
                    {
                        Console.WriteLine("\nOpção Inválida");
                        Voltar(1000);
                        this.Executar(listaArtistas);
                    }
                }
                else if(listaArtistas[ArtistaEscolhido].QuantMusicas != 0)
                {
                    Console.Write("\nDigite 1 caso queira exibir detalhes de alguma música específica: ");
                    int opcao = int.Parse(Console.ReadLine());

                    if (opcao == 1)
                    {
                        DetalhesMusica(listaArtistas);
                    }
                    else if (opcao == 0)
                    {
                        MenuExibirArtistas menuExibirArtistas = new();
                        menuExibirArtistas.Executar(listaArtistas);
                    }
                    else
                    {
                        Console.WriteLine("\nOpção Inválida");
                        Voltar(1000);
                        this.Executar(listaArtistas);
                    }
                }
                else if (listaArtistas[ArtistaEscolhido].QuantAlbuns != 0)
                {
                    Console.Write("\nDigite 1 caso queira exibir detalhes de algum álbum específico: ");
                    int opcao = int.Parse(Console.ReadLine());

                    if (opcao == 1)
                    {
                        DetalhesAlbum(listaArtistas);
                    }
                    else if (opcao == 0)
                    {
                        MenuExibirArtistas menuExibirArtistas = new();
                        menuExibirArtistas.Executar(listaArtistas);
                    }
                    else
                    {
                        Console.WriteLine("\nOpção Inválida");
                        Voltar(1000);
                        this.Executar(listaArtistas);
                    }
                }
                else
                {
                    Console.WriteLine("\nClique qualquer tecla para voltar.");
                    Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nOpção Inválida");
                Voltar(1000);
                this.Executar(listaArtistas);
            }

            Voltar(1000);
        }

        public void DetalhesAlbum(Dictionary<string, Artista> listaArtistas)
        {
            Console.Write("Digite o nome do álbum que deseja detalhar: ");
            string album = Console.ReadLine();

            Console.Clear();
            CabecalhoOpcoes(@"
                █▀▀▄ █▀▀ ▀▀█▀▀ █▀▀█ █   █  █ █▀▀ █▀▀ 　  █▀▀█ █   █▀▀▄ █  █ █▀▄▀█ 
                █  █ █▀▀   █   █▄▄█ █   █▀▀█ █▀▀ ▀▀█ 　  █▄▄█ █   █▀▀▄ █  █ █ ▀ █ 
                █▄▄▀ ▀▀▀   ▀   ▀  ▀ ▀▀▀ ▀  ▀ ▀▀▀ ▀▀▀ 　  █  █ ▀▀▀ ▀▀▀  ▀▀▀▀ ▀   ▀
            ");
            listaArtistas[ArtistaEscolhido].GetAlbum(album);
            Console.Write("\nClique qualquer tecla para voltar: ");
            Console.ReadLine();
            this.Executar(listaArtistas);
        }

        public void DetalhesMusica(Dictionary<string, Artista> listaArtistas)
        {
            Console.WriteLine("Digite o nome da música que deseja detalhar: ");
            string musica = Console.ReadLine();

            Console.Clear();
            CabecalhoOpcoes(@"
                █▀▀▄ █▀▀ ▀▀█▀▀ █▀▀█ █   █  █ █▀▀ █▀▀ 　   █▀▄▀█ █  █ █▀▀  ▀  █▀▀ █▀▀█
                █  █ █▀▀   █   █▄▄█ █   █▀▀█ █▀▀ ▀▀█ 　   █ █ █ █  █ ▀▀█ ▀█▀ █   █▄▄█ 
                █▄▄▀ ▀▀▀   ▀   ▀  ▀ ▀▀▀ ▀  ▀ ▀▀▀ ▀▀▀ 　   █   █ ▀▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀ ▀  ▀
            ");
            listaArtistas[ArtistaEscolhido].GetMusica(musica);
            Console.Write("\nClique qualquer tecla para voltar: ");
            Console.ReadLine();
            this.Executar(listaArtistas);
        }
        
    }
}
