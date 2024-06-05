﻿// <auto-generated/>

#nullable enable annotations
#nullable disable warnings

// Suppress warnings about [Obsolete] member usage in generated code.
#pragma warning disable CS0612, CS0618

namespace Ollama
{
    internal sealed partial class SourceGenerationContext
    {
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.CreateModelResponseStatus>? _CreateModelResponseStatus;
        
        /// <summary>
        /// Defines the source generated JSON serialization contract metadata for a given type.
        /// </summary>
        public global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.CreateModelResponseStatus> CreateModelResponseStatus
        {
            get => _CreateModelResponseStatus ??= (global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.CreateModelResponseStatus>)Options.GetTypeInfo(typeof(global::Ollama.CreateModelResponseStatus));
        }
        
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.CreateModelResponseStatus> Create_CreateModelResponseStatus(global::System.Text.Json.JsonSerializerOptions options)
        {
            if (!TryGetTypeInfoForRuntimeCustomConverter<global::Ollama.CreateModelResponseStatus>(options, out global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::Ollama.CreateModelResponseStatus> jsonTypeInfo))
            {
                jsonTypeInfo = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateValueInfo<global::Ollama.CreateModelResponseStatus>(options, global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.GetEnumConverter<global::Ollama.CreateModelResponseStatus>(options));
            }
        
            jsonTypeInfo.OriginatingResolver = this;
            return jsonTypeInfo;
        }
    }
}
