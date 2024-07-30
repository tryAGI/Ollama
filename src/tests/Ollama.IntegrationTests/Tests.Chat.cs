namespace Ollama.IntegrationTests;

public partial class Tests
{
	[TestMethod]
	public async Task Sends_Assistant_Answer_To_Streamer()
	{
		await using var stream = new MemoryStream();

		var client = MockApiClient(MessageRole.Assistant, "hi!");

		var chat = new Chat(client, string.Empty);
		var message = await chat.SendAsync( "henlo");

		message.Should().NotBeNull();
		message.Role.Should().Be(MessageRole.Assistant);
		message.Content.Should().Be("hi!");
	}

	[TestMethod]
	public async Task Sends_Messages_As_User()
	{
		var ollama = MockApiClient(MessageRole.Assistant, "hi!");

		var chat = new Chat(ollama, string.Empty);
		var message = await chat.SendAsync("henlo");

		chat.History[0].Role.Should().Be(MessageRole.User);
		chat.History[0].Content.Should().Be("henlo");
	}

	[TestMethod]
	public async Task Returns_User_And_Assistant_Message_History()
	{
		var ollama = MockApiClient(MessageRole.Assistant, "hi!");

		var chat = new Chat(ollama, string.Empty);
		var message = await chat.SendAsync("henlo");
		var history = chat.History;

		history.Count.Should().Be(2);
		history[0].Role.Should().Be(MessageRole.User);
		history[0].Content.Should().Be("henlo");
		history[1].Role.Should().Be(MessageRole.Assistant);
		history[1].Content.Should().Be("hi!");
		history[1].Should().BeEquivalentTo(message);
	}

	[TestMethod]
	public async Task Sends_Messages_As_Defined_Role()
	{
		var ollama = MockApiClient(MessageRole.Assistant, "hi system!");

		var chat = new Chat(ollama, string.Empty);
		var message = await chat.SendAsync("henlo hooman", MessageRole.System);

		chat.History.Count.Should().Be(2);
		chat.History[0].Role.Should().Be(MessageRole.System);
		chat.History[0].Content.Should().Be("henlo hooman");
		chat.History[1].Role.Should().Be(MessageRole.Assistant);
		chat.History[1].Content.Should().Be("hi system!");
		chat.History[1].Should().BeEquivalentTo(message);
	}
}