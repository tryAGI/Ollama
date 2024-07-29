//HintName: IVariousTypesFunctions.Tools.generated.cs

#nullable enable

namespace Ollama.IntegrationTests
{
    public static partial class VariousTypesFunctionsExtensions
    {
        public static global::System.Collections.Generic.IList<global::Ollama.Tool> AsTools(this IVariousTypesFunctions functions)
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
                            ["parameter1"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "integer",
                                Format = "int64",
                                Description = "",
                            },
                            ["parameter2"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "integer",
                                Format = "int32",
                                Description = "",
                            },
                            ["parameter3"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "number",
                                Format = "float",
                                Description = "",
                            },
                            ["parameter4"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "number",
                                Format = "double",
                                Description = "",
                            },
                            ["parameter5"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "boolean",
                                Description = "",
                            },
                            ["dateTime"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "string",
                                Format = "date-time",
                                Description = "",
                            },
                            ["date"] = new global::Ollama.OpenApiSchema
                            {
                                Type = "string",
                                Format = "date",
                                Description = "",
                            }
                        },
                        Required = new string[] { "parameter1", "parameter2", "parameter3", "parameter4", "parameter5", "dateTime", "date" },
                    },
                    },
                    Type = global::Ollama.ToolType.Function,
                },
            };
        }
    }
}