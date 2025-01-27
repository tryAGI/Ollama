# Ollama SDK for .NET 🦙

[![Nuget package](https://img.shields.io/nuget/vpre/Ollama)](https://www.nuget.org/packages/Ollama/)
[![dotnet](https://github.com/tryAGI/Ollama/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/tryAGI/Ollama/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/github/license/tryAGI/Ollama)](https://github.com/tryAGI/Ollama/blob/main/LICENSE.txt)
[![Discord](https://img.shields.io/discord/1115206893015662663?label=Discord&logo=discord&logoColor=white&color=d82679)](https://discord.gg/Ca2xhfBf3v)

## Features 🔥
- Fully generated C# SDK based on [OpenAPI specification](https://github.com/davidmigloz/langchain_dart/blob/main/packages/ollama_dart/oas/ollama-curated.yaml) using [OpenApiGenerator](https://github.com/HavenDV/OpenApiGenerator)
- Automatic releases of new preview versions if there was an update to the OpenAPI specification
- Source generator to define tools natively through C# interfaces
- All modern .NET features - nullability, trimming, NativeAOT, etc.
- Support .Net Framework/.Net Standard 2.0
- Support for all Ollama API endpoints including chats, embeddings, listing models, pulling and creating new models, and more.

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
await ollama.Models.PullModelAsync("all-minilm").EnsureSuccessAsync();

// Generating an embedding
var embedding = await ollama.Embeddings.GenerateEmbeddingAsync(
    model: "all-minilm",
    prompt: "hello");

// Streaming a completion directly into the console
// keep reusing the context to keep the chat topic going
IList<long>? context = null;
var enumerable = ollama.Completions.GenerateCompletionAsync("llama3.2", "answer 5 random words");
await foreach (var response in enumerable)
{
    Console.WriteLine($"> {response.Response}");
    
    context = response.Context;
}

var lastResponse = await ollama.Completions.GenerateCompletionAsync("llama3.2", "answer 123", stream: false, context: context).WaitAsync();
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

### Tools
```csharp
using var ollama = new OllamaApiClient();
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

## Credits

Icon and name were reused from the amazing [Ollama project](https://github.com/jmorganca/ollama).  
The project was forked from [this repository](https://github.com/awaescher/OllamaSharp), 
after which automatic code generation was applied based on [this OpenAPI specification](https://github.com/davidmigloz/langchain_dart/blob/main/packages/ollama_dart/oas/ollama-curated.yaml) 
(in the future it will be replaced by the official one, if one appears)

## Support

Priority place for bugs: https://github.com/tryAGI/Ollama/issues  
Priority place for ideas and general questions: https://github.com/tryAGI/Ollama/discussions  
Discord: https://discord.gg/Ca2xhfBf3v  

## Acknowledgments

![JetBrains logo](https://resources.jetbrains.com/storage/products/company/brand/logos/jetbrains.png)

This project is supported by JetBrains through the [Open Source Support Program](https://jb.gg/OpenSourceSupport).

![CodeRabbit logo](https://opengraph.githubassets.com/1c51002d7d0bbe0c4fd72ff8f2e58192702f73a7037102f77e4dbb98ac00ea8f/marketplace/coderabbitai)

This project is supported by CodeRabbit through the [Open Source Support Program](https://github.com/marketplace/coderabbitai).
