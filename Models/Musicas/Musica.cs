using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ScreenSound2.Models.Musicas
{
    public class Musica
    {
        //construtor
        public Musica(Artista artista, string nome, string genero)
        {
            Artista = artista;
            Nome = nome;
            Genero = genero;

            artista.AddMusic(this);
        }

        public Musica(Artista artista, Album album, string nome, string genero)
        {
            Artista = artista;
            Nome = nome;
            Genero = genero;
            Album = album;

            artista.AddMusic(this);
            album.AddMusicas(this);
        }

        //atributos
        public string Nome { get; }
        public Artista Artista { get; }
        public Album Album { get; }
        public int Duracao { get; set; }
        public bool Disponivel { get; set; }
        public string Genero { get; }

        //métodos
        public void DescResumida()
        {
            string str = Album == null ?
                $"\nA música {Nome} é do(a) artista {Artista.Nome}." : $"\nA música {Nome} é do álbum {Album.Nome} do(a) artista {Artista.Nome}.";
            
            Console.WriteLine(str); 
        }

        public void ExibirFichaTecnica()
        {
            Console.WriteLine($"\nNome: {Nome}");
            Console.WriteLine($"Artista: {Artista.Nome}");

            if (Album != null) 
            { 
                Console.WriteLine($"Álbum: {Album.Nome}"); 
            }

            Console.WriteLine($"Duração: {Duracao}s\n");

            if (Disponivel)
            {
                Console.WriteLine("Ouça Agora!");
            }
            else
            {
                Console.WriteLine("Adquiria o plano Screen Sound+");
            }
        }
    }
}
