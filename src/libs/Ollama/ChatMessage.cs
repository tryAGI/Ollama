namespace Ollama;

public partial class ChatMessage
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static implicit operator ChatMessage(string content)
    {
        return FromString(content);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static ChatMessage FromString(string content)
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
    public static ChatMessage ToChatMessage(string content)
    {
        return FromString(content);
    }
}
