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
IList<long>? context = null;
var enumerable = api.GetCompletionAsync("mistral", "How are you today?");
await foreach (var response in enumerable)
{
    Console.Write(response.Response);
    
    context = response.Context;
}

var lastResponse = await api.GetCompletionAsync("mistral", "How are you today?", stream: false).WaitAsync();
context = response.lastResponse;
Console.WriteLine(lastResponse.Response);

var chat = container.ApiClient.Chat("mistral");
while (true)
{
    var message = await chat.SendAsync("answer 123");
    
    Console.WriteLine(message.Content);
    
    var newMessage = Console.ReadLine();
    await chat.Send(newMessage);
}
```

## Credits

Icon and name were reused from the amazing [Ollama project](https://github.com/jmorganca/ollama).
The project was forked from [this repository](https://github.com/awaescher/OllamaSharp), 
after which automatic code generation was applied based on [this OpenAPI specification](https://github.com/davidmigloz/langchain_dart/blob/main/packages/ollama_dart/oas/ollama-curated.yaml) 
(in the future it will be replaced by the official one, if one appears)
