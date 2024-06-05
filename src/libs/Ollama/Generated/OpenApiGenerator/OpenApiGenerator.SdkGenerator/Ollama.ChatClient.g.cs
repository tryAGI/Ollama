
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Given a list of messages comprising a conversation, the model will return a response.
    /// If no httpClient is provided, a new one will be created.
    /// If no baseUri is provided, the default baseUri from OpenAPI spec will be used.
    /// </summary>
    public sealed partial class ChatClient : global::System.IDisposable
    {
        private readonly global::System.Net.Http.HttpClient _httpClient;


        /// <summary>
        /// Creates a new instance of the ChatClient.
        /// If no httpClient is provided, a new one will be created.
        /// If no baseUri is provided, the default baseUri from OpenAPI spec will be used.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="baseUri"></param>
        public ChatClient(
            global::System.Net.Http.HttpClient? httpClient = null,
            global::System.Uri? baseUri = null 
            )
        {
            _httpClient = httpClient ?? new global::System.Net.Http.HttpClient();
            _httpClient.BaseAddress ??= baseUri ?? new global::System.Uri("http://localhost:11434/api");
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}