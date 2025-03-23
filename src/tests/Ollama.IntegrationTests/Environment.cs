using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace Ollama.IntegrationTests;

public sealed class Environment : IAsyncDisposable
{
    public required EnvironmentType? Type { get; init; }
    public IContainer? Container { get; init; }
    public required OllamaApiClient ApiClient { get; init; }

    public async ValueTask DisposeAsync()
    {
        ApiClient.Dispose();
        if (Container != null)
        {
            await Container.DisposeAsync();
        }
    }
    
    public static async Task<Environment> PrepareAsync(string model = "", EnvironmentType? environmentType = null)
    {
        environmentType ??= InferEnvironment();
        switch (environmentType)
        {
            case EnvironmentType.Local:
            {
                // set OLLAMA_HOST=10.10.5.85:11434
                // ollama serve
                var apiClient = new OllamaApiClient(
                    httpClient: new HttpClient
                    {
                        Timeout = TimeSpan.FromMinutes(10),
                    },
                    baseUri: new Uri("http://127.0.0.1:11434/api")); // baseUri: new Uri("http://10.10.5.85:11434/api")
                
                if (!string.IsNullOrEmpty(model))
                {
                    await apiClient.Models.PullModelAsync(model).EnsureSuccessAsync();
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
                    await apiClient.Models.PullModelAsync(model).EnsureSuccessAsync();
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
    private static EnvironmentType InferEnvironment()
    {
#if DEBUG
        return EnvironmentType.Local;
#else
        return EnvironmentType.Container;
#endif
    }

}

public enum EnvironmentType
{
    Local,
    Container,
}