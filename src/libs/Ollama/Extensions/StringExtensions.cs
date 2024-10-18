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
    public static Message AsUserMessage(this string content)
    {
        return new Message
        {
            Role = MessageRole.User,
            Content = content,
        };
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Message AsAssistantMessage(this string content)
    {
        return new Message
        {
            Role = MessageRole.Assistant,
            Content = content,
        };
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Message AsSystemMessage(this string content)
    {
        return new Message
        {
            Role = MessageRole.System,
            Content = content,
        };
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Message AsToolMessage(this string content)
    {
        return new Message
        {
            Role = MessageRole.Tool,
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
    public static IList<Tool> AsOllamaTools(
        this IList<CSharpToJsonSchema.Tool> tools)
    {
        return tools
            .Select(x => new Tool
            {
                Type = ToolType.Function,
                Function = new ToolFunction
                {
                    Name = x.Name!,
                    Description = x.Description ?? string.Empty,
                    Parameters = x.Parameters ?? new ToolFunctionParams(),
                },
            })
            .ToList();
    }
}