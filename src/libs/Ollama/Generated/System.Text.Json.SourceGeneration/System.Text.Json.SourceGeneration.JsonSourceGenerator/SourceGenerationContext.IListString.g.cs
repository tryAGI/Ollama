﻿// <auto-generated/>

#nullable enable annotations
#nullable disable warnings

// Suppress warnings about [Obsolete] member usage in generated code.
#pragma warning disable CS0612, CS0618

namespace Ollama
{
    internal sealed partial class SourceGenerationContext
    {
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IList<string>>? _IListString;
        
        /// <summary>
        /// Defines the source generated JSON serialization contract metadata for a given type.
        /// </summary>
        public global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IList<string>> IListString
        {
            get => _IListString ??= (global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IList<string>>)Options.GetTypeInfo(typeof(global::System.Collections.Generic.IList<string>));
        }
        
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IList<string>> Create_IListString(global::System.Text.Json.JsonSerializerOptions options)
        {
            if (!TryGetTypeInfoForRuntimeCustomConverter<global::System.Collections.Generic.IList<string>>(options, out global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IList<string>> jsonTypeInfo))
            {
                var info = new global::System.Text.Json.Serialization.Metadata.JsonCollectionInfoValues<global::System.Collections.Generic.IList<string>>
                {
                    ObjectCreator = null,
                    SerializeHandler = IListStringSerializeHandler
                };
                
                jsonTypeInfo = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateIListInfo<global::System.Collections.Generic.IList<string>, string>(options, info);
                jsonTypeInfo.NumberHandling = null;
            }
        
            jsonTypeInfo.OriginatingResolver = this;
            return jsonTypeInfo;
        }

        // Intentionally not a static method because we create a delegate to it. Invoking delegates to instance
        // methods is almost as fast as virtual calls. Static methods need to go through a shuffle thunk.
        private void IListStringSerializeHandler(global::System.Text.Json.Utf8JsonWriter writer, global::System.Collections.Generic.IList<string>? value)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            
            writer.WriteStartArray();

            for (int i = 0; i < value.Count; i++)
            {
                writer.WriteStringValue(value[i]);
            }

            writer.WriteEndArray();
        }
    }
}
