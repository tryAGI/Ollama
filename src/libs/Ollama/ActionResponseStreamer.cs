namespace Ollama;

/// <inheritdoc />
public class ActionResponseStreamer<T>(Action<T> responseHandler) : IResponseStreamer<T>
{
	/// <summary>
	/// 
	/// </summary>
	public Action<T> ResponseHandler { get; } = responseHandler ?? throw new ArgumentNullException(nameof(responseHandler));

	/// <inheritdoc />
	public void Stream(T stream)
	{
		ResponseHandler(stream);
	}
}