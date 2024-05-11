using System.Diagnostics.CodeAnalysis;

namespace Ollama;

public partial class Message
{
	/// <summary>
	/// 
	/// </summary>
	public Message()
	{
	}
	
	/// <summary>
	/// 
	/// </summary>
	/// <param name="role"></param>
	/// <param name="content"></param>
	[SetsRequiredMembers]
	public Message(string role, string content)
	{
		Role = role;
		Content = content;
	}
}