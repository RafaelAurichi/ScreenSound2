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
    }
}
