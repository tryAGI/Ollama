
#nullable enable

namespace Ollama
{
    /// <summary>
    ///
    /// </summary>
    #pragma warning disable CS3016 // Converter type array in this attribute is not CLS-compliant.
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[]
        {
            typeof(global::Ollama.JsonConverters.ChatMessageRoleJsonConverter),

            typeof(global::Ollama.JsonConverters.ChatMessageRoleNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.ToolDefinitionTypeJsonConverter),

            typeof(global::Ollama.JsonConverters.ToolDefinitionTypeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.ChatRequestFormatEnumJsonConverter),

            typeof(global::Ollama.JsonConverters.ChatRequestFormatEnumNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.ChatResponseMessageRoleJsonConverter),

            typeof(global::Ollama.JsonConverters.ChatResponseMessageRoleNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneChoiceQuestionTypeJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneChoiceQuestionTypeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneNoulQuestionTypeJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneNoulQuestionTypeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneScoreQuestionTypeJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneScoreQuestionTypeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneChoiceAnswerTypeJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneChoiceAnswerTypeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneNoulAnswerTypeJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneNoulAnswerTypeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneScoreAnswerTypeJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneScoreAnswerTypeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageResponseRangeJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageResponseRangeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageResponseScopeJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageResponseScopeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageResponseGranularityJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageResponseGranularityNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageRangeJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageRangeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageScopeJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageScopeNullableJsonConverter),

            typeof(global::Ollama.JsonConverters.ThinkValueJsonConverter),

            typeof(global::Ollama.JsonConverters.SystemOneContentJsonConverter),

            typeof(global::Ollama.JsonConverters.UsageBucketJsonConverter),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, object>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, double?>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<global::Ollama.ChatRequestFormatEnum?, object>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, double?>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<bool?, string>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<bool?, string>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<global::Ollama.SystemOneChoiceQuestion, global::Ollama.SystemOneNoulQuestion, global::Ollama.SystemOneScoreQuestion>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<string, double?>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<global::Ollama.SystemOneChoiceAnswer, global::Ollama.SystemOneNoulAnswer, global::Ollama.SystemOneScoreAnswer>),

            typeof(global::Ollama.JsonConverters.OneOfJsonConverter<global::Ollama.IncludedBalance, global::Ollama.LegacyIncludedBalance>),

            typeof(global::Ollama.JsonConverters.UnixTimestampJsonConverter),
        })]
    #pragma warning restore CS3016
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.JsonSerializerContextTypes))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<object>), TypeInfoPropertyName = "SystemCollectionsGeneric_ObjectList")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ModelOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(float))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>), TypeInfoPropertyName = "OneOfStringIListString2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.GenerateRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<string, object>), TypeInfoPropertyName = "OneOfStringObject2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(object))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ThinkValue), TypeInfoPropertyName = "ThinkValue2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<string, double?>), TypeInfoPropertyName = "OneOfStringDouble2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(double))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.GenerateResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(long))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.Logprob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.Logprob))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.GenerateStreamEvent))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatMessageRole), TypeInfoPropertyName = "ChatMessageRole2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.ToolCall>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ToolCall))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ToolCallFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ToolDefinition))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ToolDefinitionType), TypeInfoPropertyName = "ToolDefinitionType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ToolDefinitionFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.ChatMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.ToolDefinition>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<global::Ollama.ChatRequestFormatEnum?, object>), TypeInfoPropertyName = "OneOfChatRequestFormatEnumObject2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatRequestFormatEnum), TypeInfoPropertyName = "ChatRequestFormatEnum2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTime))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatResponseMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatResponseMessageRole), TypeInfoPropertyName = "ChatResponseMessageRole2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatStreamEvent))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ChatStreamEventMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.Thinking))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.OneOf<bool?, string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<bool?, string>), TypeInfoPropertyName = "OneOfBooleanString2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.StatusEvent))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.StatusResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.EmbedRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.EmbedResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<double>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<double>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.CreateRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.Dictionary<string, string>), TypeInfoPropertyName = "DictionaryStringString_System_Collections_Generic_Dictionary_string_string")]
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
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneContent), TypeInfoPropertyName = "SystemOneContent2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<object>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneChoiceQuestion))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneChoiceQuestionType), TypeInfoPropertyName = "SystemOneChoiceQuestionType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.Dictionary<string, string?>), TypeInfoPropertyName = "DictionaryStringString_System_Collections_Generic_Dictionary_string_string_3")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneNoulQuestion))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneNoulQuestionType), TypeInfoPropertyName = "SystemOneNoulQuestionType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneNoulQuestionCriteria))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneScoreQuestion))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneScoreQuestionType), TypeInfoPropertyName = "SystemOneScoreQuestionType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<byte[]>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(byte[]))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<global::Ollama.SystemOneChoiceQuestion, global::Ollama.SystemOneNoulQuestion, global::Ollama.SystemOneScoreQuestion>), TypeInfoPropertyName = "OneOfSystemOneChoiceQuestionSystemOneNoulQuestionSystemOneScoreQuestion2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.Dictionary<string, double>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneChoiceAnswer))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneChoiceAnswerType), TypeInfoPropertyName = "SystemOneChoiceAnswerType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneNoulAnswer))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneNoulAnswerType), TypeInfoPropertyName = "SystemOneNoulAnswerType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneScoreAnswer))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneScoreAnswerType), TypeInfoPropertyName = "SystemOneScoreAnswerType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<global::Ollama.SystemOneChoiceAnswer, global::Ollama.SystemOneNoulAnswer, global::Ollama.SystemOneScoreAnswer>), TypeInfoPropertyName = "OneOfSystemOneChoiceAnswerSystemOneNoulAnswerSystemOneScoreAnswer2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.SystemOneResponseUsage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.UsageMetrics))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.UsageBucket), TypeInfoPropertyName = "UsageBucket2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.UsageBucketVariant2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.UsageResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.UsageResponseRange), TypeInfoPropertyName = "UsageResponseRange2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.UsageResponseScope), TypeInfoPropertyName = "UsageResponseScope2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.UsageResponseGranularity), TypeInfoPropertyName = "UsageResponseGranularity2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Ollama.UsageBucket>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.IncludedBalance))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.IncludedBalancePeriod))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.LegacyBalanceLimit))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.LegacyIncludedBalance))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.BalanceResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<global::Ollama.IncludedBalance, global::Ollama.LegacyIncludedBalance>), TypeInfoPropertyName = "OneOfIncludedBalanceLegacyIncludedBalance2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.BalanceResponsePurchased))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.ErrorResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.UsageRange), TypeInfoPropertyName = "UsageRange2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.UsageScope), TypeInfoPropertyName = "UsageScope2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Ollama.OneOf<string, global::System.Collections.Generic.List<string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.Logprob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.ToolCall>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.ChatMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.ToolDefinition>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.OneOf<bool?, string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::System.Collections.Generic.List<double>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<double>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.ModelSummary>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.Ps>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.WebSearchResult>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<long>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.TokenLogprob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<byte[]>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Ollama.UsageBucket>))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}