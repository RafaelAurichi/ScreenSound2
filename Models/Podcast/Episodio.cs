using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2.Models.Podcast
{
    public class Episodio
    {
        //construtor
        public Episodio(string titulo, Podcast podcast)
        {
            Titulo = titulo;
            Podcast = podcast;
            Ordem = podcast.TotalEpisodios;

            podcast.AddEpisodios(this);
        }

        //atributos
        List<string> convidados = new();
        public string Titulo { get; }
        public Podcast Podcast { get; }
        public int DuracaoEp { get; set; }
        public int Ordem { get; }

        //metodos
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
