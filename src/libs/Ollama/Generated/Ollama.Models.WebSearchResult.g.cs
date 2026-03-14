
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class WebSearchResult
    {
        /// <summary>
        /// Page title of the result
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Resolved URL for the result
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Extracted text content snippet
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("content")]
        public string? Content { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSearchResult" /> class.
        /// </summary>
        /// <param name="title">
        /// Page title of the result
        /// </param>
        /// <param name="url">
        /// Resolved URL for the result
        /// </param>
        /// <param name="content">
        /// Extracted text content snippet
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public WebSearchResult(
            string? title,
            string? url,
            string? content)
        {
            this.Title = title;
            this.Url = url;
            this.Content = content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSearchResult" /> class.
        /// </summary>
        public WebSearchResult()
        {
        }
    }
}