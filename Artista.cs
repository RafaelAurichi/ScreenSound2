using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2
{
    public class Artista
    {
        //construtor
        public Artista(string nome) 
        {
            Nome = nome;
        }

        //atributos
        private List<Album> albuns = new List<Album>();
        public string Nome { get; }

        //métodos
        public void AddAlbum(Album album) => albuns.Add(album);
        public void ExibirDiscografia()
        {
            Console.WriteLine($"Discografia da banda {Nome}");
            albuns.ForEach(x =>  Console.WriteLine($"Álbum: {x.Nome} ({x.DuracaoAlbum}s)"));
        }

    }
}
