﻿// <auto-generated/>

#nullable enable annotations
#nullable disable warnings

// Suppress warnings about [Obsolete] member usage in generated code.
#pragma warning disable CS0612, CS0618

namespace Ollama
{
    internal sealed partial class SourceGenerationContext
    {
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.DateTime>? _DateTime;
        
        /// <summary>
        /// Defines the source generated JSON serialization contract metadata for a given type.
        /// </summary>
        public global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.DateTime> DateTime
        {
            get => _DateTime ??= (global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.DateTime>)Options.GetTypeInfo(typeof(global::System.DateTime));
        }
        
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.DateTime> Create_DateTime(global::System.Text.Json.JsonSerializerOptions options)
        {
            if (!TryGetTypeInfoForRuntimeCustomConverter<global::System.DateTime>(options, out global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.DateTime> jsonTypeInfo))
            {
                jsonTypeInfo = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateValueInfo<global::System.DateTime>(options, global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.DateTimeConverter);
            }
        
            jsonTypeInfo.OriginatingResolver = this;
            return jsonTypeInfo;
        }
    }
}
