using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task StructuredOutputInChat()
    {
#if DEBUG
        await using var container = await Environment.PrepareAsync(EnvironmentType.Local, "llama3.2");
#else
        await using var container = await Environment.PrepareAsync(EnvironmentType.Container, "llama3.2");
#endif

        var chat = container.ApiClient.Chat(
            model: "llama3.2",
            systemMessage: "You are a helpful weather assistant."
        );

        // can also use NewtonSoft.Json.Schema or some other auto schema generation library
        var schemaObject = JsonSerializer.Deserialize<object>(@"{
            ""description"": ""The response to a query about the weather"",
            ""type"": ""object"",
            ""required"": [""Temperature"", ""Location"", ""Unit""],
            ""properties"": {
                ""Temperature"": {
                    ""type"": ""integer""
                },
                ""Location"": {
                    ""type"": ""string""
                },
                ""Unit"": {
                    ""type"": ""string"",
                    ""enum"": [""Celsius"", ""Fahrenheit""]
                }
            }
        }");

        try
        {
            Console.WriteLine($"schemaObject: {schemaObject}");
            chat.ResponseFormat = new ResponseFormat(schemaObject);
            var response = await chat.SendAsync("What is the current temperature in Dubai, UAE in Celsius? (hint: it's 25C in Dubai right now)");
            Console.WriteLine(response);
            var queryResponse = JsonSerializer.Deserialize<QueryResponse>(response.Content);
            queryResponse.Should().NotBeNull();
            queryResponse.Temperature.Should().Be(25);
            queryResponse.Location.Should().Contain("Dubai");
        }
        finally
        {
            Console.WriteLine(chat.PrintMessages());
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TemperatureUnit
    {
        Celsius,
        Fahrenheit
    }

    public class QueryResponse {

        public int Temperature { get; set; }
        public TemperatureUnit Unit { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}