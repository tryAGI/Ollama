
#if !NET6_0_OR_GREATER
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class OpenApiGeneratorPolyfills
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static global::System.Threading.Tasks.Task<string> ReadAsStringAsync(
            this global::System.Net.Http.HttpContent content,
            global::System.Threading.CancellationToken cancellationToken)
        {
            content = content ?? throw new global::System.ArgumentNullException(nameof(content));
            return content.ReadAsStringAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static global::System.Threading.Tasks.Task<global::System.IO.Stream> ReadAsStreamAsync(
            this global::System.Net.Http.HttpContent content,
            global::System.Threading.CancellationToken cancellationToken)
        {
            content = content ?? throw new global::System.ArgumentNullException(nameof(content));
            return content.ReadAsStreamAsync();
        }
    }
}
#endif