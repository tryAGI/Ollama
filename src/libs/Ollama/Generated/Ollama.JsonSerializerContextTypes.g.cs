
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
        /// Runtime object lists used by dynamic JSON payloads such as tool arguments.
        /// </summary>
        public global::System.Collections.Generic.List<object>? ObjectList { get; set; }

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
        public global::Ollama.GenerateStreamEvent? Type18 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ChatMessage? Type19 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ChatMessageRole? Type20 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.ToolCall>? Type21 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ToolCall? Type22 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ToolCallFunction? Type23 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ToolDefinition? Type24 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ToolDefinitionType? Type25 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ToolDefinitionFunction? Type26 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ChatRequest? Type27 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.ChatMessage>? Type28 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.ToolDefinition>? Type29 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.OneOf<global::Ollama.ChatRequestFormatEnum?, object>? Type30 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ChatRequestFormatEnum? Type31 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.OneOf<bool?, global::Ollama.ChatRequestThink?>? Type32 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ChatRequestThink? Type33 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ChatResponse? Type34 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.DateTime? Type35 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ChatResponseMessage? Type36 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ChatResponseMessageRole? Type37 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ChatStreamEvent? Type38 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ChatStreamEventMessage? Type39 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.StatusEvent? Type40 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.StatusResponse? Type41 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.EmbedRequest? Type42 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.EmbedResponse? Type43 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<double>>? Type44 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<double>? Type45 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.CreateRequest? Type46 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, string>? Type47 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.CopyRequest? Type48 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.DeleteRequest? Type49 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.PullRequest? Type50 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.PushRequest? Type51 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ShowRequest? Type52 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ShowResponse? Type53 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ModelSummary? Type54 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ModelSummaryDetails? Type55 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ListResponse? Type56 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.ModelSummary>? Type57 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.Ps? Type58 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.PsResponse? Type59 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.Ps>? Type60 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.WebSearchRequest? Type61 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.WebSearchResult? Type62 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.WebSearchResponse? Type63 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.WebSearchResult>? Type64 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.WebFetchRequest? Type65 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.WebFetchResponse? Type66 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.VersionResponse? Type67 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.TokenLogprob? Type68 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<long>? Type69 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.TokenLogprob>? Type70 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Ollama.ErrorResponse? Type71 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public byte[]? Type72 { get; set; }

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
        public global::System.Collections.Generic.List<global::Ollama.ToolCall>? ListType3 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.ChatMessage>? ListType4 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.ToolDefinition>? ListType5 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::System.Collections.Generic.List<double>>? ListType6 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<double>? ListType7 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.ModelSummary>? ListType8 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.Ps>? ListType9 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.WebSearchResult>? ListType10 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<long>? ListType11 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Ollama.TokenLogprob>? ListType12 { get; set; }
    }
}