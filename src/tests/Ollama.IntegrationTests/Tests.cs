namespace Ollama.IntegrationTests;

[TestClass]
public class GeneralTests
{
    // [TestMethod]
    // public async Task Complete()
    // {
    //     var apiKey =
    //         Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY") ??
    //         throw new AssertInconclusiveException("ANTHROPIC_API_KEY environment variable is not found.");
    //
    //     using var client = new HttpClient();
    //     var api = new OllamaApi(apiKey, client);
    //     var response = await api.CompleteAsync(new CreateCompletionRequest
    //     {
    //         Model = ModelIds.ClaudeInstant,
    //         Prompt = "Once upon a time".AsPrompt(),
    //         Max_tokens_to_sample = 250,
    //     });
    //     response.Model.Should().Be(ModelIds.ClaudeInstant);
    //     response.Completion.Should().NotBeNullOrEmpty();
    //     response.Stop_reason.Should().Be(CreateCompletionResponseStop_reason.Stop_sequence);
    // }
}
