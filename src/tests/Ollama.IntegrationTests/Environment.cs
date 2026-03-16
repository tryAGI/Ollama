using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace Ollama.IntegrationTests;

public sealed class Environment : IAsyncDisposable
{
    public required EnvironmentType? Type { get; init; }
    public IContainer? Container { get; init; }
    public required OllamaClient Client { get; init; }

    public async ValueTask DisposeAsync()
    {
        Client.Dispose();
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
                var client = new OllamaClient(
                    httpClient: new HttpClient
                    {
                        Timeout = TimeSpan.FromMinutes(10),
                    },
                    baseUri: new Uri("http://127.0.0.1:11434")); // baseUri: new Uri("http://10.10.5.85:11434")
                
                if (!string.IsNullOrEmpty(model))
                {
                    await client.PullAsStreamAsync(model).EnsureSuccessAsync();
                }

                return new Environment
                {
                    Type = environmentType,
                    Client = client,
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
        
                var client = new OllamaClient();
                if (!string.IsNullOrEmpty(model))
                {
                    await client.PullAsStreamAsync(model).EnsureSuccessAsync();
                }
                
                return new Environment
                {
                    Type = environmentType,
                    Container = container,
                    Client = client,
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
