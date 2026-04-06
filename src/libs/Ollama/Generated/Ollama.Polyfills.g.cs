
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class AutoSdkPolyfills
    {
#if !NET6_0_OR_GREATER
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static global::System.Threading.Tasks.Task<string> ReadAsStringAsync(
            this global::System.Net.Http.HttpContent content,
            global::System.Threading.CancellationToken cancellationToken)
        {
            content = content ?? throw new global::System.ArgumentNullException(nameof(content));
            return content.ReadAsStringAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static global::System.Threading.Tasks.Task<global::System.IO.Stream> ReadAsStreamAsync(
            this global::System.Net.Http.HttpContent content,
            global::System.Threading.CancellationToken cancellationToken)
        {
            content = content ?? throw new global::System.ArgumentNullException(nameof(content));
            return content.ReadAsStreamAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static global::System.Threading.Tasks.Task<byte[]> ReadAsByteArrayAsync(
            this global::System.Net.Http.HttpContent content,
            global::System.Threading.CancellationToken cancellationToken)
        {
            content = content ?? throw new global::System.ArgumentNullException(nameof(content));
            return content.ReadAsByteArrayAsync();
        }
#endif

        /// <summary>
        /// Creates a JSON request content instance.
        /// </summary>
#if NET8_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
        [global::System.Diagnostics.CodeAnalysis.RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
#endif
        public static global::System.Net.Http.HttpContent CreateJsonContent<T>(
            T inputValue,
            string mediaType,
            global::System.Text.Json.JsonSerializerOptions? jsonSerializerOptions)
        {
            if (string.IsNullOrWhiteSpace(mediaType))
            {
                throw new global::System.ArgumentException("Media type is required.", nameof(mediaType));
            }

#if NET5_0_OR_GREATER
            return global::System.Net.Http.Json.JsonContent.Create(
                inputValue: inputValue,
                mediaType: new global::System.Net.Http.Headers.MediaTypeHeaderValue(mediaType),
                options: jsonSerializerOptions);
#else
            var json = global::System.Text.Json.JsonSerializer.Serialize(inputValue, jsonSerializerOptions);
            var stringContent = new global::System.Net.Http.StringContent(
                content: json,
                encoding: global::System.Text.Encoding.UTF8);
            stringContent.Headers.ContentType = new global::System.Net.Http.Headers.MediaTypeHeaderValue(mediaType)
            {
                CharSet = global::System.Text.Encoding.UTF8.WebName,
            };
            return stringContent;
#endif
        }

        /// <summary>
        /// Creates a JSON request content instance using a source-generated serializer context.
        /// </summary>
        public static global::System.Net.Http.HttpContent CreateJsonContent(
            object? inputValue,
            global::System.Type inputType,
            string mediaType,
            global::System.Text.Json.Serialization.JsonSerializerContext jsonSerializerContext)
        {
            inputType = inputType ?? throw new global::System.ArgumentNullException(nameof(inputType));
            jsonSerializerContext = jsonSerializerContext ?? throw new global::System.ArgumentNullException(nameof(jsonSerializerContext));

            if (string.IsNullOrWhiteSpace(mediaType))
            {
                throw new global::System.ArgumentException("Media type is required.", nameof(mediaType));
            }

#if NET5_0_OR_GREATER
            var jsonTypeInfo = jsonSerializerContext.GetTypeInfo(inputType) ??
                               throw new global::System.InvalidOperationException($"No JsonTypeInfo registered for '{inputType}'.");
            return global::System.Net.Http.Json.JsonContent.Create(
                inputValue: inputValue,
                jsonTypeInfo: jsonTypeInfo,
                mediaType: new global::System.Net.Http.Headers.MediaTypeHeaderValue(mediaType));
#else
            var json = global::System.Text.Json.JsonSerializer.Serialize(
                value: inputValue,
                inputType: inputType,
                jsonSerializerContext);
            var stringContent = new global::System.Net.Http.StringContent(
                content: json,
                encoding: global::System.Text.Encoding.UTF8);
            stringContent.Headers.ContentType = new global::System.Net.Http.Headers.MediaTypeHeaderValue(mediaType)
            {
                CharSet = global::System.Text.Encoding.UTF8.WebName,
            };
            return stringContent;
#endif
        }

        /// <summary>
        /// Reads JSON content into the specified type using serializer options.
        /// </summary>
#if NET8_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
        [global::System.Diagnostics.CodeAnalysis.RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
#endif
        public static async global::System.Threading.Tasks.Task<T?> ReadFromJsonAsync<T>(
            this global::System.Net.Http.HttpContent content,
            global::System.Text.Json.JsonSerializerOptions? jsonSerializerOptions,
            global::System.Threading.CancellationToken cancellationToken)
        {
            content = content ?? throw new global::System.ArgumentNullException(nameof(content));

#if NET5_0_OR_GREATER
            return await global::System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync<T>(
                content,
                jsonSerializerOptions,
                cancellationToken).ConfigureAwait(false);
#else
            using var stream = await AutoSdkPolyfills.ReadAsStreamAsync(content, cancellationToken).ConfigureAwait(false);
            return await global::System.Text.Json.JsonSerializer.DeserializeAsync<T>(
                utf8Json: stream,
                options: jsonSerializerOptions,
                cancellationToken: cancellationToken).ConfigureAwait(false);
#endif
        }

        /// <summary>
        /// Reads JSON content into the specified type using a source-generated serializer context.
        /// </summary>
        public static async global::System.Threading.Tasks.Task<T?> ReadFromJsonAsync<T>(
            this global::System.Net.Http.HttpContent content,
            global::System.Text.Json.Serialization.JsonSerializerContext jsonSerializerContext,
            global::System.Threading.CancellationToken cancellationToken)
        {
            content = content ?? throw new global::System.ArgumentNullException(nameof(content));
            jsonSerializerContext = jsonSerializerContext ?? throw new global::System.ArgumentNullException(nameof(jsonSerializerContext));

#if NET5_0_OR_GREATER
            return (T?)await global::System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync(
                content,
                typeof(T),
                jsonSerializerContext,
                cancellationToken).ConfigureAwait(false);
#else
            using var stream = await AutoSdkPolyfills.ReadAsStreamAsync(content, cancellationToken).ConfigureAwait(false);
            return (T?)await global::System.Text.Json.JsonSerializer.DeserializeAsync(
                utf8Json: stream,
                returnType: typeof(T),
                jsonSerializerContext,
                cancellationToken: cancellationToken).ConfigureAwait(false);
#endif
        }
    }
}
