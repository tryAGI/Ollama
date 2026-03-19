# Pull Model



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
await using var container = await Environment.PrepareAsync(environmentType: EnvironmentType.Container);

await foreach (var response in container.Client.PullAsStreamAsync(TestModels.Embeddings))
{
    Console.WriteLine($"{response.Status}. Progress: {response.Completed}/{response.Total}");
}

var responses = await container.Client.PullAsStreamAsync(TestModels.Embeddings);
responses[^1].EnsureSuccess();

await container.Client.PullAsStreamAsync(TestModels.Embeddings).EnsureSuccessAsync();
```