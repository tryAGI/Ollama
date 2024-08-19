
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
            typeof(global::OpenApiGenerator.JsonConverters.ResponseFormatJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.ResponseFormatNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.MessageRoleJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.MessageRoleNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.ToolTypeJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.ToolTypeNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.DoneReasonEnumJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.DoneReasonEnumNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.CreateModelStatusEnumJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.CreateModelStatusEnumNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PullModelStatusEnumJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PullModelStatusEnumNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PushModelResponseStatusJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PushModelResponseStatusNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.DoneReasonJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.CreateModelStatusJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PullModelStatusJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.AnyOfJsonConverterFactory2),
        })]

    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.JsonSerializerContextTypes))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}