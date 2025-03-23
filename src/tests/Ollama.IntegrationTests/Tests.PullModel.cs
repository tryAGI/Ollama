namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task PullModel()
    {
        await using var container = await Environment.PrepareAsync(environmentType: EnvironmentType.Container);
        
        await foreach (var response in container.ApiClient.Models.PullModelAsync("all-minilm"))
        {
            Console.WriteLine($"{response.Status?.Object}. Progress: {response.Completed}/{response.Total}");
        }
        
        var responses = await container.ApiClient.Models.PullModelAsync("all-minilm");
        responses[^1].EnsureSuccess();
        
        await container.ApiClient.Models.PullModelAsync("all-minilm").EnsureSuccessAsync();
    }
}