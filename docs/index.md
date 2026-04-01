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

### Streaming Chat State
```csharp
using var ollama = new OllamaClient();
var chat = ollama.Chat("mistral");

var message = await chat.SendAsync(
    message: "answer 5 random words",
    onResponseChunk: (isFirstChunk, chunk) =>
    {
        if (isFirstChunk)
        {
            Console.Write("> ");
        }

        Console.Write(chunk);
    });

Console.WriteLine();
Console.WriteLine(message.Content);
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
### Chat


```csharp
await using var container = await Environment.PrepareAsync(TestModels.Chat);

var chat = container.Client.Chat(TestModels.Chat);
var message = await chat.SendAsync("answer 5 random words");

Console.WriteLine(message.Content);
```

### Chat Client Five Random Words Streaming


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

### Chat Streaming


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

### Chat Client Five Random Words


```csharp
await using var environment = await Environment.PrepareAsync(TestModels.Chat);

IChatClient client = environment.Client;
var response = await client.GetResponseAsync(
    messages:
    [
        new MeaiChatMessage(MeaiChatRole.User, "Generate 5 random words.")
    ],
    options: new ChatOptions
    {
        ModelId = TestModels.Chat,
    });
```

### Chat Client Get Service Returns Chat Client Metadata


```csharp
using var client = new OllamaClient();
IChatClient chatClient = client;

var metadata = chatClient.GetService<ChatClientMetadata>();
```

### Chat Client Get Service Returns Null For Unknown Key


```csharp
using var client = new OllamaClient();
IChatClient chatClient = client;

var result = chatClient.GetService<ChatClientMetadata>(serviceKey: "unknown");
```

### Chat Client Get Service Returns Self


```csharp
using var client = new OllamaClient();
IChatClient chatClient = client;

var self = chatClient.GetService<OllamaClient>();
```

### Embedding Generator Batch Input


```csharp
await using var environment = await Environment.PrepareAsync(TestModels.Embeddings);

IEmbeddingGenerator<string, Embedding<float>> generator = environment.Client;
var result = await generator.GenerateAsync(
    values: ["Hello, world!", "Goodbye, world!"],
    options: new EmbeddingGenerationOptions
    {
        ModelId = TestModels.Embeddings,
    });
```

### Embedding Generator Get Service Returns Embedding Generator Metadata


```csharp
using var client = new OllamaClient();
IEmbeddingGenerator<string, Embedding<float>> generator = client;

var metadata = generator.GetService<EmbeddingGeneratorMetadata>();
```

### Embedding Generator Get Service Returns Null For Unknown Key


```csharp
using var client = new OllamaClient();
IEmbeddingGenerator<string, Embedding<float>> generator = client;

var result = generator.GetService<EmbeddingGeneratorMetadata>(serviceKey: "unknown");
```

### Embedding Generator Get Service Returns Self


```csharp
using var client = new OllamaClient();
IEmbeddingGenerator<string, Embedding<float>> generator = client;

var self = generator.GetService<OllamaClient>();
```

### Embedding Generator Single Input


```csharp
await using var environment = await Environment.PrepareAsync(TestModels.Embeddings);

IEmbeddingGenerator<string, Embedding<float>> generator = environment.Client;
var result = await generator.GenerateAsync(
    values: ["Hello, world!"],
    options: new EmbeddingGenerationOptions
    {
        ModelId = TestModels.Embeddings,
    });
```

### Embeddings


```csharp
await using var container = await Environment.PrepareAsync(TestModels.Embeddings);

var embeddingResponse = await container.Client.EmbedAsync(
    model: TestModels.Embeddings,
    input: "hello");
```

### Get Completion


```csharp
await using var container = await Environment.PrepareAsync(TestModels.Chat);

var enumerable = container.Client.GenerateAsStreamAsync(TestModels.Chat, "answer 5 random words");
await foreach (var response in enumerable)
{
    Console.WriteLine($"> {response.Response}");
}

var lastResponse = await container.Client.GenerateAsync(TestModels.Chat, "answer 123");
Console.WriteLine(lastResponse.Response);
```

### Get Completion With Options


```csharp
await using var container = await Environment.PrepareAsync(TestModels.Chat);

var response = await container.Client.GenerateAsync(new GenerateRequest
{
    Model = TestModels.Chat,
    Prompt = "answer me just \"123\"",
    Options = new ModelOptions
    {
        Temperature = 0,
    },
});
Console.WriteLine(response.Response);
```

### List Models


```csharp
await using var container = await Environment.PrepareAsync(environmentType: EnvironmentType.Container);

