# Chat



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
await using var container = await Environment.PrepareAsync(TestModels.Chat);

var chat = container.Client.Chat(TestModels.Chat);
var message = await chat.SendAsync("answer 5 random words");

Console.WriteLine(message.Content);
```