﻿// <auto-generated/>

#nullable enable annotations
#nullable disable warnings

// Suppress warnings about [Obsolete] member usage in generated code.
#pragma warning disable CS0612, CS0618

namespace Ollama
{
    internal sealed partial class SourceGenerationContext
    {
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.PushModelResponse>? _PushModelResponse;
        
        /// <summary>
        /// Defines the source generated JSON serialization contract metadata for a given type.
        /// </summary>
        public global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.PushModelResponse> PushModelResponse
        {
            get => _PushModelResponse ??= (global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.PushModelResponse>)Options.GetTypeInfo(typeof(global::Ollama.PushModelResponse));
        }
        
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.PushModelResponse> Create_PushModelResponse(global::System.Text.Json.JsonSerializerOptions options)
        {
            if (!TryGetTypeInfoForRuntimeCustomConverter<global::Ollama.PushModelResponse>(options, out global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.PushModelResponse> jsonTypeInfo))
            {
                var objectInfo = new global::System.Text.Json.Serialization.Metadata.JsonObjectInfoValues<global::Ollama.PushModelResponse>
                {
                    ObjectCreator = () => new global::Ollama.PushModelResponse(),
                    ObjectWithParameterizedConstructorCreator = null,
                    PropertyMetadataInitializer = _ => PushModelResponsePropInit(options),
                    ConstructorParameterMetadataInitializer = null,
                    SerializeHandler = null
                };
                
                jsonTypeInfo = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateObjectInfo<global::Ollama.PushModelResponse>(options, objectInfo);
                jsonTypeInfo.NumberHandling = null;
            }
        
            jsonTypeInfo.OriginatingResolver = this;
            return jsonTypeInfo;
        }

        private static global::System.Text.Json.Serialization.Metadata.JsonPropertyInfo[] PushModelResponsePropInit(global::System.Text.Json.JsonSerializerOptions options)
        {
            var properties = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfo[5];

            var info0 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PushModelResponse),
                Converter = (global::System.Text.Json.Serialization.JsonConverter<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>>)ExpandConverter(typeof(global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>), new global::OpenApiGenerator.JsonConverters.AnyOfJsonConverterFactory2(), options),
                Getter = static obj => ((global::Ollama.PushModelResponse)obj).Status,
                Setter = static (obj, value) => ((global::Ollama.PushModelResponse)obj).Status = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Status",
                JsonPropertyName = "status"
            };
            
            properties[0] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>>(options, info0);

            var info1 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<string>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PushModelResponse),
                Converter = null,
                Getter = static obj => ((global::Ollama.PushModelResponse)obj).Digest,
                Setter = static (obj, value) => ((global::Ollama.PushModelResponse)obj).Digest = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Digest",
                JsonPropertyName = "digest"
            };
            
            properties[1] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<string>(options, info1);

            var info2 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<long>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PushModelResponse),
                Converter = null,
                Getter = static obj => ((global::Ollama.PushModelResponse)obj).Total,
                Setter = static (obj, value) => ((global::Ollama.PushModelResponse)obj).Total = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Total",
                JsonPropertyName = "total"
            };
            
            properties[2] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<long>(options, info2);

            var info3 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<long>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PushModelResponse),
                Converter = null,
                Getter = static obj => ((global::Ollama.PushModelResponse)obj).Completed,
                Setter = static (obj, value) => ((global::Ollama.PushModelResponse)obj).Completed = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Completed",
                JsonPropertyName = "completed"
            };
            
            properties[3] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<long>(options, info3);

            var info4 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<global::System.Collections.Generic.IDictionary<string, object>>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::Ollama.PushModelResponse),
                Converter = null,
                Getter = static obj => ((global::Ollama.PushModelResponse)obj).AdditionalProperties,
                Setter = static (obj, value) => ((global::Ollama.PushModelResponse)obj).AdditionalProperties = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = true,
                NumberHandling = null,
                PropertyName = "AdditionalProperties",
                JsonPropertyName = null
            };
            
            properties[4] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<global::System.Collections.Generic.IDictionary<string, object>>(options, info4);

            return properties;
        }
    }
}
