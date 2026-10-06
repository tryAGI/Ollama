
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Option keys mapped to descriptions, or null for a bare label. Keys must not be blank; ties follow the model's option order. The option limit depends on the model.
    /// </summary>
    public sealed partial class SystemOneChoiceQuestionCriteria
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

    }
}