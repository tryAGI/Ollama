namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task GetCompletion()
    {
        await using var container = await Environment.PrepareAsync(TestModels.Chat);

        var enumerable = container.Client.GenerateAsStreamAsync(TestModels.Chat, "answer 5 random words");
        await foreach (var response in enumerable)
        {
            Console.WriteLine($"> {response.Response}");
        }
        
        var lastResponse = await container.Client.GenerateAsync(TestModels.Chat, "answer 123");
        Console.WriteLine(lastResponse.Response);
    }
}
