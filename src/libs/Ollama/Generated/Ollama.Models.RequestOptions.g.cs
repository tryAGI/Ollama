
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Additional model parameters listed in the documentation for the Modelfile such as `temperature`.
    /// </summary>
    public sealed partial class RequestOptions
    {
        /// <summary>
        /// Number of tokens to keep from the prompt.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("num_keep")]
        public int? NumKeep { get; set; }

        /// <summary>
        /// Sets the random number seed to use for generation. Setting this to a specific number will make the model <br/>
        /// generate the same text for the same prompt. (Default: 0)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("seed")]
        public int? Seed { get; set; }

        /// <summary>
        /// Maximum number of tokens to predict when generating text. <br/>
        /// (Default: 128, -1 = infinite generation, -2 = fill context)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("num_predict")]
        public int? NumPredict { get; set; }

        /// <summary>
        /// Reduces the probability of generating nonsense. A higher value (e.g. 100) will give more diverse answers, <br/>
        /// while a lower value (e.g. 10) will be more conservative. (Default: 40)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("top_k")]
        public int? TopK { get; set; }

        /// <summary>
        /// Works together with top_k. A higher value (e.g., 0.95) will lead to more diverse text, while a lower value <br/>
        /// (e.g., 0.5) will generate more focused and conservative text. (Default: 0.9)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("top_p")]
        public float? TopP { get; set; }

        /// <summary>
        /// Alternative to the top_p, and aims to ensure a balance of quality and variety. min_p represents the minimum <br/>
        /// probability for a token to be considered, relative to the probability of the most likely token. For <br/>
        /// example, with min_p=0.05 and the most likely token having a probability of 0.9, logits with a value less <br/>
        /// than 0.05*0.9=0.045 are filtered out. (Default: 0.0)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("min_p")]
        public float? MinP { get; set; }

        /// <summary>
        /// Tail free sampling is used to reduce the impact of less probable tokens from the output. A higher value <br/>
        /// (e.g., 2.0) will reduce the impact more, while a value of 1.0 disables this setting. (default: 1)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("tfs_z")]
        public float? TfsZ { get; set; }

        /// <summary>
        /// Typical p is used to reduce the impact of less probable tokens from the output. (default: 1)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("typical_p")]
        public float? TypicalP { get; set; }

        /// <summary>
        /// Sets how far back for the model to look back to prevent repetition. <br/>
        /// (Default: 64, 0 = disabled, -1 = num_ctx)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("repeat_last_n")]
        public int? RepeatLastN { get; set; }

        /// <summary>
        /// The temperature of the model. Increasing the temperature will make the model answer more creatively. <br/>
        /// (Default: 0.8)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("temperature")]
        public float? Temperature { get; set; }

        /// <summary>
        /// Sets how strongly to penalize repetitions. A higher value (e.g., 1.5) will penalize repetitions more <br/>
        /// strongly, while a lower value (e.g., 0.9) will be more lenient. (Default: 1.1)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("repeat_penalty")]
        public float? RepeatPenalty { get; set; }

        /// <summary>
        /// Positive values penalize new tokens based on whether they appear in the text so far, increasing the <br/>
        /// model's likelihood to talk about new topics. (Default: 0)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("presence_penalty")]
        public float? PresencePenalty { get; set; }

        /// <summary>
        /// Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the <br/>
        /// model's likelihood to repeat the same line verbatim. (Default: 0)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("frequency_penalty")]
        public float? FrequencyPenalty { get; set; }

        /// <summary>
        /// Enable Mirostat sampling for controlling perplexity. <br/>
        /// (default: 0, 0 = disabled, 1 = Mirostat, 2 = Mirostat 2.0)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("mirostat")]
        public int? Mirostat { get; set; }

        /// <summary>
        /// Controls the balance between coherence and diversity of the output. A lower value will result in more <br/>
        /// focused and coherent text. (Default: 5.0)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("mirostat_tau")]
        public float? MirostatTau { get; set; }

        /// <summary>
        /// Influences how quickly the algorithm responds to feedback from the generated text. A lower learning rate <br/>
        /// will result in slower adjustments, while a higher learning rate will make the algorithm more responsive. <br/>
        /// (Default: 0.1)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("mirostat_eta")]
        public float? MirostatEta { get; set; }

        /// <summary>
        /// Penalize newlines in the output. (Default: true)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("penalize_newline")]
        public bool? PenalizeNewline { get; set; }

        /// <summary>
        /// Sequences where the API will stop generating further tokens. The returned text will not contain the stop <br/>
        /// sequence.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("stop")]
        public global::System.Collections.Generic.IList<string?>? Stop { get; set; }

        /// <summary>
        /// Enable NUMA support. (Default: false)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("numa")]
        public bool? Numa { get; set; }

        /// <summary>
        /// Sets the size of the context window used to generate the next token. (Default: 2048)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("num_ctx")]
        public int? NumCtx { get; set; }

        /// <summary>
        /// Sets the number of batches to use for generation. (Default: 512)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("num_batch")]
        public int? NumBatch { get; set; }

        /// <summary>
        /// The number of layers to send to the GPU(s). <br/>
        /// On macOS it defaults to 1 to enable metal support, 0 to disable.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("num_gpu")]
        public int? NumGpu { get; set; }

        /// <summary>
        /// The GPU to use for the main model. Default is 0.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("main_gpu")]
        public int? MainGpu { get; set; }

        /// <summary>
        /// Enable low VRAM mode. (Default: false)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("low_vram")]
        public bool? LowVram { get; set; }

        /// <summary>
        /// Enable f16 key/value. (Default: true)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("f16_kv")]
        public bool? F16Kv { get; set; }

        /// <summary>
        /// Enable logits all. (Default: false)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("logits_all")]
        public bool? LogitsAll { get; set; }

        /// <summary>
        /// Enable vocab only. (Default: false)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("vocab_only")]
        public bool? VocabOnly { get; set; }

        /// <summary>
        /// Enable mmap. (Default: false)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("use_mmap")]
        public bool? UseMmap { get; set; }

        /// <summary>
        /// Enable mlock. (Default: false)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("use_mlock")]
        public bool? UseMlock { get; set; }

        /// <summary>
        /// Sets the number of threads to use during computation. By default, Ollama will detect this for optimal <br/>
        /// performance. It is recommended to set this value to the number of physical CPU cores your system has <br/>
        /// (as opposed to the logical number of cores).
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("num_thread")]
        public int? NumThread { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}