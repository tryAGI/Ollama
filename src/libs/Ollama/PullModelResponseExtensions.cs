namespace Ollama;

/// <summary>
/// 
/// </summary>
public static class PullModelResponseExtensions
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="response"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentNullException"></exception>
	public static double GetPercent(this PullModelResponse response)
	{
		response = response ?? throw new ArgumentNullException(nameof(response));
		
		return response.Total == 0
			? 100.0
			: response.Completed * 100.0 / response.Total;
	}
}