
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Named questions about the shared state. Each is scored separately against the full state and question schema; answers are not passed to later questions.
    /// </summary>
    public sealed partial class SystemOneRequestQuestions
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

    }
}