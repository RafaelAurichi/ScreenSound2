using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ScreenSound2.Models.Musicas
{
    public class Album
    {
        //construtor
        public Album(Artista artista, string nome)
        {
            Artista = artista;
            Nome = nome;

            artista.AddAlbum(this); 
        }

        //atributos
        private List<Musica> musicas = new();
        public string Nome { get; }
        public Artista Artista { get; }
        public int DuracaoAlbum => musicas.Sum(x => x.Duracao);

        //métodos
        public void AddMusicas(Musica musica) //can be set in the music constructor
        {
            if(musicas.Contains(musica)) { }
            else
            {
                musicas.Add(musica);
            }
        }

        public void ExibirMusicas()
        {
            Console.WriteLine($"\nLista de músicas do álbum {Nome} do(a) artista {Artista.Nome}:");

            musicas.ForEach(x => Console.WriteLine($"Música: {x.Nome}"));

            Console.WriteLine($"Duração do álbum {Nome}: {DuracaoAlbum}s\n");

            //*******************FUNCAO PARA SELECIONAR ALBUM E VER SUA LISTA DE MUSICAS
        }
    }
}
