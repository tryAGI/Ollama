using DotNet.Testcontainers.Containers;

namespace Ollama.IntegrationTests;

public sealed class Environment : IAsyncDisposable
{
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
}