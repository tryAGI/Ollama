using System.Text.Json.Serialization;

namespace Ollama;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(JsonSerializerContextTypes))]
internal sealed partial class SourceGenerationContext : JsonSerializerContext;