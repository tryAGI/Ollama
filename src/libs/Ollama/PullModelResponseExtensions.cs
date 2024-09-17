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

		if (response.Total == null || response.Completed == null)
		{
			return 0;
		}
		
		return response.Total.Value == 0
			? 100.0
			: response.Completed.Value * 100.0 / response.Total.Value;
	}
}