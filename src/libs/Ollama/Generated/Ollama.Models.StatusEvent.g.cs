
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class StatusEvent
    {
        /// <summary>
        /// Human-readable status message
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Content digest associated with the status, if applicable
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("digest")]
        public string? Digest { get; set; }

        /// <summary>
        /// Total number of bytes expected for the operation
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("total")]
        public long? Total { get; set; }

        /// <summary>
        /// Number of bytes transferred so far
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("completed")]
        public long? Completed { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusEvent" /> class.
        /// </summary>
        /// <param name="status">
        /// Human-readable status message
        /// </param>
        /// <param name="digest">
        /// Content digest associated with the status, if applicable
        /// </param>
        /// <param name="total">
        /// Total number of bytes expected for the operation
        /// </param>
        /// <param name="completed">
        /// Number of bytes transferred so far
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public StatusEvent(
            string? status,
            string? digest,
            long? total,
            long? completed)
        {
            this.Status = status;
            this.Digest = digest;
            this.Total = total;
            this.Completed = completed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusEvent" /> class.
        /// </summary>
        public StatusEvent()
        {
        }
    }
}