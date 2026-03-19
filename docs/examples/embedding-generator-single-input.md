# Embedding Generator Single Input



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
await using var environment = await Environment.PrepareAsync(TestModels.Embeddings);

IEmbeddingGenerator<string, Embedding<float>> generator = environment.Client;
var result = await generator.GenerateAsync(
    values: ["Hello, world!"],
    options: new EmbeddingGenerationOptions
    {
        ModelId = TestModels.Embeddings,
    });
```