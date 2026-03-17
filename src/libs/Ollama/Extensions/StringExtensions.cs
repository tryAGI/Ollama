// ReSharper disable once CheckNamespace
namespace Ollama;

/// <summary>
/// 
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static ChatMessage AsUserMessage(this string content)
    {
        return new ChatMessage
        {
            Role = ChatMessageRole.User,
            Content = content,
        };
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static ChatMessage AsAssistantMessage(this string content)
    {
        return new ChatMessage
        {
            Role = ChatMessageRole.Assistant,
            Content = content,
        };
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static ChatMessage AsSystemMessage(this string content)
    {
        return new ChatMessage
        {
            Role = ChatMessageRole.System,
            Content = content,
        };
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static ChatMessage AsToolMessage(this string content)
    {
        return new ChatMessage
        {
            Role = ChatMessageRole.Tool,
            Content = content,
        };
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string AsJson(this object args)
    {
        return JsonSerializer.Serialize<object>(args, SourceGenerationContext.Default.Object);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tools"></param>
    /// <returns></returns>
    public static IList<ToolDefinition> AsOllamaTools(
        this IList<CSharpToJsonSchema.Tool> tools)
    {
        return tools
            .Select(x => new ToolDefinition
            {
                Type = ToolDefinitionType.Function,
                Function = new ToolDefinitionFunction
                {
                    Name = x.Name!,
                    Description = x.Description ?? string.Empty,
                    Parameters = x.Parameters ?? new object(),
                    AdditionalProperties = x.Strict == true
                        ? new Dictionary<string, object>
                        {
                            ["strict"] = true,
                        }
                        : new Dictionary<string, object>(),
                },
            })
            .ToList();
    }
}
