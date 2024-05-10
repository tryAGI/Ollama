# Ollama SDK for .NET 🦙

Generated C# SDK based on Ollama OpenAPI specification and [official docs](https://github.com/jmorganca/ollama/blob/main/docs/api.md) using OpenApiGenerator.  

## Features 🔥

- Intuitive API client: Set up and interact with Ollama in just a few lines of code.
- API endpoint coverage: Support for all Ollama API endpoints including chats, embeddings, listing models, pulling and creating new models, and more.
- Real-time streaming: Stream responses directly to your application.
- Progress reporting: Get real-time progress feedback on tasks like model pulling.

## Usage

### Initializing

```csharp
var ollama = new OllamaApiClient();

var models = await ollama.ListModelsAsync();

// Pulling a model and reporting progress
await ollama.PullModelAsync("mistral", status => Console.WriteLine($"({status.Percent}%) {status.Status}"));

// Streaming a completion directly into the console
// keep reusing the context to keep the chat topic going
ConversationContext context = null;
context = await ollama.StreamCompletionAsync("mistral", "How are you today?", context, stream => Console.Write(stream.Response));

// uses the /chat api from Ollama 0.1.14
// messages including their roles will automatically be tracked within the chat object
var chat = ollama.Chat("mistral", stream => Console.WriteLine(stream.Message?.Content ?? ""));
while (true)
{
    var message = Console.ReadLine();
    await chat.Send(message);
}
```

## Credits

Icon and name were reused from the amazing [Ollama project](https://github.com/jmorganca/ollama).
The project was forked from [this repository](https://github.com/awaescher/OllamaSharp), 
after which automatic code generation was applied based on [this OpenAPI specification](https://github.com/davidmigloz/langchain_dart/blob/main/packages/ollama_dart/oas/ollama-curated.yaml) 
(in the future it will be replaced by the official one, if one appears)
