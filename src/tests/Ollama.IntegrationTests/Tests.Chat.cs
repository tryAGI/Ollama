namespace Ollama.IntegrationTests;

[TestClass]
public partial class Tests
{
    [TestMethod]
    public async Task Chat()
    {
        await using var container = await Environment.PrepareAsync(TestModels.Chat);
        
        var chat = container.Client.Chat(TestModels.Chat);
        var message = await chat.SendAsync("answer 5 random words");
        
        Console.WriteLine(message.Content);
    }
}
