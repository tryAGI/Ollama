# Ollama SDK for .NET 🦙

Generated C# SDK based on Ollama [OpenAPI specification](https://github.com/davidmigloz/langchain_dart/blob/main/packages/ollama_dart/oas/ollama-curated.yaml) and [official docs](https://github.com/jmorganca/ollama/blob/main/docs/api.md) using [OpenApiGenerator](https://github.com/HavenDV/OpenApiGenerator).

## Features 🔥

- Intuitive API client: Set up and interact with Ollama in just a few lines of code.
- API endpoint coverage: Support for all Ollama API endpoints including chats, embeddings, listing models, pulling and creating new models, and more.
- Real-time streaming: Stream responses directly to your application.
- Progress reporting: Get real-time progress feedback on tasks like model pulling.

## Usage

### Initializing

```csharp
using var ollama = new OllamaApiClient();

var models = await ollama.Models.ListModelsAsync();

// Pulling a model and reporting progress
await foreach (var response in ollama.PullModelAsync("all-minilm", stream: true))
{
    Console.WriteLine($"{response.Status}. Progress: {response.Completed}/{response.Total}");
}
// or just pull the model and wait for it to finish
await ollama.Models.PullModelAndEnsureSuccessAsync("all-minilm");

// Generating an embedding
var embedding = await ollama.Embeddings.GenerateEmbeddingAsync(
    model: "all-minilm",
    prompt: "hello");

// Streaming a completion directly into the console
// keep reusing the context to keep the chat topic going
IList<long>? context = null;
var enumerable = ollama.Completions.GenerateCompletionAsync("llama3", "answer 5 random words", stream: true);
await foreach (var response in enumerable)
{
    Console.WriteLine($"> {response.Response}");
    
    context = response.Context;
}

var lastResponse = await ollama.Completions.GenerateCompletionAsync("llama3", "answer 123", stream: false, context: context).WaitAsync();
Console.WriteLine(lastResponse.Response);

var chat = ollama.Chat("mistral");
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
