namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task GetCompletion()
    {
#if DEBUG
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Local, "llama3");
#else
        await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container, "llama3");
#endif

        IList<long>? context = null;
        var enumerable = container.ApiClient.Completions.GenerateCompletionAsync("llama3", "answer 5 random words", stream: true);
        await foreach (var response in enumerable)
        {
            Console.WriteLine($"> {response.Response}");
            
            context = response.Context;
        }
        
        var lastResponse = await container.ApiClient.Completions.GenerateCompletionAsync("llama3", "answer 123", stream: false, context: context).WaitAsync();
        Console.WriteLine(lastResponse.Response);
    }
}