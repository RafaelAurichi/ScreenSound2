using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ScreenSound2.Models.Musicas
{
    internal class Album : IAvaliavel
    {
        //construtor
        public Album(Artista artista, string nome)
        {
            Artista = artista;
            Nome = nome;

            artista.AddAlbum(this);
            QuantAlbuns++;
        }


        //atributos
        private List<double> notas = new();
        private List<Musica> musicas = new();

        public Artista Artista { get; }
        public static int QuantAlbuns { get; private set; }
        public string Nome { get; }
        public int DuracaoAlbumSeg => musicas.Sum(x => x.DuracaoSeg);


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
            Console.WriteLine($"\nLista de músicas do álbum {Nome} do(a) artista {Artista.Nome}:\n");

            foreach (Musica x in musicas)
            {
                int minutosMusica = x.DuracaoSeg / 60;
                int horasMusica = minutosMusica / 60;
                if (horasMusica > 0)
                {
                    Console.WriteLine($"Música: {x.Nome} ({horasMusica}:{minutosMusica % 60} horas)");
                }
                else
                {
                    Console.WriteLine($"Música: {x.Nome} ({minutosMusica}:{x.DuracaoSeg % 60} minutos)");
                }
            }

            int minutos = DuracaoAlbumSeg / 60;
            int horas = minutos / 60;
            if (horas > 0)
            {
                Console.WriteLine($"\nDuração do álbum {Nome}: {horas}:{minutos % 60} horas\n");
            }
            else
            {
                Console.WriteLine($"\nDuração do álbum {Nome}: {minutos}:{DuracaoAlbumSeg % 60} minutos\n");
            }
        }
    }
}
