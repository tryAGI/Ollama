# Ollama SDK for .NET 🦙

[![Nuget package](https://img.shields.io/nuget/vpre/Ollama)](https://www.nuget.org/packages/Ollama/)
[![dotnet](https://github.com/tryAGI/Ollama/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/tryAGI/Ollama/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/github/license/tryAGI/Ollama)](https://github.com/tryAGI/Ollama/blob/main/LICENSE.txt)
[![Discord](https://img.shields.io/discord/1115206893015662663?label=Discord&logo=discord&logoColor=white&color=d82679)](https://discord.gg/Ca2xhfBf3v)

## Features 🔥
- Fully generated C# SDK based on the official [Ollama OpenAPI specification](https://github.com/ollama/ollama/blob/main/docs/openapi.yaml) using [AutoSDK](https://github.com/tryAGI/AutoSDK)
- Automatic releases of new preview versions when the official OpenAPI specification changes
- Source generator to define tools natively through C# interfaces
- All modern .NET features - nullability, trimming, NativeAOT, etc.
- Support .Net Framework/.Net Standard 2.0
- Support for all Ollama API endpoints including chats, embeddings, listing models, pulling and creating new models, and more.
- Support for [Microsoft.Extensions.AI](https://learn.microsoft.com/dotnet/ai/microsoft-extensions-ai/)

## Usage

### Initializing

```csharp
using var ollama = new OllamaClient();
// or if you have a custom server
// using var ollama = new OllamaClient(baseUri: new Uri("http://10.10.5.85:11434"));

var models = await ollama.ListAsync();

// Pulling a model and reporting progress
await foreach (var response in ollama.PullAsStreamAsync("all-minilm"))
{
    Console.WriteLine($"{response.Status}. Progress: {response.Completed}/{response.Total}");
}
// or just pull the model and wait for it to finish
await ollama.PullAsStreamAsync("all-minilm").EnsureSuccessAsync();

// Generating an embedding
var embedding = await ollama.EmbedAsync(
    model: "all-minilm",
    input: "hello");

// Streaming a completion directly into the console
var enumerable = ollama.GenerateAsStreamAsync("llama3.2", "answer 5 random words");
await foreach (var response in enumerable)
{
    Console.WriteLine($"> {response.Response}");
}

var lastResponse = await ollama.GenerateAsync("llama3.2", "answer 123");
Console.WriteLine(lastResponse.Response);

var chat = ollama.Chat("mistral");
while (true)
{
    var message = await chat.SendAsync("answer 123");
    
    Console.WriteLine(message.Content);
    
    var newMessage = Console.ReadLine();
    await chat.SendAsync(newMessage);
}
```

### Tools
```csharp
using var ollama = new OllamaClient();
var chat = ollama.Chat(
    model: "llama3.2",
    systemMessage: "You are a helpful weather assistant.",
    autoCallTools: true);

var service = new WeatherService();
chat.AddToolService(service.AsTools().AsOllamaTools(), service.AsCalls());

try
{
    _ = await chat.SendAsync("What is the current temperature in Dubai, UAE in Celsius?");
}
finally
{
    Console.WriteLine(chat.PrintMessages());
}
```
```
> System:
You are a helpful weather assistant.
> User:
What is the current temperature in Dubai, UAE in Celsius?
> Assistant:
Tool calls:
GetCurrentWeather({"location":"Dubai, UAE","unit":"celsius"})
> Tool:
{"location":"Dubai, UAE","temperature":22,"unit":"celsius","description":"Sunny"}
> Assistant:
The current temperature in Dubai, UAE is 22°C.
```
```csharp
using CSharpToJsonSchema;

public enum Unit
{
    Celsius,
    Fahrenheit,
}

public class Weather
{
    public string Location { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public Unit Unit { get; set; }
    public string Description { get; set; } = string.Empty;
}

[GenerateJsonSchema]
public interface IWeatherFunctions
{
    [Description("Get the current weather in a given location")]
    public Task<Weather> GetCurrentWeatherAsync(
        [Description("The city and state, e.g. San Francisco, CA")] string location,
        Unit unit = Unit.Celsius,
        CancellationToken cancellationToken = default);
}

public class WeatherService : IWeatherFunctions
{
    public Task<Weather> GetCurrentWeatherAsync(string location, Unit unit = Unit.Celsius, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new Weather
        {
            Location = location,
            Temperature = 22.0,
            Unit = unit,
            Description = "Sunny",
        });
    }
}
```

### Microsoft.Extensions.AI

The SDK implements [`IChatClient`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.ichatclient) and [`IEmbeddingGenerator`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.iembeddinggenerator-2):
```csharp
using Ollama;
using Microsoft.Extensions.AI;

using var ollama = new OllamaClient();

// IChatClient
IChatClient chatClient = ollama;
var response = await chatClient.GetResponseAsync(
    [new ChatMessage(ChatRole.User, "Hello!")],
    new ChatOptions { ModelId = "llama3.2" });

Console.WriteLine(response.Text);

// IEmbeddingGenerator
IEmbeddingGenerator<string, Embedding<float>> generator = ollama;
var embeddings = await generator.GenerateAsync(
    ["Hello, world!"],
    new EmbeddingGenerationOptions { ModelId = "all-minilm" });

Console.WriteLine($"Dimensions: {embeddings[0].Vector.Length}");
```

## Community Projects

Projects built on top of this SDK:

### LangMate
[LangMate](https://github.com/raminesfahani/LangMate) - A modular and extensible AI chat application platform built on this SDK:
- **LangMate.Core SDK** - Developer-friendly wrapper for easy Ollama integration in .NET apps
- **Blazor Server Chat UI** - Real-time, interactive chat interface with streaming responses
- **RESTful Web API** - Backend service with OpenAPI documentation (Scalar integration)
- **MongoDB Integration** - Persistent chat history and caching layer
- **Polly-Based Resilience** - Circuit breakers, retry logic, and timeout policies
- **File Upload Support** - Multimodal capabilities with base64 image preview for vision models
- **.NET Aspire Compatible** - Full orchestration support for Docker/Kubernetes deployment
- Production-ready .NET 9 implementation with clean, testable architecture

## Credits

Icon and name were reused from the amazing [Ollama project](https://github.com/jmorganca/ollama).  
The project was forked from [this repository](https://github.com/awaescher/OllamaSharp), 
after which automatic code generation was applied based on the official [Ollama OpenAPI specification](https://github.com/ollama/ollama/blob/main/docs/openapi.yaml).

<!-- EXAMPLES:START -->
<!-- EXAMPLES:END -->

## Support

Priority place for bugs: https://github.com/tryAGI/Ollama/issues  
Priority place for ideas and general questions: https://github.com/tryAGI/Ollama/discussions  
Discord: https://discord.gg/Ca2xhfBf3v  

## Acknowledgments

![JetBrains logo](https://resources.jetbrains.com/storage/products/company/brand/logos/jetbrains.png)

This project is supported by JetBrains through the [Open Source Support Program](https://jb.gg/OpenSourceSupport).

![CodeRabbit logo](https://opengraph.githubassets.com/1c51002d7d0bbe0c4fd72ff8f2e58192702f73a7037102f77e4dbb98ac00ea8f/marketplace/coderabbitai)

This project is supported by CodeRabbit through the [Open Source Support Program](https://github.com/marketplace/coderabbitai).
