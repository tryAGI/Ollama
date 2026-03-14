
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class JsonSerializerContextTypes
    {
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, string>? StringStringDictionary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, object>? StringObjectDictionary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public global::System.Text.Json.JsonElement? JsonElement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ModelOptions? Type0 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Type1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float? Type2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<string, global::System.Collections.Generic.IList<string>>? Type3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Type4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<string>? Type5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateRequest? Type6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<string, object>? Type7 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object? Type8 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? Type9 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<bool?, global::Ollama.GenerateRequestThink?>? Type10 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateRequestThink? Type11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<string, double?>? Type12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? Type13 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateResponse? Type14 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? Type15 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.Logprob>? Type16 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.Logprob? Type17 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<int>? Type18 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.TokenLogprob>? Type19 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.TokenLogprob? Type20 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateStreamEvent? Type21 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ChatMessage? Type22 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ChatMessageRole? Type23 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.ToolCall>? Type24 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ToolCall? Type25 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ToolCallFunction? Type26 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ToolDefinition? Type27 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ToolDefinitionType? Type28 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ToolDefinitionFunction? Type29 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ChatRequest? Type30 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.ChatMessage>? Type31 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.ToolDefinition>? Type32 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<global::Ollama.ChatRequestFormatEnum?, object>? Type33 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ChatRequestFormatEnum? Type34 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<bool?, global::Ollama.ChatRequestThink?>? Type35 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ChatRequestThink? Type36 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ChatResponse? Type37 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.DateTime? Type38 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ChatResponseMessage? Type39 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ChatResponseMessageRole? Type40 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ChatStreamEvent? Type41 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ChatStreamEventMessage? Type42 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.StatusEvent? Type43 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.StatusResponse? Type44 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.EmbedRequest? Type45 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.EmbedResponse? Type46 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<double>>? Type47 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<double>? Type48 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.CreateRequest? Type49 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.CopyRequest? Type50 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.DeleteRequest? Type51 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.PullRequest? Type52 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.PushRequest? Type53 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ShowRequest? Type54 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ShowResponse? Type55 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ModelSummary? Type56 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ModelSummaryDetails? Type57 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ListResponse? Type58 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.ModelSummary>? Type59 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.Ps? Type60 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.PsResponse? Type61 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.Ps>? Type62 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.WebSearchRequest? Type63 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.WebSearchResult? Type64 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.WebSearchResponse? Type65 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.WebSearchResult>? Type66 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.WebFetchRequest? Type67 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.WebFetchResponse? Type68 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.VersionResponse? Type69 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ErrorResponse? Type70 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<string, global::System.Collections.Generic.List<string>>? ListType0 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<string>? ListType1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.Logprob>? ListType2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<int>? ListType3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.TokenLogprob>? ListType4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.ToolCall>? ListType5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.ChatMessage>? ListType6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.ToolDefinition>? ListType7 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<global::System.Collections.Generic.List<double>>? ListType8 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<double>? ListType9 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.ModelSummary>? ListType10 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.Ps>? ListType11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.WebSearchResult>? ListType12 { get; set; }
    }
}