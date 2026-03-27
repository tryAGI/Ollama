
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
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ModelOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(float))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.GenerateRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<string, object>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(object))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<bool?, global::Ollama.GenerateRequestThink?>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.GenerateRequestThink))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<string, double?>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(double))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.GenerateResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(long))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.Logprob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.Logprob))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.GenerateStreamEvent))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatMessageRole))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.ToolCall>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ToolCall))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ToolCallFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ToolDefinition))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ToolDefinitionType))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ToolDefinitionFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.ChatMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.ToolDefinition>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<global::Ollama.ChatRequestFormatEnum?, object>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatRequestFormatEnum))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<bool?, global::Ollama.ChatRequestThink?>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatRequestThink))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTime))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatResponseMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatResponseMessageRole))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatStreamEvent))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatStreamEventMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.StatusEvent))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.StatusResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.EmbedRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.EmbedResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<double>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<double>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.CreateRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.CopyRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.DeleteRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.PullRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.PushRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ShowRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ShowResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ModelSummary))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ModelSummaryDetails))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ListResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.ModelSummary>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.Ps))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.PsResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.Ps>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.WebSearchRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.WebSearchResult))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.WebSearchResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.WebSearchResult>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.WebFetchRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.WebFetchResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.VersionResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.TokenLogprob))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<long>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.TokenLogprob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ErrorResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<string, global::System.Collections.Generic.List<string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.Logprob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.ToolCall>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.ChatMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.ToolDefinition>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::System.Collections.Generic.List<double>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<double>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.ModelSummary>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.Ps>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.WebSearchResult>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<long>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.TokenLogprob>))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}