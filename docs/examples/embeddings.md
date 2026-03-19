# Embeddings



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
await using var container = await Environment.PrepareAsync(TestModels.Embeddings);

var embeddingResponse = await container.Client.EmbedAsync(
    model: TestModels.Embeddings,
    input: "hello");
```