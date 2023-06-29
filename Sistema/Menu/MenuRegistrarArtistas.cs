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
                Artista artista = new(nomeArtista);
                listaArtistas.Add(artista.Nome, artista);

                Console.WriteLine($"\nAguarde...");

                //API OpenAI
                var client = new OpenAIAPI("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");
                var chat = client.Chat.CreateConversation();
                chat.AppendSystemMessage($"Faça uma breve descrição de 1 parágrafo da banda ou artista {nomeArtista}. Adote um estilo informal.");
                string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();

                artista.Resumo = resposta;

                Console.WriteLine($"A banda {nomeArtista} foi registrada com sucesso!");
                Console.WriteLine("\nClique qualquer tecla para voltar.");
                Console.ReadLine();
            }

            Voltar(200);
        }
    }
}
