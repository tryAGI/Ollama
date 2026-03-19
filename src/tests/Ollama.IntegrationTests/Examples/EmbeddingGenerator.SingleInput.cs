/*
order: 110
title: Embedding Generator Single Input
slug: embedding-generator-single-input
*/

using Microsoft.Extensions.AI;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task EmbeddingGenerator_SingleInput()
    {
        await using var environment = await Environment.PrepareAsync(TestModels.Embeddings);

        IEmbeddingGenerator<string, Embedding<float>> generator = environment.Client;
        var result = await generator.GenerateAsync(
            values: ["Hello, world!"],
            options: new EmbeddingGenerationOptions
            {
                ModelId = TestModels.Embeddings,
            });

        result.Should().ContainSingle();
        result[0].Vector.Length.Should().BeGreaterThan(0);
    }
}
