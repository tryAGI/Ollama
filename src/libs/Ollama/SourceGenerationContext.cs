using System.Text.Json.Serialization;
using OpenApiGenerator.JsonConverters;

namespace Ollama;

[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    Converters =
    [
        // We need specify explicitly all converters for enums inside AnyOf/OneOf/AllOf to make them work
        typeof(GenerateCompletionRequestFormatJsonConverter),
        typeof(GenerateCompletionRequestFormatNullableJsonConverter),
        typeof(GenerateChatCompletionRequestFormatJsonConverter),
        typeof(GenerateChatCompletionRequestFormatNullableJsonConverter),
        typeof(GenerateChatCompletionResponseDoneReasonJsonConverter),
        typeof(GenerateChatCompletionResponseDoneReasonNullableJsonConverter),
        typeof(MessageRoleJsonConverter),
        typeof(MessageRoleNullableJsonConverter),
        typeof(CreateModelResponseStatusJsonConverter),
        typeof(CreateModelResponseStatusNullableJsonConverter),
        typeof(PullModelResponseStatusJsonConverter),
        typeof(PullModelResponseStatusNullableJsonConverter),
        typeof(PushModelResponseStatusJsonConverter),
        typeof(PushModelResponseStatusNullableJsonConverter),
    ])]
[JsonSerializable(typeof(JsonSerializerContextTypes))]
internal sealed partial class SourceGenerationContext : JsonSerializerContext;