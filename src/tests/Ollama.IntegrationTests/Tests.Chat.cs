using System.Net;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Ollama.IntegrationTests;

public partial class Tests
{
	
	[TestMethod]
	public async Task Sends_Assistant_Answer_To_Streamer()
	{
		await using var stream = new MemoryStream();

		var client = MockApiClient(MessageRole.Assistant, "hi!");

		GenerateChatCompletionResponse? answerFromAssistant = null;
		var chat = new Chat(client, string.Empty)
		{
			Streamer = new ActionResponseStreamer<GenerateChatCompletionResponse>(answer => answerFromAssistant = answer)
		};
		await chat.SendAsync( "henlo", CancellationToken.None);

		answerFromAssistant.Should().NotBeNull();
		answerFromAssistant!.Message.Should().NotBeNull();
		answerFromAssistant!.Message!.Role.Should().Be(MessageRole.Assistant);
		answerFromAssistant.Message.Content.Should().Be("hi!");
	}

	[TestMethod]
	public async Task Sends_Messages_As_User()
	{
		var ollama = MockApiClient(MessageRole.Assistant, "hi!");

		var chat = new Chat(ollama, string.Empty);
		var history = (await chat.SendAsync("henlo", CancellationToken.None)).ToArray();

		history[0].Role.Should().Be(MessageRole.User);
		history[0].Content.Should().Be("henlo");
	}

	[TestMethod]
	public async Task Returns_User_And_Assistant_Message_History()
	{
		var ollama = MockApiClient(MessageRole.Assistant, "hi!");

		var chat = new Chat(ollama, string.Empty);
		var history = (await chat.SendAsync("henlo", CancellationToken.None)).ToArray();

		history.Length.Should().Be(2);
		history[0].Role.Should().Be(MessageRole.User);
		history[0].Content.Should().Be("henlo");
		history[1].Role.Should().Be(MessageRole.Assistant);
		history[1].Content.Should().Be("hi!");
	}

	[TestMethod]
	public async Task Sends_Messages_As_Defined_Role()
	{
		var ollama = MockApiClient(MessageRole.Assistant, "hi system!");

		var chat = new Chat(ollama, string.Empty);
		var history = (await chat.SendAsAsync(MessageRole.System, "henlo hooman", CancellationToken.None)).ToArray();

		history.Length.Should().Be(2);
		history[0].Role.Should().Be(MessageRole.System);
		history[0].Content.Should().Be("henlo hooman");
		history[1].Role.Should().Be(MessageRole.Assistant);
		history[1].Content.Should().Be("hi system!");
	}
}