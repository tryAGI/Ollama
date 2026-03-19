/*
order: 80
title: Embedding Generator Get Service Returns Embedding Generator Metadata
slug: embedding-generator-get-service-returns-embedding-generator-metadata
*/

using Microsoft.Extensions.AI;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public void EmbeddingGenerator_GetService_ReturnsEmbeddingGeneratorMetadata()
    {
        using var client = new OllamaClient();
        IEmbeddingGenerator<string, Embedding<float>> generator = client;

        var metadata = generator.GetService<EmbeddingGeneratorMetadata>();

        metadata.Should().NotBeNull();
        metadata!.ProviderName.Should().Be(nameof(OllamaClient));
    }
}
