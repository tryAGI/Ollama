# Microsoft.Extensions.AI Integration

!!! tip "Cross-SDK comparison"
    See the [centralized MEAI documentation](https://tryagi.github.io/docs/meai/) for feature matrices and comparisons across all tryAGI SDKs.

The Ollama SDK implements `IChatClient` and `IEmbeddingGenerator<string, Embedding<float>>` from [Microsoft.Extensions.AI](https://learn.microsoft.com/en-us/dotnet/ai/microsoft-extensions-ai).

## Supported Interfaces

| Interface | Description |
|-----------|-------------|
| `IChatClient` | Chat completions with text, streaming, tool calling, and images |
| `IEmbeddingGenerator<string, Embedding<float>>` | Text embeddings with custom dimensions |

## IChatClient

### Basic Chat

```csharp
using Ollama;
using Microsoft.Extensions.AI;

using var ollama = new OllamaClient();
IChatClient chatClient = ollama;

var response = await chatClient.GetResponseAsync(
    [new ChatMessage(ChatRole.User, "Hello!")],
    new ChatOptions { ModelId = "llama3.2" });

Console.WriteLine(response.Text);
```

### Streaming

```csharp
await foreach (var update in chatClient.GetStreamingResponseAsync(
    [new ChatMessage(ChatRole.User, "Count from 1 to 10.")],
    new ChatOptions { ModelId = "llama3.2" }))
{
    Console.Write(string.Concat(update.Contents.OfType<TextContent>().Select(c => c.Text)));
}
```

### System Messages

```csharp
var messages = new List<ChatMessage>
{
    new(ChatRole.System, "You are a helpful assistant that responds concisely."),
    new(ChatRole.User, "What is the capital of France?"),
};

var response = await chatClient.GetResponseAsync(
    messages,
    new ChatOptions { ModelId = "llama3.2" });
```

### Tool Calling

```csharp
var weatherTool = AIFunctionFactory.Create(
    (string city) => city switch
    {
        "Paris" => "22C, sunny",
        "London" => "15C, cloudy",
        _ => "Unknown",
    },
    name: "GetWeather",
    description: "Gets the current weather for a city");

var response = await chatClient.GetResponseAsync(
    [new ChatMessage(ChatRole.User, "What's the weather in Paris?")],
    new ChatOptions
    {
        ModelId = "llama3.2",
        Tools = [weatherTool],
    });
```

### Image Content

```csharp
var message = new ChatMessage(ChatRole.User, []);
message.Contents.Add(new TextContent("What is in this image?"));
message.Contents.Add(new DataContent(imageBytes, "image/png"));

var response = await chatClient.GetResponseAsync(
    [message],
    new ChatOptions { ModelId = "llava" });
```

## IEmbeddingGenerator

### Basic Embeddings

```csharp
using Ollama;
using Microsoft.Extensions.AI;

using var ollama = new OllamaClient();
IEmbeddingGenerator<string, Embedding<float>> generator = ollama;

var result = await generator.GenerateAsync(
    ["Hello, world!"],
    new EmbeddingGenerationOptions { ModelId = "all-minilm" });

Console.WriteLine($"Dimensions: {result[0].Vector.Length}");
```

### Batch Embeddings

```csharp
var result = await generator.GenerateAsync(
    ["Hello", "How are you?", "Goodbye"],
    new EmbeddingGenerationOptions { ModelId = "all-minilm" });

Console.WriteLine($"Generated {result.Count} embeddings");
```

### Custom Dimensions

```csharp
var result = await generator.GenerateAsync(
    ["Hello, world!"],
    new EmbeddingGenerationOptions
    {
        ModelId = "all-minilm",
        Dimensions = 256,
    });

Console.WriteLine($"Dimensions: {result[0].Vector.Length}");
```

## Combining with CSharpToJsonSchema Tools

The MEAI interface works alongside the native Ollama tools integration:

```csharp
using Ollama;
using CSharpToJsonSchema;
using Microsoft.Extensions.AI;

[GenerateJsonSchema]
public interface IWeatherFunctions
{
    [Description("Get the current weather in a given location")]
    public Task<string> GetCurrentWeatherAsync(
        [Description("The city name")] string location,
        CancellationToken cancellationToken = default);
}

// Use the native Ollama Chat abstraction with tools
var chat = ollama.Chat(
    model: "llama3.2",
    systemMessage: "You are a helpful weather assistant.",
    autoCallTools: true);

var service = new WeatherService();
chat.AddToolService(service.AsTools().AsOllamaTools(), service.AsCalls());
```
