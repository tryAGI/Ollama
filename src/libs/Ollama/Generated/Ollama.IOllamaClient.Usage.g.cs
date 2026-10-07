#nullable enable

namespace Ollama
{
    public partial interface IOllamaClient
    {
        /// <summary>
        /// Cloud usage<br/>
        /// Usage statistics for cloud inference, web search, and web fetch.
        /// </summary>
        /// <param name="range">
        /// Default Value: 7d
        /// </param>
        /// <param name="scope">
        /// Default Value: self
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.UsageResponse> UsageAsync(
            global::Ollama.UsageRange? range = default,
            global::Ollama.UsageScope? scope = default,
            global::Ollama.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Cloud usage<br/>
        /// Usage statistics for cloud inference, web search, and web fetch.
        /// </summary>
        /// <param name="range">
        /// Default Value: 7d
        /// </param>
        /// <param name="scope">
        /// Default Value: self
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Ollama.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Ollama.AutoSDKHttpResponse<global::Ollama.UsageResponse>> UsageAsResponseAsync(
            global::Ollama.UsageRange? range = default,
            global::Ollama.UsageScope? scope = default,
            global::Ollama.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}