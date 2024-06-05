﻿// <auto-generated/>

#nullable enable annotations
#nullable disable warnings

// Suppress warnings about [Obsolete] member usage in generated code.
#pragma warning disable CS0612, CS0618

namespace Ollama
{
    internal sealed partial class SourceGenerationContext
    {
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.PullModelRequest>? _PullModelRequest;
        
        /// <summary>
        /// Defines the source generated JSON serialization contract metadata for a given type.
        /// </summary>
        public global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.PullModelRequest> PullModelRequest
        {
            get => _PullModelRequest ??= (global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.PullModelRequest>)Options.GetTypeInfo(typeof(global::Ollama.PullModelRequest));
        }
        
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.PullModelRequest> Create_PullModelRequest(global::System.Text.Json.JsonSerializerOptions options)
        {
            if (!TryGetTypeInfoForRuntimeCustomConverter<global::Ollama.PullModelRequest>(options, out global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.PullModelRequest> jsonTypeInfo))
            {
                var objectInfo = new global::System.Text.Json.Serialization.Metadata.JsonObjectInfoValues<global::Ollama.PullModelRequest>
                {
                    ObjectCreator = () => new global::Ollama.PullModelRequest(),
                    ObjectWithParameterizedConstructorCreator = null,
                    PropertyMetadataInitializer = _ => PullModelRequestPropInit(options),
                    ConstructorParameterMetadataInitializer = null,
                    SerializeHandler = null
                };
                
                jsonTypeInfo = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateObjectInfo<global::Ollama.PullModelRequest>(options, objectInfo);
                jsonTypeInfo.NumberHandling = null;
            }
        
            jsonTypeInfo.OriginatingResolver = this;
            return jsonTypeInfo;
        }

        private static global::System.Text.Json.Serialization.Metadata.JsonPropertyInfo[] PullModelRequestPropInit(global::System.Text.Json.JsonSerializerOptions options)
        {
            var properties = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfo[6];

            var info0 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<string>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PullModelRequest),
                Converter = null,
                Getter = static obj => ((global::Ollama.PullModelRequest)obj).Model,
                Setter = static (obj, value) => ((global::Ollama.PullModelRequest)obj).Model = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Model",
                JsonPropertyName = "model"
            };
            
            properties[0] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<string>(options, info0);
            properties[0].IsRequired = true;

            var info1 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<bool>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PullModelRequest),
                Converter = null,
                Getter = static obj => ((global::Ollama.PullModelRequest)obj).Insecure,
                Setter = static (obj, value) => ((global::Ollama.PullModelRequest)obj).Insecure = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Insecure",
                JsonPropertyName = "insecure"
            };
            
            properties[1] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<bool>(options, info1);

            var info2 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<string>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PullModelRequest),
                Converter = null,
                Getter = static obj => ((global::Ollama.PullModelRequest)obj).Username,
                Setter = static (obj, value) => ((global::Ollama.PullModelRequest)obj).Username = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Username",
                JsonPropertyName = "username"
            };
            
            properties[2] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<string>(options, info2);

            var info3 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<string>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PullModelRequest),
                Converter = null,
                Getter = static obj => ((global::Ollama.PullModelRequest)obj).Password,
                Setter = static (obj, value) => ((global::Ollama.PullModelRequest)obj).Password = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Password",
                JsonPropertyName = "password"
            };
            
            properties[3] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<string>(options, info3);

            var info4 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<bool>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PullModelRequest),
                Converter = null,
                Getter = static obj => ((global::Ollama.PullModelRequest)obj).Stream,
                Setter = static (obj, value) => ((global::Ollama.PullModelRequest)obj).Stream = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Stream",
                JsonPropertyName = "stream"
            };
            
            properties[4] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<bool>(options, info4);

            var info5 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<global::System.Collections.Generic.IDictionary<string, object>>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PullModelRequest),
                Converter = null,
                Getter = static obj => ((global::Ollama.PullModelRequest)obj).AdditionalProperties,
                Setter = static (obj, value) => ((global::Ollama.PullModelRequest)obj).AdditionalProperties = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = true,
                NumberHandling = null,
                PropertyName = "AdditionalProperties",
                JsonPropertyName = null
            };
            
            properties[5] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<global::System.Collections.Generic.IDictionary<string, object>>(options, info5);

            return properties;
        }
    }
}
