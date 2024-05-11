using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    private static async Task<IContainer> StartContainerAsync()
    {
        var container = new ContainerBuilder()
            .WithImage("ollama/ollama")
            .WithPortBinding(hostPort: 11434, containerPort: 11434)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(11434))
            .Build();
        
        await container.StartAsync();
        
        return container;
    }
    
    [TestMethod]
    public async Task ListModels()
    {
        await using var container = await StartContainerAsync();

        using var client = new HttpClient();
        var api = new OllamaApiClient(client);
        
        var models = await api.ListModelsAsync();
        models.Should().NotBeNull();
        models.Should().BeEmpty();
    }
    
    [TestMethod]
    public async Task PullModel()
    {
        await using var container = await StartContainerAsync();

        using var client = new HttpClient();
        var api = new OllamaApiClient(client);
        
        await api.PullModelAsync("nomic-embed-text", modelResponse =>
        {
            Console.WriteLine($"{modelResponse.Status}. Progress: {modelResponse.Completed}/{modelResponse.Total}");
        });
    }
}