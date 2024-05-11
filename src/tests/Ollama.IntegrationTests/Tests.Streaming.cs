using System.Net;
using System.Text;
using System.Text.Json;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Returns_Streamed_Responses_At_Once()
    {
        await using var stream = new MemoryStream();

        var client = MockApiClient(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StreamContent(stream)
        });

        await using var writer = new StreamWriter(stream, leaveOpen: true);
        writer.AutoFlush = true;
        await writer.WriteCompletionStreamResponse("The ");
        await writer.WriteCompletionStreamResponse("sky ");
        await writer.WriteCompletionStreamResponse("is ");
        await writer.FinishCompletionStreamResponse("blue.", context: new int[] { 1, 2, 3 });
        stream.Seek(0, SeekOrigin.Begin);

        var context = await client.GetCompletionAsync(string.Empty, "prompt").WaitAsync();
        
        context.Response.Should().Be("The sky is blue.");
        context.Context.Should().BeEquivalentTo(new int[] { 1, 2, 3 });
    }

    [TestMethod]
    public async Task Streams_Response_Chunks()
    {
        await using var stream = new MemoryStream();

        var client = MockApiClient(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StreamContent(stream)
        });

        await using var writer = new StreamWriter(stream, leaveOpen: true);
        writer.AutoFlush = true;
        await writer.WriteCompletionStreamResponse("The ");
        await writer.WriteCompletionStreamResponse("sky ");
        await writer.WriteCompletionStreamResponse("is ");
        await writer.FinishCompletionStreamResponse("blue.", context: new int[] { 1, 2, 3 });
        stream.Seek(0, SeekOrigin.Begin);

        var builder = new StringBuilder();
        var enumerable = client.GetCompletionAsync("llama3", "prompt");
        IList<long>? context = null;
        await foreach (var s in enumerable)
        {
            builder.Append(s.Response);
            
            context = s.Context;
        }
        
        builder.ToString().Should().Be("The sky is blue.");
        context.Should().BeEquivalentTo(new int[] { 1, 2, 3 });
    }

    //[TestMethod]
    public async Task Streams_Response_Message_Chunks()
    {
        await using var stream = new MemoryStream();

        var client = MockApiClient(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StreamContent(stream)
        });

        await using var writer = new StreamWriter(stream, leaveOpen: true);
        writer.AutoFlush = true;
        await writer.WriteChatStreamResponse("Leave ", MessageRole.Assistant);
        await writer.WriteChatStreamResponse("me ", MessageRole.Assistant);
        await writer.FinishChatStreamResponse("alone.", MessageRole.Assistant);
        stream.Seek(0, SeekOrigin.Begin);

        var messages = new Message[]
        {
            new(MessageRole.User, "Why?"),
            new(MessageRole.Assistant, "Because!"),
            new(MessageRole.User, "And where?"),
        }.ToList();
        var chat = new GenerateChatCompletionRequest
        {
            Model = "model",
            Messages = messages,
        };

        var response = await client.SendChatAsync(chat).WaitAsync();
        messages.Add(response.Message!);
        
        messages.Count.Should().Be(4);

        messages[0].Role.Should().Be(MessageRole.User);
        messages[0].Content.Should().Be("Why?");

        messages[1].Role.Should().Be(MessageRole.Assistant);
        messages[1].Content.Should().Be("Because!");

        messages[2].Role.Should().Be(MessageRole.User);
        messages[2].Content.Should().Be("And where?");

        messages[3].Role.Should().Be(MessageRole.Assistant);
        messages[3].Content.Should().Be("Leave me alone.");
    }

    [TestMethod]
    public async Task Returns_Deserialized_Models()
    {
        var client = MockApiClient(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(
                "{\r\n\"models\": [\r\n{\r\n\"name\": \"codellama:latest\",\r\n\"modified_at\": \"2023-10-12T14:17:04.967950259+02:00\",\r\n\"size\": 3791811617,\r\n\"digest\": \"36893bf9bc7ff7ace56557cd28784f35f834290c85d39115c6b91c00a031cfad\"\r\n},\r\n{\r\n\"name\": \"llama2:latest\",\r\n\"modified_at\": \"2023-10-02T14:10:14.78152065+02:00\",\r\n\"size\": 3791737662,\r\n\"digest\": \"d5611f7c428cf71fb05660257d18e043477f8b46cf561bf86940c687c1a59f70\"\r\n},\r\n{\r\n\"name\": \"mistral:latest\",\r\n\"modified_at\": \"2023-10-02T14:16:24.841447764+02:00\",\r\n\"size\": 4108916688,\r\n\"digest\": \"8aa307f73b2622af521e8f22d46e4b777123c4df91898dcb2e4079dc8fdf579e\"\r\n},\r\n{\r\n\"name\": \"vicuna:latest\",\r\n\"modified_at\": \"2023-10-06T09:44:16.936312659+02:00\",\r\n\"size\": 3825517709,\r\n\"digest\": \"675fa173a76abc48325d395854471961abf74b664d91e92ffb4fc03e0bde652b\"\r\n}\r\n]\r\n}\r\n")
        });

        var models = await client.ListModelsAsync(CancellationToken.None);
        models.Count().Should().Be(4);

        var first = models.First();
        first.Name.Should().Be("codellama:latest");
        first.ModifiedAt.Date.Should().Be(new DateTime(2023, 10, 12));
        first.Size.Should().Be(3791811617);
        first.Digest.Should().StartWith("36893bf9bc7ff7ace5655");
    }

    [TestMethod]
    public async Task Returns_Deserialized_Models1()
    {
        var client = MockApiClient(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(
                "{\r\n  \"license\": \"<contents of license block>\",\r\n  \"modelfile\": \"# Modelfile generated by \\\"ollama show\\\"\\n\\n\",\r\n  \"parameters\": \"stop                           [INST]\\nstop [/INST]\\nstop <<SYS>>\\nstop <</SYS>>\",\r\n  \"template\": \"[INST] {{ if and .First .System }}<<SYS>>{{ .System }}<</SYS>>\\n\\n{{ end }}{{ .Prompt }} [/INST] \"\r\n}")
        });

        var info = await client.ShowModelInformationAsync("codellama:latest", CancellationToken.None);

        info.License.Should().Contain("contents of license block");
        info.Modelfile.Should().StartWith("# Modelfile generated");
        info.Parameters.Should().StartWith("stop");
        info.Template.Should().StartWith("[INST]");
    }

    [TestMethod]
    public async Task Returns_Deserialized_Models2()
    {
        var client = MockApiClient(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(
                "{\r\n  \"embedding\": [\r\n    0.5670403838157654, 0.009260174818336964, 0.23178744316101074, -0.2916173040866852, -0.8924556970596313  ]\r\n}")
        });

        var info = await client.GenerateEmbeddingsAsync(new GenerateEmbeddingRequest { Model = "", Prompt = "" },
            CancellationToken.None);

        info.Embedding.Should().NotBeNull();
        info.Embedding.Should().HaveCount(5);
        info.Embedding!.First().Should().BeApproximately(0.567, precision: 0.01);
    }
}

public static class WriterExtensions
{
    public static async Task WriteCompletionStreamResponse(this StreamWriter writer, string response)
    {
        var json = new { response, done = false };
        await writer.WriteLineAsync(JsonSerializer.Serialize(json));
    }

    public static async Task FinishCompletionStreamResponse(this StreamWriter writer, string response, int[] context)
    {
        var json = new { response, done = true, context };
        await writer.WriteLineAsync(JsonSerializer.Serialize(json));
    }

    public static async Task WriteChatStreamResponse(this StreamWriter writer, string content, string role)
    {
        var json = new { message = new { content, role }, role, done = false };
        await writer.WriteLineAsync(JsonSerializer.Serialize(json));
    }

    public static async Task FinishChatStreamResponse(this StreamWriter writer, string content, string role)
    {
        var json = new { message = new { content, role = role.ToString() }, role = role.ToString(), done = true };
        await writer.WriteLineAsync(JsonSerializer.Serialize(json));
    }
}