using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ScreenSound2.Models.Musicas
{
    internal class Musica : IAvaliavel
    {
        //construtor
        public Musica(Artista artista, string nome, string genero)
        {
            Artista = artista;
            Nome = nome;
            Genero = genero;

            artista.AddMusic(this);
            QuantMusicas++;
        }

        public Musica(Album album, string nome, string genero)
        {
            Artista = album.Artista;
            Nome = nome;
            Genero = genero;
            Album = album;

            Artista.AddMusic(this);
            album.AddMusicas(this);
            QuantMusicas++;
        }


        //atributos
        private List<double> notas = new();

        public static int QuantMusicas { get; private set; }
        public string Nome { get; }
        public Artista Artista { get; }
        public Album Album { get; }
        public int DuracaoSeg { get; set; }
        public bool Disponivel { get; set; }
        public string Genero { get; }


        //métodos
        public void AddNotas(List<double> numbers)
        {
            foreach (double x in numbers)
            {
                if (x < 0) { notas.Add(0); }
                else if (x > 10) { notas.Add(10); }
                else { notas.Add(x); }
            }
        }

        public void AddNotas(double nota)
        {
            if (nota < 0) { notas.Add(0); }
            else if (nota > 10) { notas.Add(10); }
            else { notas.Add(nota); }
        }

        public double AverageDegree() => notas.Count == 0 ? 0 : notas.Average();

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

            int minutos = DuracaoSeg / 60;
            int horas = minutos / 60;
            if (horas > 0)
            {
                Console.WriteLine($"Duração da música {Nome}: {horas}:{minutos % 60} horas");
            }
            else
            {
                Console.WriteLine($"Duração da música {Nome}: {minutos}:{DuracaoSeg % 60} minutos");
            }

            switch (Disponivel)
            {
                case true:
                    Console.WriteLine("\nOuça Agora!");
                    break;

                case false:
                    Console.WriteLine("\nAdquiria o plano Screen Sound+");
                    break;

                default:
                    Console.WriteLine("\nAdquiria o plano Screen Sound+");
                    break;
            }
        }
    }
}
