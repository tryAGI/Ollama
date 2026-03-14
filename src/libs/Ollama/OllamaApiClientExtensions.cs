using System.Runtime.CompilerServices;
using System.Text.Json;
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
		this IAsyncEnumerable<StatusEvent> enumerable)
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
		this StatusEvent response)
	{
		response = response ?? throw new ArgumentNullException(nameof(response));

		if (!string.Equals(response.Status, "success", StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException($"Failed to pull model with status {response.Status}");
		}
	}

	/// <summary>
	/// Throws an InvalidOperationException if the response is not successful.
	/// </summary>
	/// <param name="response"></param>
	public static void EnsureSuccess(
		this StatusResponse response)
	{
		response = response ?? throw new ArgumentNullException(nameof(response));

		if (!string.Equals(response.Status, "success", StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException($"Failed with status {response.Status}");
		}
	}
	
	/// <summary>
	/// Waits for the enumerable to complete and combines the responses into a single response.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static async Task<GenerateResponse> WaitAsync(
		this IAsyncEnumerable<GenerateStreamEvent> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		var content = new StringBuilder();
		var thinking = new StringBuilder();
		var currentResponse = new GenerateResponse();
		await foreach (var response in enumerable.ConfigureAwait(false))
		{
			content.Append(response.Response);
			thinking.Append(response.Thinking);
			currentResponse = new GenerateResponse
			{
				Model = response.Model,
				CreatedAt = response.CreatedAt,
				Done = response.Done,
				DoneReason = response.DoneReason,
				TotalDuration = response.TotalDuration,
				LoadDuration = response.LoadDuration,
				PromptEvalCount = response.PromptEvalCount,
				PromptEvalDuration = response.PromptEvalDuration,
				EvalCount = response.EvalCount,
				EvalDuration = response.EvalDuration,
			};
		}
		
		currentResponse.Response = content.ToString();
		if (thinking.Length > 0)
		{
			currentResponse.Thinking = thinking.ToString();
		}

		return currentResponse;
	}

	/// <inheritdoc cref="WaitAsync(IAsyncEnumerable{GenerateStreamEvent})"/>
	public static TaskAwaiter<GenerateResponse> GetAwaiter(
		this IAsyncEnumerable<GenerateStreamEvent> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		return enumerable.WaitAsync().GetAwaiter();
	}

	/// <summary>
	/// Waits for the enumerable to complete and combines the responses into a single response.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static async Task<ChatResponse> WaitAsync(
		this IAsyncEnumerable<ChatStreamEvent> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		string? responseRole = null;
		IList<ToolCall>? toolCalls = null;
		IList<string>? images = null;
		var responseContent = new StringBuilder();
		var responseThinking = new StringBuilder();
		
		var currentResponse = new ChatResponse
		{
			Message = new ChatResponseMessage
			{
				Role = ChatResponseMessageRole.Assistant,
				Content = string.Empty,
			},
			Model = string.Empty,
			CreatedAt = DateTime.UtcNow,
			Done = true,
		};
		await foreach (var response in enumerable.ConfigureAwait(false))
		{
			responseRole ??= response.Message?.Role;
			toolCalls ??= response.Message?.ToolCalls;
			images ??= response.Message?.Images;
			responseContent.Append(response.Message?.Content);
			responseThinking.Append(response.Message?.Thinking);
			
			currentResponse = new ChatResponse
			{
				Model = response.Model,
				CreatedAt = response.CreatedAt,
				Done = response.Done,
				DoneReason = GetString(response.AdditionalProperties, "done_reason"),
				TotalDuration = GetInt(response.AdditionalProperties, "total_duration"),
				LoadDuration = GetInt(response.AdditionalProperties, "load_duration"),
				PromptEvalCount = GetInt(response.AdditionalProperties, "prompt_eval_count"),
				PromptEvalDuration = GetInt(response.AdditionalProperties, "prompt_eval_duration"),
				EvalCount = GetInt(response.AdditionalProperties, "eval_count"),
				EvalDuration = GetInt(response.AdditionalProperties, "eval_duration"),
			};
		}
		
		currentResponse.Message = new ChatResponseMessage
		{
			Role = string.Equals(responseRole, "assistant", StringComparison.OrdinalIgnoreCase)
				? ChatResponseMessageRole.Assistant
				: ChatResponseMessageRole.Assistant,
			Content = responseContent.ToString(),
			Thinking = responseThinking.Length > 0 ? responseThinking.ToString() : null,
			ToolCalls = toolCalls,
			Images = images,
		};

		return currentResponse;
	}

	/// <inheritdoc cref="WaitAsync(IAsyncEnumerable{ChatStreamEvent})"/>
	public static TaskAwaiter<ChatResponse> GetAwaiter(
		this IAsyncEnumerable<ChatStreamEvent> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		return enumerable.WaitAsync().GetAwaiter();
	}

	/// <summary>
	/// Waits for the enumerable to complete and returns the responses.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static async Task<IReadOnlyList<StatusEvent>> WaitAsync(
		this IAsyncEnumerable<StatusEvent> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		var responses = new List<StatusEvent>();
		await foreach (var response in enumerable.ConfigureAwait(false))
		{
			responses.Add(response);
		}
	
		return responses;
	}
	
	/// <inheritdoc cref="WaitAsync(IAsyncEnumerable{StatusEvent})"/>
	public static TaskAwaiter<IReadOnlyList<StatusEvent>> GetAwaiter(
		this IAsyncEnumerable<StatusEvent> enumerable)
	{
		enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
		
		return enumerable.WaitAsync().GetAwaiter();
	}

	/// <summary>
	/// Converts a chat response message into a chat history message.
	/// </summary>
	/// <param name="message"></param>
	public static ChatMessage ToChatMessage(
		this ChatResponseMessage message)
	{
		message = message ?? throw new ArgumentNullException(nameof(message));

		return new ChatMessage
		{
			Role = ChatMessageRole.Assistant,
			Content = message.Content ?? string.Empty,
			Images = message.Images,
			ToolCalls = message.ToolCalls,
		};
	}

	/// <summary>
	/// Converts a streamed chat message chunk into a chat history message.
	/// </summary>
	/// <param name="message"></param>
	public static ChatMessage ToChatMessage(
		this ChatStreamEventMessage message)
	{
		message = message ?? throw new ArgumentNullException(nameof(message));

		return new ChatMessage
		{
			Role = ChatMessageRoleExtensions.ToEnum(message.Role ?? string.Empty) ?? ChatMessageRole.Assistant,
			Content = message.Content ?? string.Empty,
			Images = message.Images,
			ToolCalls = message.ToolCalls,
		};
	}

	private static string? GetString(
		IDictionary<string, object>? additionalProperties,
		string name)
	{
		if (additionalProperties?.TryGetValue(name, out var value) != true)
		{
			return null;
		}

		return value switch
		{
			null => null,
			string stringValue => stringValue,
			JsonElement jsonElement when jsonElement.ValueKind == JsonValueKind.String => jsonElement.GetString(),
			JsonElement jsonElement => jsonElement.ToString(),
			_ => value.ToString(),
		};
	}

	private static int? GetInt(
		IDictionary<string, object>? additionalProperties,
		string name)
	{
		if (additionalProperties?.TryGetValue(name, out var value) != true)
		{
			return null;
		}

		return value switch
		{
			int intValue => intValue,
			long longValue when longValue <= int.MaxValue && longValue >= int.MinValue => (int)longValue,
			JsonElement jsonElement when jsonElement.ValueKind == JsonValueKind.Number && jsonElement.TryGetInt32(out var intValue) => intValue,
			_ => null,
		};
	}
}
