using Microsoft.Extensions.AI;
using MeaiChatMessage = Microsoft.Extensions.AI.ChatMessage;
using MeaiChatRole = Microsoft.Extensions.AI.ChatRole;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task ChatClient_FiveRandomWords()
    {
        await using var environment = await Environment.PrepareAsync(TestModels.Chat);

        IChatClient client = environment.Client;
        var response = await client.GetResponseAsync(
            messages:
            [
                new MeaiChatMessage(MeaiChatRole.User, "Generate 5 random words.")
            ],
            options: new ChatOptions
            {
                ModelId = TestModels.Chat,
            });

        response.Messages.Should().ContainSingle();
        response.Text.Should().NotBeNullOrWhiteSpace();
        response.Messages[0].Role.Should().Be(MeaiChatRole.Assistant);
        response.Messages[0].Text.Should().NotBeNullOrWhiteSpace();
    }

    [TestMethod]
    public async Task ChatClient_FiveRandomWords_Streaming()
    {
        await using var environment = await Environment.PrepareAsync(TestModels.Chat);

        IChatClient client = environment.Client;
        var updates = client.GetStreamingResponseAsync(
            messages:
            [
                new MeaiChatMessage(MeaiChatRole.User, "Generate 5 random words.")
            ],
            options: new ChatOptions
            {
                ModelId = TestModels.Chat,
            });

        var deltas = new List<string>();
        await foreach (var update in updates)
        {
            if (!string.IsNullOrWhiteSpace(update.Text))
            {
                deltas.Add(update.Text);
            }
        }

        deltas.Should().NotBeEmpty();
        string.Concat(deltas).Should().NotBeNullOrWhiteSpace();
    }
}
