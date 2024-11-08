using Microsoft.Extensions.AI;

namespace Ollama;

public partial class OllamaApiClient : Microsoft.Extensions.AI.IChatClient
{
    /// <inheritdoc />
    public async Task<ChatCompletion> CompleteAsync(
        IList<ChatMessage> chatMessages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var response = await Chat.GenerateChatCompletionAsync(
            model: options?.ModelId ?? "ollama",
            messages: chatMessages.Select(x => new Message
            {
                Content = x.Text ?? string.Empty,
                Role = x.Role.Value switch
                {
                    "assistant" => MessageRole.Assistant,
                    "user" => MessageRole.User,
                    "system" => MessageRole.System,
                    "tool" => MessageRole.Tool,
                    _ => MessageRole.User,
                },
            }).ToArray(),
            format: options?.ResponseFormat switch
            {
                ChatResponseFormatJson => ResponseFormat.Json,
                _ => null,
            },
            options: new RequestOptions
            {
                Temperature = options?.Temperature,
            },
            stream: false,
            keepAlive: default,
            tools: options?.Tools?.Select(x => new Tool
            {
                Function = new ToolFunction
                {
                    Name = string.Empty,
                    Description = string.Empty,
                    Parameters = x.AsJson(),
                },
            }).ToList(),
            cancellationToken: cancellationToken).WaitAsync().ConfigureAwait(false);
        if (response.Message == null)
        {
            throw new InvalidOperationException("Response message was null.");
        }
        
        return new ChatCompletion(new ChatMessage(
            role: response.Message.Role switch
            {
                MessageRole.Assistant => ChatRole.Assistant,
                MessageRole.User => ChatRole.User,
                MessageRole.System => ChatRole.System,
                MessageRole.Tool => ChatRole.Tool,
                _ => ChatRole.User,
            },
            content: response.Message.Content)
        {
            RawRepresentation = response.Message,
        })
        {
            RawRepresentation = response,
        };
    }

    /// <inheritdoc />
    public IAsyncEnumerable<StreamingChatCompletionUpdate> CompleteStreamingAsync(
        IList<ChatMessage> chatMessages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public TService? GetService<TService>(object? key = null) where TService : class
    {
        return this as TService;
    }

    /// <inheritdoc />
    public ChatClientMetadata Metadata => new(
        providerName: "Ollama",
        providerUri: HttpClient.BaseAddress);
}