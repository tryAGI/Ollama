namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task ToolsInChat()
    {
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
    }
}
