# Embedding Generator Get Service Returns Embedding Generator Metadata



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
using var client = new OllamaClient();
IEmbeddingGenerator<string, Embedding<float>> generator = client;

var metadata = generator.GetService<EmbeddingGeneratorMetadata>();
```