# Chat Client Get Service Returns Self



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
using var client = new OllamaClient();
IChatClient chatClient = client;

var self = chatClient.GetService<OllamaClient>();
```