using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ScreenSound2
{
    public class Musica : IGenero
    {
        //construtor
        public Musica(Artista artista, string nome) 
        {
            Artista = artista;
            Nome = nome;
        }

        //atributos
        public string Nome { get; }
        public Artista Artista { get; }
        public int Duracao { get; set; }
        public bool Disponivel { get; set; }
        public string DescResumida => $"A música {Nome} é do(a) artista {Artista}";
        public string GeneroMusical { get; set; }

        //métodos
        public void ExibirFichaTecnica()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Artista: {Artista.Nome}");
            Console.WriteLine($"Duração: {Duracao}s");
            if (Disponivel)
            {
                Console.WriteLine("Ouça Agora!");
            }
            else
            {
                Console.WriteLine("Adquiria o plano Screen Sound+");
            }
            Console.WriteLine();
        }
    }
}
