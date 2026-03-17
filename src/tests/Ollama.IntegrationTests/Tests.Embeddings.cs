namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Embeddings()
    {
        await using var container = await Environment.PrepareAsync(TestModels.Embeddings);
        
        var embeddingResponse = await container.Client.EmbedAsync(
            model: TestModels.Embeddings,
            input: "hello");
        
        embeddingResponse.Embeddings.Should().NotBeNullOrEmpty();
    }
}
