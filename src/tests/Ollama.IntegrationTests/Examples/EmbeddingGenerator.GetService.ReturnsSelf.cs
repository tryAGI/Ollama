/*
order: 100
title: Embedding Generator Get Service Returns Self
slug: embedding-generator-get-service-returns-self
*/

using Microsoft.Extensions.AI;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public void EmbeddingGenerator_GetService_ReturnsSelf()
    {
        using var client = new OllamaClient();
        IEmbeddingGenerator<string, Embedding<float>> generator = client;

        var self = generator.GetService<OllamaClient>();

        self.Should().BeSameAs(client);
    }
}
