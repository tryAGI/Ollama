# Get Completion With Options



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
await using var container = await Environment.PrepareAsync(TestModels.Chat);

var response = await container.Client.GenerateAsync(new GenerateRequest
{
    Model = TestModels.Chat,
    Prompt = "answer me just \"123\"",
    Options = new ModelOptions
    {
        Temperature = 0,
    },
});
Console.WriteLine(response.Response);
```