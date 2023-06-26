using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ScreenSound2
{
    public class Podcast
    {
        //construtor
        public Podcast(string host, string nome)
        {
            Host = host;
            Nome = nome;
        }

        //atributos
        private List<Episodio> episodios = new();
        public string Host { get; }
        public string Nome { get; }
        public int TotalEpisodios => episodios.Count + 1;

        //métodos
        public void AddEpisodios(Episodio episodio)
        {
            episodios.Add(episodio);
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"\nO podcast {Nome} é hosteado por {Host}");
            Console.WriteLine($"Lista de episódios ({episodios.Count()}):");
            episodios.ForEach(x => Console.WriteLine($"Episódio {x.Ordem}: {x.Titulo}"));
        }
    }
}