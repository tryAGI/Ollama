#nullable enable

namespace Ollama.JsonConverters
{
    /// <inheritdoc />
    public sealed class GenerateCompletionRequestFormatEnumJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Ollama.GenerateCompletionRequestFormatEnum>
    {
        /// <inheritdoc />
        public override global::Ollama.GenerateCompletionRequestFormatEnum Read(
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
                        return global::Ollama.GenerateCompletionRequestFormatEnumExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Ollama.GenerateCompletionRequestFormatEnum)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Ollama.GenerateCompletionRequestFormatEnum);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Ollama.GenerateCompletionRequestFormatEnum value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::Ollama.GenerateCompletionRequestFormatEnumExtensions.ToValueString(value));
        }
    }
}
