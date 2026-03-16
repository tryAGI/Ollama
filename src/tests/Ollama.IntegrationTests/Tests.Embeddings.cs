namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Embeddings()
    {
        await using var container = await Environment.PrepareAsync( "all-minilm");
        
        var embeddingResponse = await container.Client.EmbedAsync(
            model:"all-minilm",
            input: "hello");
        
        embeddingResponse.Embeddings.Should().NotBeNullOrEmpty();
    }
}
