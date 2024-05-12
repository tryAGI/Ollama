using DotNet.Testcontainers.Builders;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    private static async Task<Environment> PrepareEnvironmentAsync(EnvironmentType environmentType, string model = "")
    {
        switch (environmentType)
        {
            case EnvironmentType.Local:
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://172.16.50.107:11434/");
                var apiClient = new OllamaApiClient(client);
                
                if (!string.IsNullOrEmpty(model))
                {
                    await apiClient.PullModelAsync(model).WaitAsync();
                }

                return new Environment
                {
                    HttpClient = client,
                    ApiClient = apiClient,
                };
            }
            case EnvironmentType.Container:
            {
                var container = new ContainerBuilder()
                    .WithImage("ollama/ollama")
                    .WithPortBinding(hostPort: 11434, containerPort: 11434)
                    .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(11434))
                    .Build();
        
                await container.StartAsync();
        
                var client = new HttpClient();
                var apiClient = new OllamaApiClient(client);
                
                if (!string.IsNullOrEmpty(model))
                {
                    await apiClient.PullModelAsync(model).WaitAsync();
                }
                
                return new Environment
                {
                    Container = container,
                    HttpClient = client,
                    ApiClient = apiClient,
                };
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(environmentType), environmentType, null);
        }
    }
    
    [TestMethod]
    public async Task ListModels()
    {
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container);
        
        var models = await container.ApiClient.ListModelsAsync();
        models.Should().NotBeNull();
        models.Should().BeEmpty();
    }
    
    [TestMethod]
    public async Task PullModel()
    {
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container);
        
        await foreach (var response in container.ApiClient.PullModelAsync("nomic-embed-text"))
        {
            Console.WriteLine($"{response.Status}. Progress: {response.Completed}/{response.Total}");
        }
        
        await container.ApiClient.PullModelAsync("nomic-embed-text").WaitAsync();
    }
    
    [TestMethod]
    public async Task GetCompletionWithOptions()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3");
#endif

        var response = await container.ApiClient.GetCompletionAsync(new GenerateCompletionRequest
        {
            Model = "llama3",
            Prompt = "answer me just \"123\"",
            Stream = true,
            Options = new RequestOptions
            {
                Temperature = 0,
            },
        }).WaitAsync();
        Console.WriteLine(response.Response);
    }
    
    [TestMethod]
    public async Task GetCompletion()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3");
#endif

        IList<long>? context = null;
        var enumerable = container.ApiClient.GetCompletionAsync("llama3", "answer 123", stream: false);
        await foreach (var response in enumerable)
        {
            Console.WriteLine(response.Response);
            
            context = response.Context;
        }
        
        var lastResponse = await container.ApiClient.GetCompletionAsync("llama3", "answer 123", stream: false, context: context).WaitAsync();
        Console.WriteLine(lastResponse.Response);
    }
    
    [TestMethod]
    public async Task GetChat()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3");
#endif
        
        var chat = container.ApiClient.Chat("llama3");
        var message = await chat.SendAsync("answer 123");
        
        Console.WriteLine(message.Content);
    }
}