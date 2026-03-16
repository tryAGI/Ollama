namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task PullModel()
    {
        await using var container = await Environment.PrepareAsync(environmentType: EnvironmentType.Container);
        
        await foreach (var response in container.Client.PullAsStreamAsync("all-minilm"))
        {
            Console.WriteLine($"{response.Status}. Progress: {response.Completed}/{response.Total}");
        }
        
        var responses = await container.Client.PullAsStreamAsync("all-minilm");
        responses[^1].EnsureSuccess();
        
        await container.Client.PullAsStreamAsync("all-minilm").EnsureSuccessAsync();
    }
}
