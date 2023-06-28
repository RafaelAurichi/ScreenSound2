using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ScreenSound2.Models.Musicas
{
    internal class Artista : IAvaliavel
    {
        //construtor
        public Artista(string nome)
        {
            Nome = nome;

            QuantArtistas++;
        }


        //atributos
        private Dictionary<string, Album> albuns = new();
        private Dictionary<string, Musica> musicas = new();
        private List<double> notas = new();

        public static int QuantArtistas { get; private set; }
        public string Nome { get; }
        public int QuantAlbuns => albuns.Count;
        public int QuantMusicas => musicas.Count;


        //métodos
        public bool GetAlbum(string nome)
        {
            if (albuns.ContainsKey(nome))
            {
                albuns[nome].ExibirMusicas();
                return true;
            }
            else
            {
                Console.WriteLine($"\nO álbum {nome} não foi encontrado!");
                return false;
            }
        }

        public void GetMusica(string nome)
        {
            if (musicas.ContainsKey(nome))
            {
                musicas[nome].ExibirFichaTecnica();
            }
            else
            {
                Console.WriteLine($"\nA música {nome} não foi encontrada!");
            }
        }

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

        public void AddMusic(Musica music) => musicas.Add(music.Nome, music); //it's set when some Music object is created

        public void AddAlbum(Album album) => albuns.Add(album.Nome, album); //it's set when some Album object is created

        public double AverageDegree() => notas.Count == 0 ? 0 : notas.Average();

        public void ExibirDiscografia()
        {
            Console.WriteLine($"\nDiscografia do(a) artista {Nome}:\n");
            if (QuantAlbuns == 0)
            {
                Console.WriteLine($"O artista ou banda {Nome} não possui álbuns cadastrados!");
            }
            else
            {
                foreach (Album x in albuns.Values)
                {
                    int minutos = x.DuracaoAlbumSeg / 60;
                    int horas = minutos / 60;
                    if (horas > 0)
                    {
                        Console.WriteLine($"Álbum: {x.Nome} ({horas}:{minutos % 60} horas)");
                    }
                    else
                    {
                        Console.WriteLine($"Álbum: {x.Nome} ({minutos}:{x.DuracaoAlbumSeg % 60} minutos)");
                    }
                }
            }

            Console.WriteLine();

            Console.WriteLine($"\nMúsicas do(a) artista {Nome}:\n");
            if (QuantMusicas == 0)
            {
                Console.WriteLine($"O artista ou banda {Nome} não possui músicas cadastradas!");
            }
            else
            { 
                foreach (Musica x in musicas.Values)
                {
                    int minutos = x.DuracaoSeg / 60;
                    int horas = minutos / 60;
                    if (horas > 0)
                    {
                        Console.WriteLine($"Música: {x.Nome} ({horas}:{minutos % 60} horas)");
                    }
                    else
                    {
                        Console.WriteLine($"Música: {x.Nome} ({minutos}:{x.DuracaoSeg % 60} minutos)");
                    }
                }
            }
        }

        //public void ExibirMusicas()
        //{
        //    if (QuantMusicas == 0)
        //    {
        //        Console.WriteLine($"O artista ou banda {Nome} não possui músicas cadastraas!");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Músicas do(a) artista {Nome}:");

        //        foreach (Musica x in musicas)
        //        {
        //            int minutos = x.DuracaoSeg / 60;
        //            int horas = minutos / 60;
        //            if (horas > 0)
        //            {
        //                Console.WriteLine($"Música: {x.Nome} ({horas}:{minutos % 60} horas)\n");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Música: ({minutos}:{x.DuracaoSeg % 60} minutos)\n");
        //            }
        //        }
        //    }
        //}
    }
}
