namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task ListModels()
    {
        await using var container = await Environment.PrepareAsync(environmentType: EnvironmentType.Container);
        
        var models = await container.ApiClient.Models.ListModelsAsync();
        models.Models.Should().BeNullOrEmpty();
        
        await container.ApiClient.Models.PullModelAsync("all-minilm").EnsureSuccessAsync();
        
        models = await container.ApiClient.Models.ListModelsAsync();
        models.Models.Should().NotBeNull();
        models.Models.Should().HaveCount(1);
        models.Models![0].Model1.Should().Be("all-minilm:latest");
    }
}