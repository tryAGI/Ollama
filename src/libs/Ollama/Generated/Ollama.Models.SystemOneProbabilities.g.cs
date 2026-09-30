
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Probabilities normalized over the supplied candidates, summing to 1 subject to floating-point precision.
    /// </summary>
    public sealed partial class SystemOneProbabilities
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

    }
}