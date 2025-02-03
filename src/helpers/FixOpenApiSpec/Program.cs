using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

var path = args[0];
var text = await File.ReadAllTextAsync(path);

var openApiDocument = new OpenApiStringReader().Read(text, out var diagnostics);
openApiDocument.Components.Schemas["GenerateCompletionRequest"]!.Properties["stream"]!.Default = new OpenApiBoolean(true);
openApiDocument.Components.Schemas["GenerateChatCompletionRequest"]!.Properties["stream"]!.Default = new OpenApiBoolean(true);
openApiDocument.Components.Schemas["CreateModelRequest"]!.Properties["stream"]!.Default = new OpenApiBoolean(true);
openApiDocument.Components.Schemas["PullModelRequest"]!.Properties["stream"]!.Default = new OpenApiBoolean(true);
openApiDocument.Components.Schemas["PushModelRequest"]!.Properties["stream"]!.Default = new OpenApiBoolean(true);

ConvertToAnyOf(openApiDocument.Components.Schemas["DoneReason"]!);
ConvertToAnyOf(openApiDocument.Components.Schemas["CreateModelStatus"]!);
ConvertToAnyOf(openApiDocument.Components.Schemas["PullModelStatus"]!);

openApiDocument.Components.Schemas["PushModelResponse"]!.Properties["status"] = new OpenApiSchema
{
    Description = "Status pushing the model.",
    AnyOf = new List<OpenApiSchema>
    {
        new()
        {
            Type = "string",
        },
        new()
        {
            Type = "string",
            Enum = new List<IOpenApiAny>
            {
                new OpenApiString("retrieving manifest"),
                new OpenApiString("starting upload"),
                new OpenApiString("pushing manifest"),
                new OpenApiString("success"),
            },
        },
    },
};

var currentResponseFormat = openApiDocument.Components.Schemas["ResponseFormat"]!;
openApiDocument.Components.Schemas["ResponseFormat"]!.OneOf = new List<OpenApiSchema>
{
    new()
    {
        Type = currentResponseFormat.Type,
        Enum = currentResponseFormat.Enum,
        Description = "Enable JSON mode by setting the format parameter to 'json'. This will structure the response as valid JSON.",
    },
    new()
    {
        Type = "object",
        Description = "A JSON Schema object that defines the structure of the response. The model will generate a response that matches this schema.",
    },
};
openApiDocument.Components.Schemas["ResponseFormat"].Enum = null;
openApiDocument.Components.Schemas["ResponseFormat"].Type = null;
openApiDocument.Components.Schemas["ResponseFormat"].Description = null;

text = openApiDocument.SerializeAsYaml(OpenApiSpecVersion.OpenApi3_0);
_ = new OpenApiStringReader().Read(text, out diagnostics);

if (diagnostics.Errors.Count > 0)
{
    foreach (var error in diagnostics.Errors)
    {
        Console.WriteLine(error.Message);
    }
    // Return Exit code 1
    Environment.Exit(1);
}

await File.WriteAllTextAsync(path, text);
return;

static void ConvertToAnyOf(OpenApiSchema schema)
{
    schema.Type = null;
    schema.AnyOf = new List<OpenApiSchema>
    {
        new()
        {
            Type = "string",
        },
        new()
        {
            Type = "string",
            Enum = schema.Enum,
        },
    };
    schema.Enum = null;
}