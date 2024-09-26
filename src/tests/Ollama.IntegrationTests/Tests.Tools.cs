namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Tools()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3.2");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3.2");
#endif
        
        var messages = new List<Message>
        {
            "You are a helpful weather assistant.".AsSystemMessage(),
            "What is the current temperature in Dubai, UAE in Celsius?".AsUserMessage(),
        };
        const string model = "llama3.2";

        try
        {
            var service = new WeatherService();
            var tools = service.AsTools();
            var response = await container.ApiClient.Chat.GenerateChatCompletionAsync(
                model,
                messages,
                stream: false,
                tools: tools).WaitAsync();

            messages.Add(response.Message);

            response.Message.ToolCalls.Should().NotBeNullOrEmpty(because: "Expected a function call.");

            foreach (var call in response.Message.ToolCalls!)
            {
                var json = await service.CallAsync(
                    functionName: call.Function?.Name ?? string.Empty,
                    argumentsAsJson: call.Function?.Arguments.AsJson() ?? string.Empty);
                messages.Add(json.AsToolMessage());
            }

            response = await container.ApiClient.Chat.GenerateChatCompletionAsync(
                model,
                messages,
                stream: false,
                tools: tools).WaitAsync();
            messages.Add(response.Message);
        }
        finally
        {
            Console.WriteLine(Ollama.Chat.PrintMessages(messages));
        }
    }
}