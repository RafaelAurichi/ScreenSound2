using ScreenSound2.Models.Musicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2.Sistema.Menu
{
    internal class MenuMediaArtistas : Menu
    {
        public override void Executar(Dictionary<string, Artista> listaArtistas)
        {
            CabecalhoOpcoes(@"     
                 █▀▄▀█ █▀▀ █▀▀▄  ▀  █▀▀█ 　 █▀▀▄ █▀▀█ █▀▀ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
                 █ █ █ █▀▀ █  █ ▀█▀ █▄▄█ 　 █  █ █▄▄█ ▀▀█ 　 █▀▀▄ █▄▄█ █  █ █  █ █▄▄█ ▀▀█ 
                 █   █ ▀▀▀ ▀▀▀  ▀▀▀ ▀  ▀ 　 ▀▀▀  ▀  ▀ ▀▀▀ 　 ▀▀▀  ▀  ▀ ▀  ▀ ▀▀▀  ▀  ▀ ▀▀▀
            ");

            try
            {
                Console.Write("Digite o nome da banda que deseja ver a média: ");
                string nomeArtista = Console.ReadLine()!;

                if (string.IsNullOrEmpty(nomeArtista))
                {
                    Console.WriteLine("Opção inválida");
                    Voltar(1000);
                    this.Executar(listaArtistas);
                }
                else if (nomeArtista == "0")
                {

                }
                else
                {
                    Console.WriteLine($"A média da banda {nomeArtista} é: {listaArtistas[nomeArtista].AverageDegree()}");
                    Console.WriteLine("\nClique qualquer tecla para voltar.");
                    Console.ReadLine();
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("\nOpção Inválida");
                Menu.Voltar(1000);
                this.Executar(listaArtistas);
            }

            Voltar(200);
        }
    }
}
