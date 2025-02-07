
#nullable enable

namespace Ollama
{
    /// <summary>
    /// Request class for pushing a model.
    /// </summary>
    public sealed partial class PushModelRequest
    {
        /// <summary>
        /// The name of the model to push in the form of &lt;namespace&gt;/&lt;model&gt;:&lt;tag&gt;.<br/>
        /// Example: mattw/pygmalion:latest
        /// </summary>
        /// <example>mattw/pygmalion:latest</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Model { get; set; }

        /// <summary>
        /// Allow insecure connections to the library. <br/>
        /// Only use this if you are pushing to your library during development.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("insecure")]
        public bool? Insecure { get; set; }

        /// <summary>
        /// Ollama username.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("username")]
        public string? Username { get; set; }

        /// <summary>
        /// Ollama password.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("password")]
        public string? Password { get; set; }

        /// <summary>
        /// If `false` the response will be returned as a single response object, otherwise the response will be streamed as a series of objects.<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("stream")]
        public bool? Stream { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PushModelRequest" /> class.
        /// </summary>
        /// <param name="model">
        /// The name of the model to push in the form of &lt;namespace&gt;/&lt;model&gt;:&lt;tag&gt;.<br/>
        /// Example: mattw/pygmalion:latest
        /// </param>
        /// <param name="insecure">
        /// Allow insecure connections to the library. <br/>
        /// Only use this if you are pushing to your library during development.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="username">
        /// Ollama username.
        /// </param>
        /// <param name="password">
        /// Ollama password.
        /// </param>
        /// <param name="stream">
        /// If `false` the response will be returned as a single response object, otherwise the response will be streamed as a series of objects.<br/>
        /// Default Value: true
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public PushModelRequest(
            string model,
            bool? insecure,
            string? username,
            string? password,
            bool? stream)
        {
            this.Model = model ?? throw new global::System.ArgumentNullException(nameof(model));
            this.Insecure = insecure;
            this.Username = username;
            this.Password = password;
            this.Stream = stream;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PushModelRequest" /> class.
        /// </summary>
        public PushModelRequest()
        {
        }
    }
}