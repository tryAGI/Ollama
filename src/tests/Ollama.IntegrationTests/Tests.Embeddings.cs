namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Embeddings()
    {
        await using var container = await Environment.PrepareAsync( "all-minilm");
        
        var embeddingResponse = await container.ApiClient.Embeddings.GenerateEmbeddingAsync(
            model:"all-minilm",
            prompt: "hello");
        
        embeddingResponse.Embedding.Should().NotBeNullOrEmpty();
    }
}