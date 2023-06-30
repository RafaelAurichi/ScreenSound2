using ScreenSound2.Models.Musicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2.Sistema.Menu
{
    internal class Menu
    {
        public static void CabecalhoOpcoes(string str)
        {
            Console.Clear();
            Console.WriteLine(str);
            Console.WriteLine("Caso deseje voltar, digite 0.\n");
        }

        public static void Voltar(int time)
        {
            Thread.Sleep(time);
            Console.Clear();
        }

        public virtual void Executar(Dictionary<string, Artista> listaArtistas) { }

        public static void ListarArtistas(Dictionary<string, Artista> listaArtistas)
        {
            Console.WriteLine("Lista de artistas Cadastrados: \n");

            var ordenados = listaArtistas.OrderBy(listaArtistas => listaArtistas.Key);

            int i = 1;
            foreach (string x in listaArtistas.Keys)
            {
                Console.WriteLine($"Banda {i}: {x}");
                i++;
            }
            Console.WriteLine("\n**Dica: use o atalho 'Ctrl + F' para ajudar na busca!**");
        }
    }
}
