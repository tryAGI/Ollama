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
                // set OLLAMA_HOST=10.10.0.125:11434
                // ollama serve
                var apiClient = new OllamaApiClient(
                    httpClient: new HttpClient
                    {
                        Timeout = TimeSpan.FromMinutes(10),
                    },
                    baseUri: new Uri("http://10.10.0.125:11434/api"));
                
                if (!string.IsNullOrEmpty(model))
                {
                    await apiClient.Models.PullModelAndEnsureSuccessAsync(model);
                }

                return new Environment
                {
                    Type = environmentType,
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
        
                var apiClient = new OllamaApiClient();
                if (!string.IsNullOrEmpty(model))
                {
                    await apiClient.Models.PullModelAndEnsureSuccessAsync(model);
                }
                
                return new Environment
                {
                    Type = environmentType,
                    Container = container,
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
        
        var models = await container.ApiClient.Models.ListModelsAsync();
        models.Models.Should().BeNullOrEmpty();
        
        await container.ApiClient.Models.PullModelAndEnsureSuccessAsync("all-minilm");
        
        models = await container.ApiClient.Models.ListModelsAsync();
        models.Models.Should().NotBeNull();
        models.Models.Should().HaveCount(1);
        models.Models![0].Model1.Should().Be("all-minilm:latest");
    }
    
    [TestMethod]
    public async Task PullModel()
    {
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container);
        
        await foreach (var response in container.ApiClient.Models.PullModelAsync("all-minilm", stream: true))
        {
            Console.WriteLine($"{response.Status?.Object}. Progress: {response.Completed}/{response.Total}");
        }
        
        var response2 = await container.ApiClient.Models.PullModelAsync("all-minilm").WaitAsync();
        response2.EnsureSuccess();
        
        await container.ApiClient.Models.PullModelAndEnsureSuccessAsync("all-minilm");
    }
    
    [TestMethod]
    public async Task Embeddings()
    {
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container);
        
        if (container.Type == EnvironmentType.Local)
        {
            var models = await container.ApiClient.Models.ListRunningModelsAsync();
            models.Models.Should().BeNullOrEmpty();
        }
        
        await container.ApiClient.Models.PullModelAndEnsureSuccessAsync("all-minilm");
        
        var embeddingResponse = await container.ApiClient.Embeddings.GenerateEmbeddingAsync(
            model:"all-minilm",
            prompt: "hello");
        
        embeddingResponse.Embedding.Should().NotBeNullOrEmpty();
        
        if (container.Type == EnvironmentType.Local)
        {
            var models2 = await container.ApiClient.Models.ListRunningModelsAsync();
            models2.Models.Should().NotBeNullOrEmpty();
        }

    }
    
    [TestMethod]
    public async Task GetCompletionWithOptions()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3");
#endif

        var response = await container.ApiClient.Completions.GenerateCompletionAsync(new GenerateCompletionRequest
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
        var enumerable = container.ApiClient.Completions.GenerateCompletionAsync("llama3", "answer 5 random words", stream: true);
        await foreach (var response in enumerable)
        {
            Console.WriteLine($"> {response.Response}");
            
            context = response.Context;
        }
        
        var lastResponse = await container.ApiClient.Completions.GenerateCompletionAsync("llama3", "answer 123", stream: false, context: context).WaitAsync();
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
        var message = await chat.SendAsync("answer 5 random words");
        
        Console.WriteLine(message.Content);
    }
    
    [TestMethod]
    public async Task Tools()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3.1");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3.1");
#endif
        
        var messages = new List<Message>
        {
            "You are a helpful weather assistant.".AsSystemMessage(),
            "What is the current temperature in Dubai, UAE in Celsius?".AsUserMessage(),
        };
        const string model = "llama3.1";

        try
        {
            var service = new WeatherService();
            var tools = service.AsTools();
            var response = await container.ApiClient.Chat.GenerateChatCompletionAsync(
                model,
                messages,
                stream: false,
                tools: tools).WaitAsync();

            messages.Add(response.Message);

            response.Message.ToolCalls.Should().NotBeNullOrEmpty(because: "Expected a function call.");

            foreach (var call in response.Message.ToolCalls!)
            {
                var json = await service.CallAsync(
                    functionName: call.Function?.Name ?? string.Empty,
                    argumentsAsJson: call.Function?.Arguments.AsJson() ?? string.Empty);
                messages.Add(json.AsToolMessage());
            }

            response = await container.ApiClient.Chat.GenerateChatCompletionAsync(
                model,
                messages,
                stream: false,
                tools: tools).WaitAsync();
            messages.Add(response.Message);
        }
        finally
        {
            Console.WriteLine(Chat.PrintMessages(messages));
        }
    }
    
    
    [TestMethod]
    public async Task ToolsInChat()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3.1");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3.1");
#endif
        
        var chat = container.ApiClient.Chat(
            model: "llama3.1",
            systemMessage: "You are a helpful weather assistant.",
            autoCallTools: true);
        
        var service = new WeatherService();
        chat.AddToolService(service.AsTools(), service.AsCalls());
        
        try
        {
            _ = await chat.SendAsync("What is the current temperature in Dubai, UAE in Celsius?");
        }
        finally
        {
            Console.WriteLine(chat.PrintMessages());
        }
    }
}