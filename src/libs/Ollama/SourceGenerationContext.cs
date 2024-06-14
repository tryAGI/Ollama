using System.Text.Json.Serialization;
using OpenApiGenerator.JsonConverters;

namespace Ollama;

[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    Converters =
    [
        // We need specify explicitly all converters for enums inside AnyOf/OneOf/AllOf to make them work
        typeof(ResponseFormatJsonConverter),
        typeof(ResponseFormatNullableJsonConverter),
        typeof(GenerateChatCompletionResponseDoneReasonJsonConverter),
        typeof(GenerateChatCompletionResponseDoneReasonNullableJsonConverter),
        typeof(DoneReasonVariant2JsonConverter),
        typeof(DoneReasonVariant2NullableJsonConverter),
        typeof(MessageRoleJsonConverter),
        typeof(MessageRoleNullableJsonConverter),
        typeof(CreateModelResponseStatusJsonConverter),
        typeof(CreateModelResponseStatusNullableJsonConverter),
        typeof(CreateModelStatusVariant2JsonConverter),
        typeof(CreateModelStatusVariant2NullableJsonConverter),
        typeof(PullModelResponseStatusJsonConverter),
        typeof(PullModelResponseStatusNullableJsonConverter),
        typeof(PullModelStatusVariant2JsonConverter),
        typeof(PullModelStatusVariant2NullableJsonConverter),
        typeof(PushModelResponseStatusJsonConverter),
        typeof(PushModelResponseStatusNullableJsonConverter),
        typeof(PushModelStatusVariant2JsonConverter),
        typeof(PushModelStatusVariant2NullableJsonConverter),
    ])]
[JsonSerializable(typeof(JsonSerializerContextTypes))]
internal sealed partial class SourceGenerationContext : JsonSerializerContext;