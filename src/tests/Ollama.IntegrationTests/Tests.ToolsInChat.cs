namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task ToolsInChat()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3.1");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3.1");
#endif
        
        var chat = container.ApiClient.Chat(
            model: "llama3.1",
            systemMessage: "You are a helpful weather assistant.",
            autoCallTools: true);
        
        var service = new WeatherService();
        chat.AddToolService(service.AsTools(), service.AsCalls());
        
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