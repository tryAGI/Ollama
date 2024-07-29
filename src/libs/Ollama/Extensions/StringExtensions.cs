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
    public static string AsJson(this ToolCallFunctionArgs args)
    {
        return JsonSerializer.Serialize(args, SourceGenerationContext.Default.ToolCallFunctionArgs);
    }
}