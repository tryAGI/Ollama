
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class WebFetchResponse
    {
        /// <summary>
        /// Title of the fetched page
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Extracted page content
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("content")]
        public string? Content { get; set; }

        /// <summary>
        /// Links found on the page
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("links")]
        public global::System.Collections.Generic.IList<string>? Links { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="WebFetchResponse" /> class.
        /// </summary>
        /// <param name="title">
        /// Title of the fetched page
        /// </param>
        /// <param name="content">
        /// Extracted page content
        /// </param>
        /// <param name="links">
        /// Links found on the page
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public WebFetchResponse(
            string? title,
            string? content,
            global::System.Collections.Generic.IList<string>? links)
        {
            this.Title = title;
            this.Content = content;
            this.Links = links;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebFetchResponse" /> class.
        /// </summary>
        public WebFetchResponse()
        {
        }
    }
}