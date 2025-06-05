#nullable enable
#pragma warning disable CS0618 // Type or member is obsolete

namespace Ollama.JsonConverters
{
    /// <inheritdoc />
    public class CreateModelStatusJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Ollama.CreateModelStatus>
    {
        /// <inheritdoc />
        public override global::Ollama.CreateModelStatus Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            options = options ?? throw new global::System.ArgumentNullException(nameof(options));
            var typeInfoResolver = options.TypeInfoResolver ?? throw new global::System.InvalidOperationException("TypeInfoResolver is not set.");

            var
            readerCopy = reader;
            string? value1 = default;
            try
            {
                var typeInfo = typeInfoResolver.GetTypeInfo(typeof(string), options) as global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<string> ??
                               throw new global::System.InvalidOperationException($"Cannot get type info for {typeof(string).Name}");
                value1 = global::System.Text.Json.JsonSerializer.Deserialize(ref readerCopy, typeInfo);
            }
            catch (global::System.Text.Json.JsonException)
            {
            }

            readerCopy = reader;
            global::Ollama.CreateModelStatusEnum? value2 = default;
            try
            {
                var typeInfo = typeInfoResolver.GetTypeInfo(typeof(global::Ollama.CreateModelStatusEnum), options) as global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.CreateModelStatusEnum> ??
                               throw new global::System.InvalidOperationException($"Cannot get type info for {typeof(global::Ollama.CreateModelStatusEnum).Name}");
                value2 = global::System.Text.Json.JsonSerializer.Deserialize(ref readerCopy, typeInfo);
            }
            catch (global::System.Text.Json.JsonException)
            {
            }

            var result = new global::Ollama.CreateModelStatus(
                value1,
                value2
                );

            if (value1 != null)
            {
                var typeInfo = typeInfoResolver.GetTypeInfo(typeof(string), options) as global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<string> ??
                               throw new global::System.InvalidOperationException($"Cannot get type info for {typeof(string).Name}");
                _ = global::System.Text.Json.JsonSerializer.Deserialize(ref reader, typeInfo);
            }
            else if (value2 != null)
            {
                var typeInfo = typeInfoResolver.GetTypeInfo(typeof(global::Ollama.CreateModelStatusEnum), options) as global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.CreateModelStatusEnum> ??
                               throw new global::System.InvalidOperationException($"Cannot get type info for {typeof(global::Ollama.CreateModelStatusEnum).Name}");
                _ = global::System.Text.Json.JsonSerializer.Deserialize(ref reader, typeInfo);
            }

            return result;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Ollama.CreateModelStatus value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            options = options ?? throw new global::System.ArgumentNullException(nameof(options));
            var typeInfoResolver = options.TypeInfoResolver ?? throw new global::System.InvalidOperationException("TypeInfoResolver is not set.");

            if (value.IsValue1)
            {
                var typeInfo = typeInfoResolver.GetTypeInfo(typeof(string), options) as global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<string?> ??
                               throw new global::System.InvalidOperationException($"Cannot get type info for {typeof(string).Name}");
                global::System.Text.Json.JsonSerializer.Serialize(writer, value.Value1, typeInfo);
            }
            else if (value.IsValue2)
            {
                var typeInfo = typeInfoResolver.GetTypeInfo(typeof(global::Ollama.CreateModelStatusEnum), options) as global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.CreateModelStatusEnum> ??
                               throw new global::System.InvalidOperationException($"Cannot get type info for {typeof(global::Ollama.CreateModelStatusEnum).Name}");
                global::System.Text.Json.JsonSerializer.Serialize(writer, value.Value2, typeInfo);
            }
        }
    }
}