namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task ListModels()
    {
        await using var container = await Environment.PrepareAsync(environmentType: EnvironmentType.Container);
        
        var models = await container.Client.ListAsync();
        var initialCount = models.Models?.Count ?? 0;
        
        await container.Client.PullAsStreamAsync(TestModels.Embeddings).EnsureSuccessAsync();
        
        models = await container.Client.ListAsync();
        models.Models.Should().NotBeNull();
        models.Models!.Count.Should().BeGreaterThan(initialCount - 1);
        models.Models.Any(model =>
            model.Model != null &&
            model.Model.StartsWith(TestModels.Embeddings, StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
    }
}
