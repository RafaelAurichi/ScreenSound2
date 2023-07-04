using ScreenSound2.Models.Musicas;

namespace ScreenSound2.Sistema
{
    internal class Linq
    {
        public static Dictionary<string, Artista> LinqDistinctArtista(List<Artista> artistas)
        {
            var distinct = artistas.DistinctBy(artista => artista.Nome).ToArray();
            var ordenados = distinct.OrderBy(distinct => distinct.Nome);

            Dictionary<string, Artista> artistasFiltrados = new();

            foreach (var artista in ordenados)
            {
                artistasFiltrados.Add(artista.Nome, artista);
            }

            return artistasFiltrados;
        }

        public static Dictionary<string, Artista> LinqOrder(Dictionary<string, Artista> listaArtistas)
        {
            
            var ordenados = listaArtistas.OrderBy(listaArtistas => listaArtistas.Key);

            Dictionary<string, Artista> artistasOrdenados = new();

            foreach (var artista in ordenados)
            {
                artistasOrdenados.Add(artista.Key, artista.Value);
            }

            return artistasOrdenados;
        }
    }
}
