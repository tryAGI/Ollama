
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
        public global::Ollama.GenerateCompletionRequest? Type0 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Type1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<long>? Type2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? Type3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? Type4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<global::Ollama.GenerateCompletionRequestFormatEnum?, object>? Type5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateCompletionRequestFormatEnum? Type6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object? Type7 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Type8 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<string>? Type9 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.RequestOptions? Type10 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float? Type11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<bool?, global::Ollama.GenerateCompletionRequestThink?>? Type12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateCompletionRequestThink? Type13 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ResponseFormat? Type14 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ResponseFormatEnum? Type15 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.VersionResponse? Type16 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateCompletionResponse? Type17 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.DateTime? Type18 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateChatCompletionRequest? Type19 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.Message>? Type20 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.Message? Type21 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.MessageRole? Type22 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.ToolCall>? Type23 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ToolCall? Type24 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ToolCallFunction? Type25 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<global::Ollama.GenerateChatCompletionRequestFormatEnum?, object>? Type26 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateChatCompletionRequestFormatEnum? Type27 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.Tool>? Type28 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.Tool? Type29 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ToolType? Type30 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ToolFunction? Type31 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.OneOf<bool?, global::Ollama.GenerateChatCompletionRequestThink?>? Type32 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateChatCompletionRequestThink? Type33 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateChatCompletionResponse? Type34 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.DoneReason? Type35 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.DoneReasonEnum? Type36 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateEmbeddingRequest? Type37 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.GenerateEmbeddingResponse? Type38 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<double>? Type39 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? Type40 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.CreateModelRequest? Type41 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, string>? Type42 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.CreateModelResponse? Type43 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.CreateModelStatus? Type44 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.CreateModelStatusEnum? Type45 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ModelsResponse? Type46 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.Model>? Type47 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.Model? Type48 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ModelDetails? Type49 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ModelInformation? Type50 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.Tensor? Type51 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.Capability? Type52 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ProcessResponse? Type53 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.ProcessModel>? Type54 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ProcessModel? Type55 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ModelInfoRequest? Type56 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.ModelInfo? Type57 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.Tensor>? Type58 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Collections.Generic.IList<global::Ollama.Capability>? Type59 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.CopyModelRequest? Type60 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.DeleteModelRequest? Type61 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.PullModelRequest? Type62 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.PullModelResponse? Type63 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.PullModelStatus? Type64 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.PullModelStatusEnum? Type65 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.PushModelRequest? Type66 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.PushModelResponse? Type67 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.AnyOf<string, global::Ollama.PushModelResponseStatus?>? Type68 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::Ollama.PushModelResponseStatus? Type69 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[]? Type70 { get; set; }
    }
}