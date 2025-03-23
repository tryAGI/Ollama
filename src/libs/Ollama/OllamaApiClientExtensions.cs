using System.Runtime.CompilerServices;
using System.Text;

namespace Ollama;

/// <summary>
/// 
/// </summary>
public static class OllamaApiClientExtensions
{
	/// <summary>
	/// Starts a new chat with the currently selected model.
	/// </summary>
	/// <param name="client">The client to start the chat with</param>
	/// <param name="model">The model to chat with</param>
	/// <param name="systemMessage">Optional. A system message to send to the model</param>
	/// <param name="autoCallTools">Optional. If set to true, the client will automatically call tools.</param>
	/// <returns>
	/// A chat instance that can be used to receive and send messages from and to
	/// the Ollama endpoint while maintaining the message history.
	/// </returns>
	public static Chat Chat(
		this IOllamaApiClient client,
		string model,
		string? systemMessage = null,
		bool autoCallTools = true)
	{
		return new Chat(client, model, systemMessage)
		{
			AutoCallTools = autoCallTools,
		};
	}
	
	/// <summary>
	/// Pulls the specified model from the server and ensures the operation was successful. <br/>
	/// Safe to call if model already exists. <br/>
	/// </summary>
	/// <exception cref="ArgumentNullException">Thrown when the enumerable is null.</exception>
	/// <exception cref="InvalidOperationException">Thrown when the response status is not "success".</exception>
	public static async Task EnsureSuccessAsync(
		this IAsyncEnumerable<PullModelResponse> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		var responses = await enumerable.WaitAsync().ConfigureAwait(false);
		if (responses.Count == 0)
		{
			throw new InvalidOperationException("No responses received.");
		}
		
		responses[^1].EnsureSuccess();
	}
	
	/// <summary>
	/// Throws an InvalidOperationException if the response is not successful.
	/// </summary>
	/// <param name="response"></param>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="InvalidOperationException"></exception>
	public static void EnsureSuccess(
		this PullModelResponse response)
	{
		response = response ?? throw new ArgumentNullException(nameof(response));

		if (response.Status?.Value2 != PullModelStatusEnum.Success)
		{
			throw new InvalidOperationException($"Failed to pull model with status {response.Status?.Object}");
		}
	}
	
	/// <summary>
	/// Waits for the enumerable to complete and combines the responses into a single response.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static async Task<GenerateCompletionResponse> WaitAsync(
		this IAsyncEnumerable<GenerateCompletionResponse> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		var content = new StringBuilder();
		var currentResponse = new GenerateCompletionResponse();
		await foreach (var response in enumerable.ConfigureAwait(false))
		{
			content.Append(response.Response);
			currentResponse = response;
		}
		
		currentResponse.Response = content.ToString();

		return currentResponse;
	}

	/// <inheritdoc cref="WaitAsync(IAsyncEnumerable{GenerateCompletionResponse})"/>
	public static TaskAwaiter<GenerateCompletionResponse> GetAwaiter(
		this IAsyncEnumerable<GenerateCompletionResponse> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		return enumerable.WaitAsync().GetAwaiter();
	}

	/// <summary>
	/// Waits for the enumerable to complete and combines the responses into a single response.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static async Task<GenerateChatCompletionResponse> WaitAsync(
		this IAsyncEnumerable<GenerateChatCompletionResponse> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		MessageRole? responseRole = null;
		IList<ToolCall>? toolCalls = null;
		var responseContent = new StringBuilder();
		
		var currentResponse = new GenerateChatCompletionResponse
		{
			Message = new Message
			{
				Role = MessageRole.User,
				Content = string.Empty,
			},
			Model = string.Empty,
			CreatedAt = DateTime.UtcNow,
			Done = true,
		};
		await foreach (var response in enumerable.ConfigureAwait(false))
		{
			responseRole ??= response.Message.Role;
			toolCalls ??= response.Message.ToolCalls;
			responseContent.Append(response.Message.Content);
			
			currentResponse = response;
		}
		
		currentResponse.Message = new Message
		{
			Role = responseRole ?? MessageRole.User,
			Content = responseContent.ToString(),
			ToolCalls = toolCalls,
		};

		return currentResponse;
	}

	/// <inheritdoc cref="WaitAsync(IAsyncEnumerable{GenerateChatCompletionResponse})"/>
	public static TaskAwaiter<GenerateChatCompletionResponse> GetAwaiter(
		this IAsyncEnumerable<GenerateChatCompletionResponse> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		return enumerable.WaitAsync().GetAwaiter();
	}

	/// <summary>
	/// Waits for the enumerable to complete and returns the responses.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static async Task<IReadOnlyList<PullModelResponse>> WaitAsync(
		this IAsyncEnumerable<PullModelResponse> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		var responses = new List<PullModelResponse>();
		await foreach (var response in enumerable.ConfigureAwait(false))
		{
			responses.Add(response);
		}
	
		return responses;
	}
	
	/// <inheritdoc cref="WaitAsync(IAsyncEnumerable{PullModelResponse})"/>
	public static TaskAwaiter<IReadOnlyList<PullModelResponse>> GetAwaiter(
		this IAsyncEnumerable<PullModelResponse> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		return enumerable.WaitAsync().GetAwaiter();
	}
}