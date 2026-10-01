using Microsoft.Extensions.AI;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task ChatClient_ConstructorAuthorization_IsSent()
    {
        using var handler = new AuthorizationHandler();
        using var httpClient = new HttpClient(handler) { BaseAddress = new Uri("http://localhost:11434/") };
        using var client = new OllamaClient(
            httpClient: httpClient,
            authorizations:
            [
                new EndPointAuthorization
                {
                    Type = "ApiKey",
                    Location = "Header",
                    SchemeId = "Bearer",
                    Name = "Authorization",
                    Value = "test-token",
                },
            ],
            disposeHttpClient: false);

        IChatClient chatClient = client;
        await chatClient.GetResponseAsync("Hello");

        handler.Authorization.Should().Be("test-token");
    }

    private sealed class AuthorizationHandler : HttpMessageHandler
    {
        public string? Authorization { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Authorization = request.Headers.GetValues("Authorization").SingleOrDefault();
            return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("{\"model\":\"test\",\"message\":{\"role\":\"assistant\",\"content\":\"ok\"},\"done\":true}"),
            });
        }
    }
}
