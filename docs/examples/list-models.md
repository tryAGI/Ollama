# List Models



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
await using var container = await Environment.PrepareAsync(environmentType: EnvironmentType.Container);

var models = await container.Client.ListAsync();
var initialCount = models.Models?.Count ?? 0;

await container.Client.PullAsStreamAsync(TestModels.Embeddings).EnsureSuccessAsync();

models = await container.Client.ListAsync();
models.Models.Any(model =>
    model.Model != null &&
```