/*
order: 140
title: Get Completion With Options
slug: get-completion-with-options
*/

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task GetCompletionWithOptions()
    {
        await using var container = await Environment.PrepareAsync(TestModels.Chat);

        var response = await container.Client.GenerateAsync(new GenerateRequest
        {
            Model = TestModels.Chat,
            Prompt = "answer me just \"123\"",
            Options = new ModelOptions
            {
                Temperature = 0,
            },
        });
        Console.WriteLine(response.Response);
    }
}
