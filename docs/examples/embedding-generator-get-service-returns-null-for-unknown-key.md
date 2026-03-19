# Embedding Generator Get Service Returns Null For Unknown Key



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
using var client = new OllamaClient();
IEmbeddingGenerator<string, Embedding<float>> generator = client;

var result = generator.GetService<EmbeddingGeneratorMetadata>(serviceKey: "unknown");
```