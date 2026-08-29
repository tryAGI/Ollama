#nullable enable

namespace Ollama
{
    /// <summary>
    /// Represents an exception thrown by the API.
    /// </summary>
    [global::System.Serializable]
    public partial class ApiException : global::System.Exception
    {
        /// <summary>
        /// The HTTP status code of the response.
        /// </summary>
        public global::System.Net.HttpStatusCode StatusCode { get; }

        /// <summary>
        /// The response body as a string, or <c>null</c> if the body could not be read.
        /// This is always populated for error responses regardless of the <c>ReadResponseAsString</c> setting.
        /// For success-path failures (e.g. deserialization errors), the client attempts a best-effort read.
        /// </summary>
        public string? ResponseBody { get; set; }

        /// <summary>
        /// The response headers.
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IEnumerable<string>>? ResponseHeaders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        public ApiException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="statusCode">The HTTP status code of the response.</param>
        public ApiException(string message, global::System.Net.HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        /// <param name="statusCode">The HTTP status code of the response.</param>
        public ApiException(string message, global::System.Exception? innerException, global::System.Net.HttpStatusCode statusCode) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Constructs an <see cref="ApiException"/> instance whose runtime type matches the response status code when the typed exception hierarchy is enabled. Always returns a plain <see cref="ApiException"/> when the hierarchy is disabled.
        /// </summary>
        /// <param name="statusCode">The HTTP status code of the response.</param>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">An inner exception, when one is available.</param>
        /// <param name="responseHeaders">The response headers; consulted for 429 <c>Retry-After</c> parsing when present.</param>
        public static global::Ollama.ApiException Create(
            global::System.Net.HttpStatusCode statusCode,
            string message,
            global::System.Exception? innerException = null,
            global::System.Collections.Generic.IDictionary<string, global::System.Collections.Generic.IEnumerable<string>>? responseHeaders = null)
        {
            return new global::Ollama.ApiException(message, innerException, statusCode);
        }

        /// <summary>
        /// Convenience overload that constructs an <see cref="ApiException"/> with response body and headers populated.
        /// </summary>
        public static global::Ollama.ApiException Create(
            global::System.Net.HttpStatusCode statusCode,
            string message,
            global::System.Exception? innerException,
            string? responseBody,
            global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IEnumerable<string>>? responseHeaders)
        {
            var exception = global::Ollama.ApiException.Create(statusCode, message, innerException, responseHeaders);
            exception.ResponseBody = responseBody;
            exception.ResponseHeaders = responseHeaders;
            return exception;
        }

        /// <summary>
        /// Parses a <c>Retry-After</c> response header (delta-seconds or HTTP-date) into a <see cref="global::System.TimeSpan"/>.
        /// Returns <c>null</c> when the header is missing or unparseable. Public so consumer code that observes
        /// <see cref="ApiException"/> directly can recover the value without re-implementing the parser.
        /// </summary>
        public static global::System.TimeSpan? TryParseRetryAfter(
            global::System.Collections.Generic.IDictionary<string, global::System.Collections.Generic.IEnumerable<string>>? headers)
        {
            if (headers == null)
            {
                return null;
            }

            global::System.Collections.Generic.IEnumerable<string>? values = null;
            foreach (var entry in headers)
            {
                if (string.Equals(entry.Key, "Retry-After", global::System.StringComparison.OrdinalIgnoreCase))
                {
                    values = entry.Value;
                    break;
                }
            }

            if (values == null)
            {
                return null;
            }

            string? raw = null;
            foreach (var value in values)
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    raw = value.Trim();
                    break;
                }
            }

            if (string.IsNullOrEmpty(raw))
            {
                return null;
            }

            if (int.TryParse(
                raw,
                global::System.Globalization.NumberStyles.Integer,
                global::System.Globalization.CultureInfo.InvariantCulture,
                out var seconds) && seconds >= 0)
            {
                return global::System.TimeSpan.FromSeconds(seconds);
            }

            if (global::System.DateTimeOffset.TryParse(
                raw,
                global::System.Globalization.CultureInfo.InvariantCulture,
                global::System.Globalization.DateTimeStyles.AssumeUniversal | global::System.Globalization.DateTimeStyles.AdjustToUniversal,
                out var when))
            {
                var delta = when - global::System.DateTimeOffset.UtcNow;
                return delta > global::System.TimeSpan.Zero ? delta : global::System.TimeSpan.Zero;
            }

            return null;
        }
    }

    /// <summary>
    /// Represents an exception thrown by the API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [global::System.Serializable]
    public partial class ApiException<T> : ApiException
    {
        /// <summary>
        /// The response object.
        /// </summary>
        public T? ResponseObject { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        public ApiException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="statusCode">The HTTP status code of the response.</param>
        public ApiException(string message, global::System.Net.HttpStatusCode statusCode) : base(message, statusCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        /// <param name="statusCode">The HTTP status code of the response.</param>
        public ApiException(string message, global::System.Exception? innerException, global::System.Net.HttpStatusCode statusCode) : base(message, innerException, statusCode)
        {
        }

        /// <summary>
        /// Constructs an <see cref="ApiException{T}"/> whose runtime type matches the response status code when the typed exception hierarchy is enabled.
        /// </summary>
        /// <param name="statusCode">The HTTP status code of the response.</param>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">An inner exception, when one is available.</param>
        /// <param name="responseHeaders">The response headers; consulted for 429 <c>Retry-After</c> parsing when present.</param>
        public static new global::Ollama.ApiException<T> Create(
            global::System.Net.HttpStatusCode statusCode,
            string message,
            global::System.Exception? innerException = null,
            global::System.Collections.Generic.IDictionary<string, global::System.Collections.Generic.IEnumerable<string>>? responseHeaders = null)
        {
            return new global::Ollama.ApiException<T>(message, innerException, statusCode);
        }

        /// <summary>
        /// Convenience overload that constructs an <see cref="ApiException{T}"/> with response body, object, and headers populated.
        /// </summary>
        public static global::Ollama.ApiException<T> Create(
            global::System.Net.HttpStatusCode statusCode,
            string message,
            global::System.Exception? innerException,
            string? responseBody,
            T? responseObject,
            global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IEnumerable<string>>? responseHeaders)
        {
            var exception = global::Ollama.ApiException<T>.Create(statusCode, message, innerException, responseHeaders);
            exception.ResponseBody = responseBody;
            exception.ResponseObject = responseObject;
            exception.ResponseHeaders = responseHeaders;
            return exception;
        }
    }
}