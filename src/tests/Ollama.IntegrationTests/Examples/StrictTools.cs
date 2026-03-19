/*
order: 180
title: Strict Tools
slug: strict-tools
*/

namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public void ToolsAreMarkedStrictForOllama()
    {
        var service = new WeatherService();

        var tools = service.AsTools();
        tools.Should().NotBeEmpty();
        foreach (var tool in tools)
        {
            tool.Strict.Should().BeTrue();
        }

        var ollamaTools = tools.AsOllamaTools();
        ollamaTools.Should().NotBeEmpty();
        foreach (var tool in ollamaTools)
        {
            tool.Function.AdditionalProperties.TryGetValue("strict", out var strict).Should().BeTrue();
            strict.Should().Be(true);
        }
    }
}
