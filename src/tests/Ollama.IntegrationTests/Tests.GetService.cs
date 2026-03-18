using Microsoft.Extensions.AI;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public void ChatClient_GetService_ReturnsChatClientMetadata()
    {
        using var client = new OllamaClient();
        IChatClient chatClient = client;

        var metadata = chatClient.GetService<ChatClientMetadata>();

        metadata.Should().NotBeNull();
        metadata!.ProviderName.Should().Be(nameof(OllamaClient));
    }

    [TestMethod]
    public void ChatClient_GetService_ReturnsSelf()
    {
        using var client = new OllamaClient();
        IChatClient chatClient = client;

        var self = chatClient.GetService<OllamaClient>();

        self.Should().BeSameAs(client);
    }

    [TestMethod]
    public void ChatClient_GetService_ReturnsNullForUnknownKey()
    {
        using var client = new OllamaClient();
        IChatClient chatClient = client;

        var result = chatClient.GetService<ChatClientMetadata>(serviceKey: "unknown");

        result.Should().BeNull();
    }

    [TestMethod]
    public void EmbeddingGenerator_GetService_ReturnsEmbeddingGeneratorMetadata()
    {
        using var client = new OllamaClient();
        IEmbeddingGenerator<string, Embedding<float>> generator = client;

        var metadata = generator.GetService<EmbeddingGeneratorMetadata>();

        metadata.Should().NotBeNull();
        metadata!.ProviderName.Should().Be(nameof(OllamaClient));
    }

    [TestMethod]
    public void EmbeddingGenerator_GetService_ReturnsSelf()
    {
        using var client = new OllamaClient();
        IEmbeddingGenerator<string, Embedding<float>> generator = client;

        var self = generator.GetService<OllamaClient>();

        self.Should().BeSameAs(client);
    }

    [TestMethod]
    public void EmbeddingGenerator_GetService_ReturnsNullForUnknownKey()
    {
        using var client = new OllamaClient();
        IEmbeddingGenerator<string, Embedding<float>> generator = client;

        var result = generator.GetService<EmbeddingGeneratorMetadata>(serviceKey: "unknown");

        result.Should().BeNull();
    }
}
