﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ScreenSound2
{
    public class Album
    {
        //construtor
        public Album(Artista artista, string nome)
        {
            Artista = artista;
            Nome = nome;
        }

        //atributos
        private List<Musica> musicas = new();
        public string Nome { get; }
        public Artista Artista { get; }
        public int DuracaoAlbum => musicas.Sum(x => x.Duracao);

        //métodos
        public void AdicionarMusicas(Musica musica) => musicas.Add(musica);
        public void ExibirMusicas()
        {
            Console.WriteLine($"\nLista de músicas do álbum {Nome} do(a) artista {Artista.Nome}\n");

            musicas.ForEach(x => Console.WriteLine($"Música: {x.Nome}"));

            Console.WriteLine($"\nPara ouvir o álbum {Nome} inteiro você precisa de {DuracaoAlbum}s\n");
        }
    }
}