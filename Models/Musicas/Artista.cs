using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2.Models.Musicas
{
    public class Artista
    {
        //construtor
        public Artista(string nome)
        {
            Nome = nome;
        }

        //atributos
        private List<Album> albuns = new();
        private List<int> notas = new();
        private List<Musica> musicas = new();
        public string Nome { get; }

        //métodos
        public void AddNotas(int nota) => notas.Add(nota);
        public void AddMusic(Musica music) => musicas.Add(music); //it's set when some Music object is created
        public void AddAlbum(Album album) => albuns.Add(album); //it's set when some Album object is created
        public double AverageDegree() => notas.Average();
        public void ExibirDiscografia()
        {
            Console.WriteLine($"Discografia do(a) artista {Nome}");
            albuns.ForEach(x => Console.WriteLine($"{albuns.IndexOf(x) + 1}° Álbum: {x.Nome} ({x.DuracaoAlbum}s)"));

            //*******************FUNCAO PARA SELECIONAR ALBUM E VER SUA LISTA DE MUSICAS
        }
    }
}
