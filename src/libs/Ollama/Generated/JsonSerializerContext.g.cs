
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace Ollama
{
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[] 
        { 
            typeof(global::OpenApiGenerator.JsonConverters.ResponseFormatJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.ResponseFormatNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.GenerateChatCompletionResponseDoneReasonJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.GenerateChatCompletionResponseDoneReasonNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.DoneReasonVariant2JsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.DoneReasonVariant2NullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.MessageRoleJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.MessageRoleNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.ToolTypeJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.ToolTypeNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.CreateModelResponseStatusJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.CreateModelResponseStatusNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.CreateModelStatusVariant2JsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.CreateModelStatusVariant2NullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PullModelResponseStatusJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PullModelResponseStatusNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PullModelStatusVariant2JsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PullModelStatusVariant2NullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PushModelResponseStatusJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PushModelResponseStatusNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PushModelStatusVariant2JsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PushModelStatusVariant2NullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.AnyOfJsonConverterFactory2),
            typeof(global::OpenApiGenerator.JsonConverters.DoneReasonJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.CreateModelStatusJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PullModelStatusJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.PushModelStatusJsonConverter),
        })]

    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.JsonSerializerContextTypes))]
    internal sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}