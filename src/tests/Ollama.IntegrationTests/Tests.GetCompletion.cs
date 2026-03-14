namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task GetCompletion()
    {
        await using var container = await Environment.PrepareAsync("llama3.2");

        var enumerable = container.ApiClient.GenerateAsStreamAsync("llama3.2", "answer 5 random words");
        await foreach (var response in enumerable)
        {
            Console.WriteLine($"> {response.Response}");
        }
        
        var lastResponse = await container.ApiClient.GenerateAsync("llama3.2", "answer 123");
        Console.WriteLine(lastResponse.Response);
    }
}
