namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task GetCompletionWithOptions()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3.2");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3.2");
#endif

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