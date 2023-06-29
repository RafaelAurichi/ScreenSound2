using ScreenSound2.Models.Musicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2.Sistema.Menu
{
    internal class MenuExibirArtistas : Menu
    {
        public override void Executar(Dictionary<string, Artista> listaArtistas)
        {
            CabecalhoOpcoes(@"
                 █     ▀  █▀▀ ▀▀█▀▀ █▀▀█ 　 █▀▀▄ █▀▀ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
                 █    ▀█▀ ▀▀█   █   █▄▄█ 　 █  █ █▀▀ 　 █▀▀▄ █▄▄█ █  █ █  █ █▄▄█ ▀▀█ 
                 █▄▄█ ▀▀▀ ▀▀▀   ▀   ▀  ▀ 　 ▀▀▀  ▀▀▀ 　 ▀▀▀  ▀  ▀ ▀  ▀ ▀▀▀  ▀  ▀ ▀▀▀  
            ");

            List<string> artistas = new();
            int i = 1;
            foreach (string x in listaArtistas.Keys)
            {
                Console.WriteLine($"Banda {i}: {x}");
                artistas.Add(x);
                i++;
            }

            try
            {
                Console.Write("\nDigite o número da banda caso queira ver mais opções: ");
                int opcao = int.Parse(Console.ReadLine());

                if (opcao == 0)
                {
                    Voltar(200);
                }
                else if (artistas.Contains(artistas[opcao - 1]))
                {
                    string artistaEscolhido = artistas[opcao - 1];
                    MenuExibirDetalhesBanda menuExibirDetalhesBanda = new(artistaEscolhido);
                    menuExibirDetalhesBanda.Executar(listaArtistas);
                }
                else
                {
                    Console.WriteLine("\nOpção Inválida");
                    Voltar(1000);
                    this.Executar(listaArtistas);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nOpção Inválida");
                Voltar(1000);
                this.Executar(listaArtistas);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("\nOpção Inválida");
                Voltar(1000);
                this.Executar(listaArtistas);
            }
        }
    }
}
