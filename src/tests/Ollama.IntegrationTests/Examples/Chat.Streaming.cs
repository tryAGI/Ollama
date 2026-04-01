/*
order: 20
title: Chat Streaming
slug: chat-streaming
*/

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Chat_Streaming()
    {
        await using var container = await Environment.PrepareAsync(TestModels.Chat);

        var chat = container.Client.Chat(TestModels.Chat);
        var deltas = new List<string>();
        var message = await chat.SendAsync(
            message: "answer 5 random words",
            onResponseChunk: (isFirstChunk, chunk) =>
            {
                if (isFirstChunk)
                {
                    Console.Write("> ");
                }

                if (chunk != null)
                {
                    deltas.Add(chunk);
                    Console.Write(chunk);
                }
            });

        Console.WriteLine();

        deltas.Should().NotBeEmpty();
        string.Concat(deltas).Should().NotBeNullOrWhiteSpace();
        message.Content.Should().Be(string.Concat(deltas));
    }
}
