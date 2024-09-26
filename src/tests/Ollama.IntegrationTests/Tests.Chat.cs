namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Chat()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3.2");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3.2");
#endif
        
        var chat = container.ApiClient.Chat("llama3.2");
        var message = await chat.SendAsync("answer 5 random words");
        
        Console.WriteLine(message.Content);
    }
}