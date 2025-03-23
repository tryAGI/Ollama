namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task GetCompletionWithOptions()
    {
        await using var container = await Environment.PrepareAsync("llama3.2");

        var response = await container.ApiClient.Completions.GenerateCompletionAsync(new GenerateCompletionRequest
        {
            Model = "llama3.2",
            Prompt = "answer me just \"123\"",
            Stream = true,
            Options = new RequestOptions
            {
                Temperature = 0,
            },
        });
        Console.WriteLine(response.Response);
    }
}