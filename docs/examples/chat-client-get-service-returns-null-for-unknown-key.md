# Chat Client Get Service Returns Null For Unknown Key



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
using var client = new OllamaClient();
IChatClient chatClient = client;

var result = chatClient.GetService<ChatClientMetadata>(serviceKey: "unknown");
```