using System.Text.Json.Serialization;

namespace Ollama;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(OpenApiGeneratorTrimmableSupport))]
internal sealed partial class SourceGenerationContext : JsonSerializerContext;