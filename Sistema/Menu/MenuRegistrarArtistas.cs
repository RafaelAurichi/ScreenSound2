using ScreenSound2.Models.Musicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2.Sistema.Menu
{
    internal class MenuRegistrarArtistas : Menu
    {
        public override void Executar(Dictionary<string, Artista> listaArtistas)
        {
            CabecalhoOpcoes(@"
                 █▀▀█ █▀▀ █▀▀▀  ▀  █▀▀ ▀▀█▀▀ █▀▀█ █▀▀█ 　 █▀▀▄ █▀▀ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
                 █▄▄▀ █▀▀ █ ▀█ ▀█▀ ▀▀█   █   █▄▄▀ █  █ 　 █  █ █▀▀ 　 █▀▀▄ █▄▄█ █  █ █  █ █▄▄█ ▀▀█ 
                 █  █ ▀▀▀ ▀▀▀▀ ▀▀▀ ▀▀▀   ▀   ▀ ▀▀ ▀▀▀▀ 　 ▀▀▀  ▀▀▀ 　 ▀▀▀  ▀  ▀ ▀  ▀ ▀▀▀  ▀  ▀ ▀▀▀
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
    }
}
