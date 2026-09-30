#nullable enable

namespace Ollama.JsonConverters
{
    /// <inheritdoc />
    public sealed class SystemOneNoulAnswerTypeNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Ollama.SystemOneNoulAnswerType?>
    {
        /// <inheritdoc />
        public override global::Ollama.SystemOneNoulAnswerType? Read(
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
                        return global::Ollama.SystemOneNoulAnswerTypeExtensions.ToEnum(stringValue);
                    }

                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Ollama.SystemOneNoulAnswerType)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Ollama.SystemOneNoulAnswerType?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Ollama.SystemOneNoulAnswerType? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Ollama.SystemOneNoulAnswerTypeExtensions.ToValueString(value.Value));
            }
        }
    }
}
