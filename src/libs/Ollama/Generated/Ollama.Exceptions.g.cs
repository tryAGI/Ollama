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
        /// The response body.
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
        public ApiException(string message, global::System.Exception innerException, global::System.Net.HttpStatusCode statusCode) : base(message, innerException)
        {
            StatusCode = statusCode;
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
        public ApiException(string message, global::System.Exception innerException, global::System.Net.HttpStatusCode statusCode) : base(message, innerException, statusCode)
        {
        }
    }
}