
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Option keys mapped to descriptions. A null description uses the key itself. Keys must not be blank; ties select the first option in request order.
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