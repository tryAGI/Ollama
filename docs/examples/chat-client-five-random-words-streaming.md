# Chat Client Five Random Words Streaming



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
await using var environment = await Environment.PrepareAsync(TestModels.Chat);

IChatClient client = environment.Client;
var updates = client.GetStreamingResponseAsync(
    messages:
    [
        new MeaiChatMessage(MeaiChatRole.User, "Generate 5 random words.")
    ],
    options: new ChatOptions
    {
        ModelId = TestModels.Chat,
    });

var deltas = new List<string>();
await foreach (var update in updates)
{
    if (!string.IsNullOrWhiteSpace(update.Text))
    {
        deltas.Add(update.Text);
    }
}
```