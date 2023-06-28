using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2.Models.Podcast
{
    internal class Episodio : IAvaliavel
    {
        //construtor
        public Episodio(string titulo, Podcast podcast)
        {
            Titulo = titulo;
            Podcast = podcast;
            Ordem = podcast.TotalEpisodios;

            podcast.AddEpisodios(this);
            QuantEpisodios++;
        }


        //atributos
        private List<double> notas = new();
        List<string> convidados = new();

        public static int QuantEpisodios { get; private set; }
        public string Titulo { get; }
        public Podcast Podcast { get; }
        public int DuracaoEp { get; set; }
        public int Ordem { get; }


        //metodos
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

        public void Resumo()
        {
            Console.WriteLine($"\nResumo do episódio {Titulo} do podcast {Podcast.Nome}:\n" +
                    $"Duração: {DuracaoEp} minutos\n" +
                    $"Convidados: {string.Join(", ", convidados)}");
        }

        public void AddConvidado(string convidado)
        {
            convidados.Add(convidado);
        }
    }
}
