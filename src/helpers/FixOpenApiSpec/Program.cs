using System.Text.Json.Nodes;
using AutoSDK.Extensions;
using AutoSDK.Models;
using Microsoft.OpenApi;

var path = args[0];
var yamlOrJson = await File.ReadAllTextAsync(path);

var openApiDocument = yamlOrJson.GetOpenApiDocument(Settings.Default);

((OpenApiSchema)openApiDocument.Components!.Schemas!["GenerateCompletionRequest"]!.Properties!["stream"]!).Default = JsonValue.Create(true);
((OpenApiSchema)openApiDocument.Components.Schemas["GenerateChatCompletionRequest"]!.Properties!["stream"]!).Default = JsonValue.Create(true);
((OpenApiSchema)openApiDocument.Components.Schemas["CreateModelRequest"]!.Properties!["stream"]!).Default = JsonValue.Create(true);
((OpenApiSchema)openApiDocument.Components.Schemas["PullModelRequest"]!.Properties!["stream"]!).Default = JsonValue.Create(true);
((OpenApiSchema)openApiDocument.Components.Schemas["PushModelRequest"]!.Properties!["stream"]!).Default = JsonValue.Create(true);

ConvertToAnyOf((OpenApiSchema)openApiDocument.Components.Schemas["DoneReason"]!);
ConvertToAnyOf((OpenApiSchema)openApiDocument.Components.Schemas["CreateModelStatus"]!);
ConvertToAnyOf((OpenApiSchema)openApiDocument.Components.Schemas["PullModelStatus"]!);

openApiDocument.Components.Schemas["PushModelResponse"]!.Properties!["status"] = new OpenApiSchema
{
    Description = "Status pushing the model.",
    AnyOf = new List<IOpenApiSchema>
    {
        new OpenApiSchema
        {
            Type = JsonSchemaType.String,
        },
        new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            Enum = new List<JsonNode>
            {
                JsonValue.Create("retrieving manifest")!,
                JsonValue.Create("starting upload")!,
                JsonValue.Create("pushing manifest")!,
                JsonValue.Create("success")!,
            },
        },
    },
};

var currentResponseFormat = (OpenApiSchema)openApiDocument.Components.Schemas["ResponseFormat"]!;
var responseFormatSchema = (OpenApiSchema)openApiDocument.Components.Schemas["ResponseFormat"]!;
responseFormatSchema.OneOf = new List<IOpenApiSchema>
{
    new OpenApiSchema
    {
        Type = currentResponseFormat.Type,
        Enum = currentResponseFormat.Enum,
        Description = "Enable JSON mode by setting the format parameter to 'json'. This will structure the response as valid JSON.",
    },
    new OpenApiSchema
    {
        Type = JsonSchemaType.Object,
        Description = "A JSON Schema object that defines the structure of the response. The model will generate a response that matches this schema.",
    },
};
responseFormatSchema.Enum = null;
responseFormatSchema.Type = null;
responseFormatSchema.Description = null;

yamlOrJson = await openApiDocument.SerializeAsYamlAsync(OpenApiSpecVersion.OpenApi3_2);

await File.WriteAllTextAsync(path, yamlOrJson);
return;

static void ConvertToAnyOf(OpenApiSchema schema)
{
    schema.Type = null;
    schema.AnyOf = new List<IOpenApiSchema>
    {
        new OpenApiSchema
        {
            Type = JsonSchemaType.String,
        },
        new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            Enum = schema.Enum,
        },
    };
    schema.Enum = null;
}
