# Tools



This example assumes `using Ollama;` is in scope and `apiKey` contains your Ollama API key.

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