var models = await container.Client.ListAsync();
var initialCount = models.Models?.Count ?? 0;

await container.Client.PullAsStreamAsync(TestModels.Embeddings).EnsureSuccessAsync();

models = await container.Client.ListAsync();
models.Models.Any(model =>
    model.Model != null &&
```

### Pull Model


```csharp
await using var container = await Environment.PrepareAsync(environmentType: EnvironmentType.Container);

await foreach (var response in container.Client.PullAsStreamAsync(TestModels.Embeddings))
{
    Console.WriteLine($"{response.Status}. Progress: {response.Completed}/{response.Total}");
}

var responses = await container.Client.PullAsStreamAsync(TestModels.Embeddings);
responses[^1].EnsureSuccess();

await container.Client.PullAsStreamAsync(TestModels.Embeddings).EnsureSuccessAsync();
```

### Reader Lm


```csharp
await using var container = await Environment.PrepareAsync(TestModels.Reader);

var enumerable = container.Client.GenerateAsStreamAsync(
    TestModels.Reader,
    """
    <html>
      <body>
        <h3>Why is the sky blue?</h3>
        <p>The sky appears blue because of the way light from the sun is reflected by the atmosphere. The atmosphere is made up of gases, including nitrogen and oxygen, which scatter light in all directions. This scattering causes the sunlight to appear as a rainbow of colors, with red light scattered more than other colors.
        </p>
      </body>
    </html>
    """);
await foreach (var response in enumerable)
{
    Console.Write(response.Response);
}

// ### Why is the sky blue?
//
// The sky appears blue because of the way light from the sun is reflected by the atmosphere. The atmosphere is made up of gases, including nitrogen and oxygen, which scatter light in all directions. This scattering causes the sunlight to appear as a rainbow of colors, with red light scattered more than other colors.
```

### Strict Tools


```csharp
var service = new WeatherService();

var tools = service.AsTools();
foreach (var tool in tools)
{
}

var ollamaTools = tools.AsOllamaTools();
foreach (var tool in ollamaTools)
{
}
```

### Tools


```csharp
await using var container = await Environment.PrepareAsync(TestModels.Chat);

var messages = new List<ChatMessage>
{
    "You are a helpful weather assistant. Use the provided tools for weather questions.".AsSystemMessage(),
    "What is the current temperature in Dubai, UAE in Celsius?".AsUserMessage(),
};
var model = TestModels.Chat;

try
{
    var service = new WeatherService();
    var tools = service.AsTools().AsOllamaTools();
    var response = await container.Client.ChatAsync(
        model,
        messages,
        tools: tools,
        options: new ModelOptions
        {
            Temperature = 0,
            Seed = 1,
        });
    var assistantMessage = response.Message ?? throw new InvalidOperationException("Expected a response message.");

    messages.Add(assistantMessage.ToChatMessage());

    foreach (var call in assistantMessage.ToolCalls!)
    {
        var argumentsAsJson = call.Function?.Arguments == null
            ? string.Empty
            : call.Function.Arguments.AsJson();
        var json = await service.CallAsync(
            functionName: call.Function?.Name ?? string.Empty,
            argumentsAsJson: argumentsAsJson);
        messages.Add(json.AsToolMessage());
    }

    response = await container.Client.ChatAsync(
        model,
        messages,
        tools: tools,
        options: new ModelOptions
        {
            Temperature = 0,
            Seed = 1,
        });
    messages.Add((response.Message ?? throw new InvalidOperationException("Expected a response message.")).ToChatMessage());
}
finally
{
    Console.WriteLine(Ollama.Chat.PrintMessages(messages));
}
```

### Tools In Chat


```csharp
await using var container = await Environment.PrepareAsync(TestModels.Chat);

var chat = container.Client.Chat(
    model: TestModels.Chat,
    systemMessage: "You are a helpful weather assistant. Use the provided tools for weather questions.",
    autoCallTools: true);
chat.Options = new ModelOptions
{
    Temperature = 0,
    Seed = 1,
};

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
<!-- EXAMPLES:END -->

## Support

Priority place for bugs: https://github.com/tryAGI/Ollama/issues  
Priority place for ideas and general questions: https://github.com/tryAGI/Ollama/discussions  
Discord: https://discord.gg/Ca2xhfBf3v  

## Acknowledgments

![JetBrains logo](https://resources.jetbrains.com/storage/products/company/brand/logos/jetbrains.png)

This project is supported by JetBrains through the [Open Source Support Program](https://jb.gg/OpenSourceSupport).
