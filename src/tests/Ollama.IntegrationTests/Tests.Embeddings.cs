namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Embeddings()
    {
        await using var container = await Environment.PrepareAsync(EnvironmentType.Container);
        
        if (container.Type == EnvironmentType.Local)
        {
            var models = await container.ApiClient.Models.ListRunningModelsAsync();
            models.Models.Should().BeNullOrEmpty();
        }
        
        await container.ApiClient.Models.PullModelAsync("all-minilm").EnsureSuccessAsync();
        
        var embeddingResponse = await container.ApiClient.Embeddings.GenerateEmbeddingAsync(
            model:"all-minilm",
            prompt: "hello");
        
        embeddingResponse.Embedding.Should().NotBeNullOrEmpty();
        
        if (container.Type == EnvironmentType.Local)
        {
            var models2 = await container.ApiClient.Models.ListRunningModelsAsync();
            models2.Models.Should().NotBeNullOrEmpty();
        }

    }
}