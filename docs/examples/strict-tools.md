# Strict Tools



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

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