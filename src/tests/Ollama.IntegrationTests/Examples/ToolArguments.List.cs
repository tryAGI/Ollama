/*
order: 205
title: List-valued tool arguments
slug: list-tool-arguments
*/

using System.Text.Json;

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public void ToolArguments_WithObjectList_SerializeWithGeneratedContext()
    {
        var request = new ChatRequest
        {
            Model = "test-model",
            Messages =
            [
                new ChatMessage
                {
                    Role = ChatMessageRole.Assistant,
                    Content = string.Empty,
                    ToolCalls =
                    [
                        new ToolCall
                        {
                            Function = new ToolCallFunction
                            {
                                Name = "read_multiple_files",
                                Arguments = new Dictionary<string, object>
                                {
                                    ["paths"] = new List<object>
                                    {
                                        "/tmp/one.txt",
                                        "/tmp/two.txt",
                                    },
                                },
                            },
                        },
                    ],
                },
            ],
        };

        string json = request.ToJson(SourceGenerationContext.Default);
        using JsonDocument document = JsonDocument.Parse(json);
        JsonElement paths = document.RootElement
            .GetProperty("messages")[0]
            .GetProperty("tool_calls")[0]
            .GetProperty("function")
            .GetProperty("arguments")
            .GetProperty("paths");

        paths.GetArrayLength().Should().Be(2);
        paths[1].GetString().Should().Be("/tmp/two.txt");
    }
}
