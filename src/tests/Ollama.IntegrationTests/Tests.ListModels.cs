namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task ListModels()
    {
        await using var container = await Environment.PrepareAsync(environmentType: EnvironmentType.Container);
        
        var models = await container.Client.ListAsync();
        models.Models.Should().BeNullOrEmpty();
        
        await container.Client.PullAsStreamAsync("all-minilm").EnsureSuccessAsync();
        
        models = await container.Client.ListAsync();
        models.Models.Should().NotBeNull();
        models.Models.Should().HaveCount(1);
        models.Models![0].Model.Should().Be("all-minilm:latest");
    }
}
