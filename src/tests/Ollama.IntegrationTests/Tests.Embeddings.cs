namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Embeddings()
    {
#if DEBUG
        await using var container = await Environment.PrepareAsync(EnvironmentType.Local, "all-minilm");
#else
        await using var container = await Environment.PrepareAsync(EnvironmentType.Container, "all-minilm");
#endif
        
        var embeddingResponse = await container.ApiClient.Embeddings.GenerateEmbeddingAsync(
            model:"all-minilm",
            prompt: "hello");
        
        embeddingResponse.Embedding.Should().NotBeNullOrEmpty();
    }
}