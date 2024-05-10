namespace Ollama;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IResponseStreamer<T>
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="stream"></param>
	void Stream(T stream);
}