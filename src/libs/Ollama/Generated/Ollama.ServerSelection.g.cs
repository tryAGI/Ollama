#nullable enable

namespace Ollama
{
    /// <summary>
    /// Represents a concrete OpenAPI server option.
    /// </summary>
    public sealed class AutoSDKServer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoSDKServer"/> class.
        /// </summary>
        /// <param name="id">The stable identifier for this server option.</param>
        /// <param name="name">The display name for this server option.</param>
        /// <param name="url">The server URL.</param>
        /// <param name="description">The server description.</param>
        public AutoSDKServer(
            string id,
            string name,
            string url,
            string description)
        {
            Id = id ?? throw new global::System.ArgumentNullException(nameof(id));
            Name = name ?? string.Empty;
            Url = url ?? throw new global::System.ArgumentNullException(nameof(url));
            Description = description ?? string.Empty;
            Uri = new global::System.Uri(url, global::System.UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// Gets the stable identifier for this server option.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Gets the display name for this server option.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gets the server URL.
        /// </summary>
        public string Url { get; }
        /// <summary>
        /// Gets the server description.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Gets the parsed server URI.
        /// </summary>
        public global::System.Uri Uri { get; }
    }

    internal sealed class AutoSDKServerConfiguration
    {
        public global::System.Uri? ExplicitBaseUri { get; set; }
        public global::Ollama.AutoSDKServer? SelectedServer { get; set; }
    }
}