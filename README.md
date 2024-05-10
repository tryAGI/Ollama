# Ollama SDK for .NET

[![Nuget package](https://img.shields.io/nuget/vpre/Ollama)](https://www.nuget.org/packages/Ollama/)
[![dotnet](https://github.com/tryAGI/Ollama/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/tryAGI/Ollama/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/github/license/tryAGI/Ollama)](https://github.com/tryAGI/Ollama/blob/main/LICENSE.txt)
[![Discord](https://img.shields.io/discord/1115206893015662663?label=Discord&logo=discord&logoColor=white&color=d82679)](https://discord.gg/Ca2xhfBf3v)

Generated C# SDK based on Ollama OpenAPI specification using NSwag.  

### Usage
```csharp
using Ollama;

using var client = new HttpClient();
var api = new OllamaApi(apiKey, client);
var response = await api.CompleteAsync(new CreateCompletionRequest
{
    Model = ModelIds.ClaudeInstant,
    Prompt = "Once upon a time".AsPrompt(),
    Max_tokens_to_sample = 250,
});
Console.WriteLine(response.Completion);

// or use history syntax

var response = await api.CompleteAsync(new CreateCompletionRequest
{
    Model = ModelIds.ClaudeInstant,
    Prompt = new[]
    {
        "What's the weather like today?".AsHumanMessage(),
        "Sure! Could you please provide me with your location?".AsAssistantMessage(),
        "Dubai, UAE".AsHumanMessage(),
    }.AsPrompt(),
    Max_tokens_to_sample = 300,
});
```

## Support

Priority place for bugs: https://github.com/tryAGI/Ollama/issues  
Priority place for ideas and general questions: https://github.com/tryAGI/Ollama/discussions  
Discord: https://discord.gg/Ca2xhfBf3v  