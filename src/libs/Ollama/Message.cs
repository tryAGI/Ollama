namespace Ollama;

public partial class Message
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static implicit operator Message(string content)
    {
        return ToMessage(content);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Message ToMessage(string content)
    {
        return new Message
        {
            Role = MessageRole.User,
            Content = content,
        };
    }
}