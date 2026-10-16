
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Named questions about the shared state. Answers are not passed to later questions. Cloud models accept names of up to 100 ASCII letters, digits, `_`, `.`, or `-`.
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