/*
order: 50
title: Chat Client Get Service Returns Null For Unknown Key
slug: chat-client-get-service-returns-null-for-unknown-key
*/

using Microsoft.Extensions.AI;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public void ChatClient_GetService_ReturnsNullForUnknownKey()
    {
        using var client = new OllamaClient();
        IChatClient chatClient = client;

        var result = chatClient.GetService<ChatClientMetadata>(serviceKey: "unknown");

        result.Should().BeNull();
    }
}
