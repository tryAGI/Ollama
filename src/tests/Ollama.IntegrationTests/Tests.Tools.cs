namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Tools()
    {
        await using var container = await Environment.PrepareAsync("llama3.2");
        
        var messages = new List<ChatMessage>
        {
            "You are a helpful weather assistant.".AsSystemMessage(),
            "What is the current temperature in Dubai, UAE in Celsius?".AsUserMessage(),
        };
        const string model = "llama3.2";

        try
        {
            var service = new WeatherService();
            var tools = service.AsTools().AsOllamaTools();
            var response = await container.ApiClient.ChatAsync(
                model,
                messages,
                tools: tools);
            var assistantMessage = response.Message ?? throw new InvalidOperationException("Expected a response message.");

            messages.Add(assistantMessage.ToChatMessage());

            assistantMessage.ToolCalls.Should().NotBeNullOrEmpty(because: "Expected a function call.");

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

            response = await container.ApiClient.ChatAsync(
                model,
                messages,
                tools: tools);
            messages.Add((response.Message ?? throw new InvalidOperationException("Expected a response message.")).ToChatMessage());
        }
        finally
        {
            Console.WriteLine(Ollama.Chat.PrintMessages(messages));
        }
    }
}
