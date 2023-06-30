using ScreenSound2.Models.Musicas;
using OpenAI_API;

namespace ScreenSound2.Sistema.Menu
{
    internal class MenuRegistrarArtistas : Menu
    {
        public override void Executar(Dictionary<string, Artista> listaArtistas)
        {
            CabecalhoOpcoes(@"
                 █▀▀█ █▀▀ █▀▀▀  ▀  █▀▀ ▀▀█▀▀ █▀▀█ █▀▀█ 　 █▀▀▄ █▀▀ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
                 █▄▄▀ █▀▀ █ ▀█ ▀█▀ ▀▀█   █   █▄▄▀ █  █ 　 █  █ █▀▀ 　 █▀▀▄ █▄▄█ █  █ █  █ █▄▄█ ▀▀█ 
                 █  █ ▀▀▀ ▀▀▀▀ ▀▀▀ ▀▀▀   ▀   ▀ ▀▀ ▀▀▀▀ 　 ▀▀▀  ▀▀▀ 　 ▀▀▀  ▀  ▀ ▀  ▀ ▀▀▀  ▀  ▀ ▀▀▀
            ");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeArtista = Console.ReadLine();

            if (string.IsNullOrEmpty(nomeArtista))
            {
                Console.WriteLine("Opção inválida");
            }
            else if (nomeArtista == "0")
            {
                Voltar(200);
            }
            else
            {
                RegistrarArtista(listaArtistas, nomeArtista);

                Console.WriteLine($"A banda {nomeArtista} foi registrada com sucesso!");
                Console.WriteLine("\nClique qualquer tecla para voltar.");
                Console.ReadLine();
            }

            Voltar(200);
        }

        public static void RegistrarArtista(Dictionary<string, Artista> listaArtistas, string nome)
        {
            Artista artista = new(nome);
            listaArtistas.Add(artista.Nome, artista);

            var ordenados = LinqFilter.LinqOrder(listaArtistas);
            listaArtistas.Clear();

            foreach (var artistaOrdenado in ordenados.Values)
            {
                listaArtistas.Add(artistaOrdenado.Nome, artista);
            }

            Console.WriteLine($"\nAguarde...");

            //API OpenAI
            var client = new OpenAIAPI("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");
            var chat = client.Chat.CreateConversation();
            chat.AppendSystemMessage($"Faça uma breve descrição de 2 linhas da banda ou artista {nome}. Adote um estilo informal.");
            string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();

            artista.Resumo = resposta;
        }
    }
}
