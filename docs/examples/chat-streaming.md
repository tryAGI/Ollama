# Chat Streaming



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
await using var container = await Environment.PrepareAsync(TestModels.Chat);

var chat = container.Client.Chat(TestModels.Chat);
var deltas = new List<string>();
var message = await chat.SendAsync(
    message: "answer 5 random words",
    onResponseChunk: (isFirstChunk, chunk) =>
    {
        if (isFirstChunk)
        {
            Console.Write("> ");
        }

        if (chunk != null)
        {
            deltas.Add(chunk);
            Console.Write(chunk);
        }
    });

Console.WriteLine();
```