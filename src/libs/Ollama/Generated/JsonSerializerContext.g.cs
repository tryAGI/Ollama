
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
            typeof(global::Ollama.JsonConverters.ResponseFormatEnumJsonConverter),
            typeof(global::Ollama.JsonConverters.ResponseFormatEnumNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.MessageRoleJsonConverter),
            typeof(global::Ollama.JsonConverters.MessageRoleNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.ToolTypeJsonConverter),
            typeof(global::Ollama.JsonConverters.ToolTypeNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.DoneReasonEnumJsonConverter),
            typeof(global::Ollama.JsonConverters.DoneReasonEnumNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.CreateModelStatusEnumJsonConverter),
            typeof(global::Ollama.JsonConverters.CreateModelStatusEnumNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.CapabilityJsonConverter),
            typeof(global::Ollama.JsonConverters.CapabilityNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.PullModelStatusEnumJsonConverter),
            typeof(global::Ollama.JsonConverters.PullModelStatusEnumNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.PushModelResponseStatusJsonConverter),
            typeof(global::Ollama.JsonConverters.PushModelResponseStatusNullableJsonConverter),
            typeof(global::Ollama.JsonConverters.ResponseFormatJsonConverter),
            typeof(global::Ollama.JsonConverters.DoneReasonJsonConverter),
            typeof(global::Ollama.JsonConverters.CreateModelStatusJsonConverter),
            typeof(global::Ollama.JsonConverters.PullModelStatusJsonConverter),
            typeof(global::Ollama.JsonConverters.AnyOfJsonConverter<string, global::Ollama.PushModelResponseStatus?>),
            typeof(global::Ollama.JsonConverters.UnixTimestampJsonConverter),
        })]

    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.JsonSerializerContextTypes))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}