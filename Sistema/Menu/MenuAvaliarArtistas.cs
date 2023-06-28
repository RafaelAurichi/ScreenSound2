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

            Console.Write("Digite o nome da banda que deseja avaliar: ");
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
                if (listaArtistas.ContainsKey(nomeArtista))
                {
                    try
                    {
                        Console.Write("Digite a nota: ");
                        double nota = double.Parse(Console.ReadLine()!);

                        listaArtistas[nomeArtista].AddNotas(nota);
                        Console.WriteLine($"A nota {nota} foi registrada para a banda {nomeArtista} com sucesso!");
                        Console.WriteLine("\nClique qualquer tecla para voltar.");
                        Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nOpção Inválida");
                        Voltar(1000);
                        this.Executar(listaArtistas);
                    }
                }
            }

            Voltar(200);
        }
    }
}
