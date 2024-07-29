//HintName: IWeatherFunctions.Tools.generated.cs

#nullable enable

namespace Ollama.IntegrationTests
{
    public static partial class WeatherFunctionsExtensions
    {
        public static global::System.Collections.Generic.IList<global::Ollama.Tool> AsTools(this IWeatherFunctions functions)
        {
            return new global::System.Collections.Generic.List<global::Ollama.Tool>
            {
                new global::Ollama.Tool
                {
                    Function = new global::Ollama.ToolFunction
                    {
                        Name = "GetCurrentWeather",
                        Description = "Get the current weather in a given location",
                        Parameters = new global::Ollama.ToolFunctionParams
                    {
                        Type = "object",
                        Description = "Get the current weather in a given location",
                        Properties = new global::System.Collections.Generic.Dictionary<string, global::Ollama.OpenApiSchema>
                        {
                            ["location"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "string",
                                Description = "The city and state, e.g. San Francisco, CA",
                            },
                            ["unit"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "string",
                                Description = "",
                                Enum = new string[] { "celsius", "fahrenheit" },
                            }
                        },
                        Required = new string[] { "location" },
                    },
                    },
                    Type = global::Ollama.ToolType.Function,
                },

                new global::Ollama.Tool
                {
                    Function = new global::Ollama.ToolFunction
                    {
                        Name = "GetCurrentWeatherAsync",
                        Description = "Get the current weather in a given location",
                        Parameters = new global::Ollama.ToolFunctionParams
                    {
                        Type = "object",
                        Description = "Get the current weather in a given location",
                        Properties = new global::System.Collections.Generic.Dictionary<string, global::Ollama.OpenApiSchema>
                        {
                            ["location"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "string",
                                Description = "The city and state, e.g. San Francisco, CA",
                            },
                            ["unit"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "string",
                                Description = "",
                                Enum = new string[] { "celsius", "fahrenheit" },
                            }
                        },
                        Required = new string[] { "location" },
                    },
                    },
                    Type = global::Ollama.ToolType.Function,
                },
            };
        }
    }
}