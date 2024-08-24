namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task PullModel()
    {
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container);
        
        await foreach (var response in container.ApiClient.Models.PullModelAsync("all-minilm"))
        {
            Console.WriteLine($"{response.Status?.Object}. Progress: {response.Completed}/{response.Total}");
        }
        
        var response2 = await container.ApiClient.Models.PullModelAsync("all-minilm");
        response2.EnsureSuccess();
        
        await container.ApiClient.Models.PullModelAsync("all-minilm").EnsureSuccessAsync();
    }
}