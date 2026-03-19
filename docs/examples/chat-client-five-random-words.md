# Chat Client Five Random Words



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
await using var environment = await Environment.PrepareAsync(TestModels.Chat);

IChatClient client = environment.Client;
var response = await client.GetResponseAsync(
    messages:
    [
        new MeaiChatMessage(MeaiChatRole.User, "Generate 5 random words.")
    ],
    options: new ChatOptions
    {
        ModelId = TestModels.Chat,
    });
```