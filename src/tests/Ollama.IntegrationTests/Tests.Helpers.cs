using DotNet.Testcontainers.Builders;

namespace Ollama.IntegrationTests;

[TestClass]
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

}
    
