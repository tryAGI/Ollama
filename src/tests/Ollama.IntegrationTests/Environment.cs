using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace Ollama.IntegrationTests;

public sealed class Environment : IAsyncDisposable
{
    private const ushort OllamaPort = 11434;
    private static readonly TimeSpan ClientTimeout = TimeSpan.FromMinutes(10);

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
                var client = CreateClient(new Uri($"http://127.0.0.1:{OllamaPort}")); // baseUri: new Uri("http://10.10.5.85:11434")
                
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
                var container = new ContainerBuilder("ollama/ollama")
                    .WithPortBinding(OllamaPort, assignRandomHostPort: true)
                    .WithWaitStrategy(
                        Wait.ForUnixContainer()
                            .UntilInternalTcpPortIsAvailable(OllamaPort)
                            .UntilExternalTcpPortIsAvailable(OllamaPort))
                    .Build();
        
                await container.StartAsync();
        
                var client = CreateClient(
                    new UriBuilder(
                        Uri.UriSchemeHttp,
                        container.Hostname,
                        container.GetMappedPublicPort(OllamaPort)).Uri);

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

    private static OllamaClient CreateClient(Uri baseUri) =>
        new(
            httpClient: new HttpClient
            {
                Timeout = ClientTimeout,
            },
            baseUri: baseUri);

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
