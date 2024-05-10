using System.Net.Http;

namespace Ollama;

/// <summary>
/// Class providing methods for API access.
/// </summary>
public partial class OllamaApi
{
    /// <summary>
    /// Sets the selected apiKey as a default header for the HttpClient.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="httpClient"></param>
    public OllamaApi(string apiKey, HttpClient httpClient)// : this(httpClient)
    {
        apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
    }
}
