/*
order: 60
title: Chat Client Get Service Returns Self
slug: chat-client-get-service-returns-self
*/

using Microsoft.Extensions.AI;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public void ChatClient_GetService_ReturnsSelf()
    {
        using var client = new OllamaClient();
        IChatClient chatClient = client;

        var self = chatClient.GetService<OllamaClient>();

        self.Should().BeSameAs(client);
    }
}
