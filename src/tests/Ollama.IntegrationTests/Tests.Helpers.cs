using System.Net;
using System.Text.Json;
using Moq;
using Moq.Protected;

namespace Ollama.IntegrationTests;

[TestClass]
public partial class Tests
{
    public static OllamaApiClient MockApiClient(MessageRole role, string answer)
    {
        return MockApiClient(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonSerializer.Serialize(new GenerateChatCompletionResponse
            {
                Done = true,
                DoneReason = GenerateChatCompletionResponseDoneReason.Stop,
                Message = new Message
                {
                    Role = role,
                    Content = answer,
                },
                CreatedAt = DateTime.UtcNow,
                Model = "model",
            }))
        });
    }
    
    public static OllamaApiClient MockApiClient(HttpResponseMessage response)
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(_ => true),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(() => response);

        var httpClient = new HttpClient(mockHandler.Object) { BaseAddress = new Uri("http://127.0.0.1/") };
        return new OllamaApiClient(httpClient);
    }
}
