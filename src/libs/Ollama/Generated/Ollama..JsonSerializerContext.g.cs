
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[] 
        { 
            typeof(global::Ollama.JsonConverters.GenerateRequestThinkJsonConverter),
            typeof(global::Ollama.JsonConverters.GenerateRequestThinkNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.ChatMessageRoleJsonConverter),
            typeof(global::Ollama.JsonConverters.ChatMessageRoleNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.ToolDefinitionTypeJsonConverter),
            typeof(global::Ollama.JsonConverters.ToolDefinitionTypeNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.ChatRequestFormatEnumJsonConverter),
            typeof(global::Ollama.JsonConverters.ChatRequestFormatEnumNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.ChatRequestThinkJsonConverter),
            typeof(global::Ollama.JsonConverters.ChatRequestThinkNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.ChatResponseMessageRoleJsonConverter),
            typeof(global::Ollama.JsonConverters.ChatResponseMessageRoleNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),
            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, object>),
            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<bool?, global::Ollama.GenerateRequestThink?>),
            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, double?>),
            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<global::Ollama.ChatRequestFormatEnum?, object>),
            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<bool?, global::Ollama.ChatRequestThink?>),
            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, double?>),
            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),
            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),
            typeof(global::Ollama.JsonConverters.UnixTimestampJsonConverter),
        })]

    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.JsonSerializerContextTypes))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}