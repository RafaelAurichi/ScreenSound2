using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2
{
    public class Episodio
    {
        //construtor
        public Episodio(string titulo, Podcast podcast) 
        {
            Titulo = titulo;
            Podcast = podcast;
            Ordem = podcast.TotalEpisodios;
        }

        //atributos
        List<string> convidados = new();
        public string Titulo { get; }
        public Podcast Podcast { get; }
        public int DuracaoEp { get; set; }
        public int Ordem { get; }
        public string Resumo
        { 
            get
            {
                return $"Resumo do episódio {Titulo}:\n" +
                    $"Duração: {DuracaoEp} minutos\n" +
                    $"Convidados: {String.Join(", ", convidados)}";
            }
        }

        //metodos
        public void AddConvidado(string convidado)
        {
            convidados.Add(convidado);
        }
    }
}
