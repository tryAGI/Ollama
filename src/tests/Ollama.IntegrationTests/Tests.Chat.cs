namespace Ollama.IntegrationTests;

[TestClass]
public partial class Tests
{
    [TestMethod]
    public async Task Chat()
    {
        await using var container = await Environment.PrepareAsync("llama3.2");
        
        var chat = container.Client.Chat("llama3.2");
        var message = await chat.SendAsync("answer 5 random words");
        
        Console.WriteLine(message.Content);
    }
}
