# Chat Client Get Service Returns Chat Client Metadata



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

```csharp
using var client = new OllamaClient();
IChatClient chatClient = client;

var metadata = chatClient.GetService<ChatClientMetadata>();
```