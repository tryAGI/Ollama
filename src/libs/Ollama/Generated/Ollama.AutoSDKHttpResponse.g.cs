
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Represents a successful HTTP response with status code and headers.
    /// </summary>
    public partial class AutoSDKHttpResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoSDKHttpResponse"/> class.
        /// </summary>
        public AutoSDKHttpResponse(
            global::System.Net.HttpStatusCode statusCode,
            global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IEnumerable<string>> headers)
            : this(
                statusCode: statusCode,
                headers: headers,
                requestUri: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoSDKHttpResponse"/> class.
        /// </summary>
        public AutoSDKHttpResponse(
            global::System.Net.HttpStatusCode statusCode,
            global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IEnumerable<string>> headers,
            global::System.Uri? requestUri)
        {
            StatusCode = statusCode;
            Headers = headers ?? throw new global::System.ArgumentNullException(nameof(headers));
            RequestUri = requestUri;
        }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        public global::System.Net.HttpStatusCode StatusCode { get; }
        /// <summary>
        /// Gets the response headers.
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IEnumerable<string>> Headers { get; }
        /// <summary>
        /// Gets the final request URI associated with the response.
        /// </summary>
        public global::System.Uri? RequestUri { get; }

        internal static global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IEnumerable<string>> CreateHeaders(
            global::System.Net.Http.HttpResponseMessage response)
        {
            response = response ?? throw new global::System.ArgumentNullException(nameof(response));

            var headers = global::System.Linq.Enumerable.ToDictionary(
                response.Headers,
                static header => header.Key,
                static header => (global::System.Collections.Generic.IEnumerable<string>)global::System.Linq.Enumerable.ToArray(header.Value),
                global::System.StringComparer.OrdinalIgnoreCase);

            if (response.Content?.Headers == null)
            {
                return headers;
            }

            foreach (var header in response.Content.Headers)
            {
                if (headers.TryGetValue(header.Key, out var existingValues))
                {
                    headers[header.Key] = global::System.Linq.Enumerable.ToArray(
                        global::System.Linq.Enumerable.Concat(existingValues, header.Value));
                }
                else
                {
                    headers[header.Key] = global::System.Linq.Enumerable.ToArray(header.Value);
                }
            }

            return headers;
        }
    }

    /// <summary>
    /// Represents a successful HTTP response with status code, headers, and body.
    /// </summary>
    public partial class AutoSDKHttpResponse<T> : AutoSDKHttpResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoSDKHttpResponse{T}"/> class.
        /// </summary>
        public AutoSDKHttpResponse(
            global::System.Net.HttpStatusCode statusCode,
            global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IEnumerable<string>> headers,
            T body)
            : this(
                statusCode: statusCode,
                headers: headers,
                requestUri: null,
                body: body)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoSDKHttpResponse{T}"/> class.
        /// </summary>
        public AutoSDKHttpResponse(
            global::System.Net.HttpStatusCode statusCode,
            global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IEnumerable<string>> headers,
            global::System.Uri? requestUri,
            T body)
            : base(statusCode, headers, requestUri)
        {
            Body = body;
        }

        /// <summary>
        /// Gets the response body.
        /// </summary>
        public T Body { get; }
    }

    /// <summary>
    /// Represents the result of a conditional HTTP request. A not-modified response has no body
    /// and preserves the response entity tag so callers can keep their cached representation.
    /// </summary>
    public sealed class AutoSDKConditionalResponse<T>
    {
        internal AutoSDKConditionalResponse(
            bool notModified,
            string? entityTag,
            global::Ollama.AutoSDKHttpResponse<T>? response)
        {
            NotModified = notModified;
            EntityTag = entityTag;
            Response = response;
        }

        /// <summary>Gets whether the server returned HTTP 304 Not Modified.</summary>
        public bool NotModified { get; }

        /// <summary>Gets the response ETag, when one was supplied.</summary>
        public string? EntityTag { get; }

        /// <summary>Gets the successful response, or null when <see cref="NotModified"/> is true.</summary>
        public global::Ollama.AutoSDKHttpResponse<T>? Response { get; }
    }

    /// <summary>
    /// Helpers for standards-based ETag conditional requests. Generated clients already expose
    /// request headers through <see cref="AutoSDKRequestOptions"/> and successful response
    /// headers through <see cref="AutoSDKHttpResponse"/>; this helper also turns an OpenAPI
    /// <c>304</c> error response into a typed not-modified result.
    /// </summary>
    public static class AutoSDKConditionalRequests
    {
        /// <summary>
        /// Executes a generated <c>AsResponseAsync</c> method with an optional If-None-Match header.
        /// </summary>
        public static async global::System.Threading.Tasks.Task<global::Ollama.AutoSDKConditionalResponse<T>> SendAsync<T>(
            global::System.Func<global::Ollama.AutoSDKRequestOptions, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<global::Ollama.AutoSDKHttpResponse<T>>> send,
            string? entityTag = null,
            global::Ollama.AutoSDKRequestOptions? requestOptions = null,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            send = send ?? throw new global::System.ArgumentNullException(nameof(send));
            requestOptions = CloneRequestOptions(requestOptions);
            if (!string.IsNullOrWhiteSpace(entityTag))
            {
                requestOptions.Headers["If-None-Match"] = entityTag!;
            }

            try
            {
                var response = await send(requestOptions, cancellationToken).ConfigureAwait(false);
                return new global::Ollama.AutoSDKConditionalResponse<T>(
                    notModified: false,
                    entityTag: GetEntityTag(response.Headers),
                    response: response);
            }
            catch (global::Ollama.ApiException exception)
                when (exception.StatusCode == global::System.Net.HttpStatusCode.NotModified)
            {
                return new global::Ollama.AutoSDKConditionalResponse<T>(
                    notModified: true,
                    entityTag: GetEntityTag(exception.ResponseHeaders) ?? entityTag,
                    response: null);
            }
        }

        private static global::Ollama.AutoSDKRequestOptions CloneRequestOptions(
            global::Ollama.AutoSDKRequestOptions? source)
        {
            var clone = new global::Ollama.AutoSDKRequestOptions();
            if (source == null)
            {
                return clone;
            }

            foreach (var header in source.Headers)
            {
                clone.Headers[header.Key] = header.Value;
            }

            foreach (var parameter in source.QueryParameters)
            {
                clone.QueryParameters[parameter.Key] = parameter.Value;
            }

            clone.Timeout = source.Timeout;
            clone.Retry = source.Retry;
            clone.ReadResponseAsString = source.ReadResponseAsString;
            clone.Authorizations = source.Authorizations;
            return clone;
        }

        /// <summary>Gets the first ETag header value from a generated response header map.</summary>
        public static string? GetEntityTag(
            global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IEnumerable<string>>? headers)
        {
            if (headers == null || !headers.TryGetValue("ETag", out var values))
            {
                return null;
            }

            return global::System.Linq.Enumerable.FirstOrDefault(values);
        }
    }
}