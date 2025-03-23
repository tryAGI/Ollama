namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task ToolsInChat()
    {
        await using var container = await Environment.PrepareAsync("llama3.2");
        
        var chat = container.ApiClient.Chat(
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
    }
}