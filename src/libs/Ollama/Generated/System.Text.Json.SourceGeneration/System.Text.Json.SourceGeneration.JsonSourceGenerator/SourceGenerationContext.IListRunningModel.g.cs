﻿// <auto-generated/>

#nullable enable annotations
#nullable disable warnings

// Suppress warnings about [Obsolete] member usage in generated code.
#pragma warning disable CS0612, CS0618

namespace Ollama
{
    internal sealed partial class SourceGenerationContext
    {
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IList<global::Ollama.RunningModel>>? _IListRunningModel;
        
        /// <summary>
        /// Defines the source generated JSON serialization contract metadata for a given type.
        /// </summary>
        public global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IList<global::Ollama.RunningModel>> IListRunningModel
        {
            get => _IListRunningModel ??= (global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IList<global::Ollama.RunningModel>>)Options.GetTypeInfo(typeof(global::System.Collections.Generic.IList<global::Ollama.RunningModel>));
        }
        
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IList<global::Ollama.RunningModel>> Create_IListRunningModel(global::System.Text.Json.JsonSerializerOptions options)
        {
            if (!TryGetTypeInfoForRuntimeCustomConverter<global::System.Collections.Generic.IList<global::Ollama.RunningModel>>(options, out global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IList<global::Ollama.RunningModel>> jsonTypeInfo))
            {
                var info = new global::System.Text.Json.Serialization.Metadata.JsonCollectionInfoValues<global::System.Collections.Generic.IList<global::Ollama.RunningModel>>
                {
                    ObjectCreator = null,
                    SerializeHandler = IListRunningModelSerializeHandler
                };
                
                jsonTypeInfo = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateIListInfo<global::System.Collections.Generic.IList<global::Ollama.RunningModel>, global::Ollama.RunningModel>(options, info);
                jsonTypeInfo.NumberHandling = null;
            }
        
            jsonTypeInfo.OriginatingResolver = this;
            return jsonTypeInfo;
        }

        // Intentionally not a static method because we create a delegate to it. Invoking delegates to instance
        // methods is almost as fast as virtual calls. Static methods need to go through a shuffle thunk.
        private void IListRunningModelSerializeHandler(global::System.Text.Json.Utf8JsonWriter writer, global::System.Collections.Generic.IList<global::Ollama.RunningModel>? value)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            
            writer.WriteStartArray();

            for (int i = 0; i < value.Count; i++)
            {
                global::System.Text.Json.JsonSerializer.Serialize(writer, value[i], RunningModel);
            }

            writer.WriteEndArray();
        }
    }
}
