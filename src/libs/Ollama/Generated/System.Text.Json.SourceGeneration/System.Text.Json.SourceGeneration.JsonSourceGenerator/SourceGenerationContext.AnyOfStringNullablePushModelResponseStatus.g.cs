﻿// <auto-generated/>

#nullable enable annotations
#nullable disable warnings

// Suppress warnings about [Obsolete] member usage in generated code.
#pragma warning disable CS0612, CS0618

namespace Ollama
{
    internal sealed partial class SourceGenerationContext
    {
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>>? _AnyOfStringNullablePushModelResponseStatus;
        
        /// <summary>
        /// Defines the source generated JSON serialization contract metadata for a given type.
        /// </summary>
        public global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>> AnyOfStringNullablePushModelResponseStatus
        {
            get => _AnyOfStringNullablePushModelResponseStatus ??= (global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>>)Options.GetTypeInfo(typeof(global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>));
        }
        
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>> Create_AnyOfStringNullablePushModelResponseStatus(global::System.Text.Json.JsonSerializerOptions options)
        {
            if (!TryGetTypeInfoForRuntimeCustomConverter<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>>(options, out global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>> jsonTypeInfo))
            {
                var objectInfo = new global::System.Text.Json.Serialization.Metadata.JsonObjectInfoValues<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>>
                {
                    ObjectCreator = () => new global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>(),
                    ObjectWithParameterizedConstructorCreator = null,
                    PropertyMetadataInitializer = _ => AnyOfStringNullablePushModelResponseStatusPropInit(options),
                    ConstructorParameterMetadataInitializer = null,
                    SerializeHandler = null
                };
                
                jsonTypeInfo = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateObjectInfo<global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>>(options, objectInfo);
                jsonTypeInfo.NumberHandling = null;
            }
        
            jsonTypeInfo.OriginatingResolver = this;
            return jsonTypeInfo;
        }

        private static global::System.Text.Json.Serialization.Metadata.JsonPropertyInfo[] AnyOfStringNullablePushModelResponseStatusPropInit(global::System.Text.Json.JsonSerializerOptions options)
        {
            var properties = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfo[5];

            var info0 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<string>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>),
                Converter = null,
                Getter = static obj => ((global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>)obj).Value1,
                Setter = null,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Value1",
                JsonPropertyName = null
            };
            
            properties[0] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<string>(options, info0);

            var info1 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<bool>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>),
                Converter = null,
                Getter = static obj => ((global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>)obj).IsValue1,
                Setter = null,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "IsValue1",
                JsonPropertyName = null
            };
            
            properties[1] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<bool>(options, info1);

            var info2 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<global::Ollama.PushModelResponseStatus?>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>),
                Converter = null,
                Getter = static obj => ((global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>)obj).Value2,
                Setter = null,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Value2",
                JsonPropertyName = null
            };
            
            properties[2] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<global::Ollama.PushModelResponseStatus?>(options, info2);

            var info3 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<bool>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>),
                Converter = null,
                Getter = static obj => ((global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>)obj).IsValue2,
                Setter = null,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "IsValue2",
                JsonPropertyName = null
            };
            
            properties[3] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<bool>(options, info3);

            var info4 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<object>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>),
                Converter = null,
                Getter = static obj => ((global::System.AnyOf<string, global::Ollama.PushModelResponseStatus?>)obj).Object,
                Setter = null,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Object",
                JsonPropertyName = null
            };
            
            properties[4] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<object>(options, info4);

            return properties;
        }
    }
}
