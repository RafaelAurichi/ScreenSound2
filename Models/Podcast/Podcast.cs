using ScreenSound2.Models.Musicas;
using ScreenSound2.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ScreenSound2.Models.Podcast
{
    internal class Podcast : IAvaliavel
    {
        //construtor
        public Podcast(string host, string nome)
        {
            Host = host;
            Nome = nome;
            QuantPodcasts++;
        }


        //atributos
        private List<Episodio> episodios = new();
        List<double> notas = new();

        public static int QuantPodcasts { get; private set; }
        public string Host { get; }
        public string Nome { get; }
        public int TotalEpisodios => episodios.Count;


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

        public void AddEpisodios(Episodio episodio) //can be set in the Episode constructor
        {
            if (episodios.Contains(episodio)) { }
            else
            {
                episodios.Add(episodio);
            }
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"\nO podcast {Nome} é hosteado por {Host}");
            Console.WriteLine($"Lista de episódios ({episodios.Count}):");
            episodios.ForEach(x => Console.WriteLine($"Episódio {x.Ordem}: {x.Titulo}"));

            ////*******************FUNCAO PARA SELECIONAR EP E VER SEU RESUMO
        }
    }
}