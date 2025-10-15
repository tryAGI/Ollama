#nullable enable

namespace Ollama.JsonConverters
{
    /// <inheritdoc />
    public sealed class GenerateCompletionRequestThinkJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Ollama.GenerateCompletionRequestThink>
    {
        /// <inheritdoc />
        public override global::Ollama.GenerateCompletionRequestThink Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case global::System.Text.Json.JsonTokenType.String:
                {
                    var stringValue = reader.GetString();
                    if (stringValue != null)
                    {
                        return global::Ollama.GenerateCompletionRequestThinkExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Ollama.GenerateCompletionRequestThink)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Ollama.GenerateCompletionRequestThink);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Ollama.GenerateCompletionRequestThink value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::Ollama.GenerateCompletionRequestThinkExtensions.ToValueString(value));
        }
    }
}
