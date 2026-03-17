using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Meai = Microsoft.Extensions.AI;

namespace Ollama;

public partial class OllamaClient : Meai.IChatClient
{
    private Meai.ChatClientMetadata? _metadata;

    object? Meai.IChatClient.GetService(Type serviceType, object? serviceKey)
    {
        ArgumentNullException.ThrowIfNull(serviceType);

        return
            serviceKey is not null ? null :
            serviceType == typeof(Meai.ChatClientMetadata) ? (_metadata ??= new(nameof(OllamaClient), BaseUri)) :
            serviceType.IsInstanceOfType(this) ? this :
            null;
    }

    async Task<Meai.ChatResponse> Meai.IChatClient.GetResponseAsync(
        IEnumerable<Meai.ChatMessage> messages,
        Meai.ChatOptions? options,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(messages);

        var response = await ChatAsync(
            CreateRequest(messages, options),
            cancellationToken).ConfigureAwait(false);

        return CreateChatResponse(response);
    }

    async IAsyncEnumerable<Meai.ChatResponseUpdate> Meai.IChatClient.GetStreamingResponseAsync(
        IEnumerable<Meai.ChatMessage> messages,
        Meai.ChatOptions? options,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(messages);

        var responseId = $"ollama-{Guid.NewGuid():N}";
        var messageId = $"{responseId}-message";

        await foreach (var update in ChatAsStreamAsync(
                           CreateRequest(messages, options),
                           cancellationToken).ConfigureAwait(false))
        {
            var responseUpdate = new Meai.ChatResponseUpdate
            {
                Role = ToChatRole(update.Message?.Role),
                ResponseId = responseId,
                MessageId = messageId,
                ModelId = update.Model,
                CreatedAt = update.CreatedAt,
                RawRepresentation = update,
                AdditionalProperties = CreateAdditionalPropertiesDictionary(CreateResponseUpdateAdditionalProperties(update)),
            };

            AddContents(responseUpdate.Contents, update.Message, responseId);

            var usage = CreateUsageDetails(update);
            if (usage is not null)
            {
                responseUpdate.Contents.Add(new Meai.UsageContent(usage)
                {
                    RawRepresentation = update,
                });
            }

            if (update.Done == true)
            {
                responseUpdate.FinishReason = ToFinishReason(GetString(update.AdditionalProperties, "done_reason"));
            }

            yield return responseUpdate;
        }
    }

    private ChatRequest CreateRequest(IEnumerable<Meai.ChatMessage> messages, Meai.ChatOptions? options)
    {
        List<ChatMessage> requestMessages = [];
        if (!string.IsNullOrWhiteSpace(options?.Instructions))
        {
            requestMessages.Add(new ChatMessage
            {
                Role = ChatMessageRole.System,
                Content = options.Instructions!,
            });
        }

        foreach (var message in messages)
        {
            requestMessages.Add(ToOllamaMessage(message));
        }

        ChatRequest? request = options?.RawRepresentationFactory?.Invoke(this) as ChatRequest;
        if (request is null)
        {
            request = new ChatRequest
            {
                Model = options?.ModelId ?? string.Empty,
                Messages = requestMessages,
            };
        }
        else
        {
            request.Model = options?.ModelId ?? request.Model ?? string.Empty;
            request.Messages ??= [];
            foreach (var message in requestMessages)
            {
                request.Messages.Add(message);
            }
        }

        ApplyOptions(request, options);
        return request;
    }

    private static ChatMessage ToOllamaMessage(Meai.ChatMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        List<string>? images = null;
        List<ToolCall>? toolCalls = null;
        StringBuilder content = new();

        foreach (var item in message.Contents)
        {
            switch (item)
            {
                case Meai.TextContent textContent:
                    content.Append(textContent.Text);
                    break;

                case Meai.FunctionResultContent functionResult:
                    AppendContent(content, ToToolResultText(functionResult));
                    break;

                case Meai.FunctionCallContent functionCall:
                    (toolCalls ??= []).Add(new ToolCall
                    {
                        Function = new ToolCallFunction
                        {
                            Name = functionCall.Name,
                            Arguments = functionCall.Arguments,
                        },
                    });
                    break;

                case Meai.DataContent dataContent when dataContent.HasTopLevelMediaType("image"):
                    (images ??= []).Add(ToBase64(dataContent));
                    break;

                case Meai.UriContent uriContent when uriContent.HasTopLevelMediaType("image"):
                    throw new NotSupportedException(
                        "Ollama only supports inline image content. Use DataContent for images instead of UriContent.");

                case Meai.TextReasoningContent:
                case Meai.UsageContent:
                    break;

                default:
                    throw new NotSupportedException(
                        $"Content type '{item.GetType().Name}' is not supported by the Ollama chat adapter.");
            }
        }

        return new ChatMessage
        {
            Role = ToOllamaRole(message.Role),
            Content = content.ToString(),
            Images = images,
            ToolCalls = toolCalls,
            AdditionalProperties = CopyInputAdditionalProperties(message.AdditionalProperties) ?? new Dictionary<string, object>(),
        };
    }

    private static void ApplyOptions(ChatRequest request, Meai.ChatOptions? options)
    {
        if (options is null)
        {
            return;
        }

        if (request.Format is null && options.ResponseFormat is not null)
        {
            request.Format = ToOllamaFormat(options.ResponseFormat);
        }

        if (request.Think is null && options.Reasoning is not null)
        {
            request.Think = ToThinkingMode(options.Reasoning);
        }

        if (NeedsModelOptions(options))
        {
            request.Options ??= new ModelOptions();
            request.Options.Temperature ??= options.Temperature;
            request.Options.TopP ??= options.TopP;
            request.Options.TopK ??= options.TopK;
            request.Options.Seed ??= ToInt32(options.Seed, nameof(options.Seed));
            request.Options.NumPredict ??= ToInt32(options.MaxOutputTokens, nameof(options.MaxOutputTokens));

            if (request.Options.Stop is null && options.StopSequences is { Count: > 0 } stopSequences)
            {
                request.Options.Stop = stopSequences.Count == 1 ? stopSequences[0] : stopSequences.ToList();
            }
        }

        ApplyTools(request, options);
    }

    private static void ApplyTools(ChatRequest request, Meai.ChatOptions options)
    {
        if (options.ToolMode is Meai.NoneChatToolMode)
        {
            request.Tools = null;
            return;
        }

        if (options.Tools is { Count: > 0 } aiTools)
        {
            request.Tools ??= [];
            foreach (var tool in aiTools)
            {
                request.Tools.Add(CreateTool(tool));
            }
        }

        if (options.ToolMode is not Meai.RequiredChatToolMode requiredToolMode)
        {
            return;
        }

        if (request.Tools is not { Count: > 0 })
        {
            throw new InvalidOperationException("ChatToolMode.Required requires at least one function tool.");
        }

        if (!string.IsNullOrWhiteSpace(requiredToolMode.RequiredFunctionName))
        {
            var requiredTools = request.Tools
                .Where(t => string.Equals(
                    t.Function.Name,
                    requiredToolMode.RequiredFunctionName,
                    StringComparison.Ordinal))
                .ToList();

            if (requiredTools.Count == 0)
            {
                throw new InvalidOperationException(
                    $"Required tool '{requiredToolMode.RequiredFunctionName}' was not supplied.");
            }

            request.Tools = requiredTools;
        }
    }

    private static ToolDefinition CreateTool(Meai.AITool tool)
    {
        if (tool is not Meai.AIFunction function)
        {
            throw new NotSupportedException(
                $"Tool type '{tool.GetType().Name}' is not supported by Ollama. Only function tools are supported.");
        }

        object parameters =
            function.JsonSchema.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined
                ? new ToolDefinitionFunctionParameters()
                : function.JsonSchema;

        return new ToolDefinition
        {
            Type = ToolDefinitionType.Function,
            Function = new ToolDefinitionFunction
            {
                Name = function.Name,
                Description = function.Description,
                Parameters = parameters,
            },
        };
    }

    private static OneOf<ChatRequestFormatEnum?, object>? ToOllamaFormat(Meai.ChatResponseFormat responseFormat)
    {
        return responseFormat switch
        {
            Meai.ChatResponseFormatJson { Schema: JsonElement schema }
                when schema.ValueKind is not JsonValueKind.Null and not JsonValueKind.Undefined => schema,
            Meai.ChatResponseFormatJson => ChatRequestFormatEnum.Json,
            _ => null,
        };
    }

    private static OneOf<bool?, ChatRequestThink?>? ToThinkingMode(Meai.ReasoningOptions reasoning)
    {
        if (reasoning.Output == Meai.ReasoningOutput.None)
        {
            return false;
        }

        return reasoning.Effort switch
        {
            Meai.ReasoningEffort.Low => ChatRequestThink.Low,
            Meai.ReasoningEffort.Medium => ChatRequestThink.Medium,
            Meai.ReasoningEffort.High or Meai.ReasoningEffort.ExtraHigh => ChatRequestThink.High,
            _ => true,
        };
    }

    private static bool NeedsModelOptions(Meai.ChatOptions options) =>
        options.Temperature is not null ||
        options.TopP is not null ||
        options.TopK is not null ||
        options.Seed is not null ||
        options.MaxOutputTokens is not null ||
        options.StopSequences is { Count: > 0 };

    private static Meai.ChatResponse CreateChatResponse(ChatResponse response)
    {
        var message = CreateChatMessage(response.Message);
        var completion = new Meai.ChatResponse(message)
        {
            ModelId = response.Model,
            CreatedAt = response.CreatedAt,
            FinishReason = ToFinishReason(response.DoneReason),
            Usage = CreateUsageDetails(response),
            RawRepresentation = response,
            AdditionalProperties = CreateAdditionalPropertiesDictionary(CreateResponseAdditionalProperties(response)),
        };

        return completion;
    }

    private static Meai.ChatMessage CreateChatMessage(ChatResponseMessage? message)
    {
        var chatMessage = new Meai.ChatMessage
        {
            Role = ToChatRole(message?.Role),
            CreatedAt = null,
            RawRepresentation = message,
            AdditionalProperties = CreateAdditionalPropertiesDictionary(CopyOutputAdditionalProperties(message?.AdditionalProperties)),
        };

        AddContents(chatMessage.Contents, message, "ollama");
        return chatMessage;
    }

    private static void AddContents(IList<Meai.AIContent> contents, ChatResponseMessage? message, string callIdPrefix)
    {
        if (message is null)
        {
            return;
        }

        if (!string.IsNullOrWhiteSpace(message.Content))
        {
            contents.Add(new Meai.TextContent(message.Content)
            {
                RawRepresentation = message,
            });
        }

        if (!string.IsNullOrWhiteSpace(message.Thinking))
        {
            contents.Add(new Meai.TextReasoningContent(message.Thinking)
            {
                RawRepresentation = message,
            });
        }

        if (message.Images is { Count: > 0 } images)
        {
            foreach (var image in images)
            {
                contents.Add(new Meai.DataContent(Convert.FromBase64String(image), "image/*")
                {
                    RawRepresentation = message,
                });
            }
        }

        if (message.ToolCalls is { Count: > 0 } toolCalls)
        {
            for (var i = 0; i < toolCalls.Count; i++)
            {
                var toolCall = toolCalls[i];
                contents.Add(new Meai.FunctionCallContent(
                    callId: $"{callIdPrefix}-tool-{i}",
                    name: toolCall.Function?.Name ?? string.Empty,
                    arguments: ToArgumentsDictionary(toolCall.Function?.Arguments))
                {
                    RawRepresentation = toolCall,
                });
            }
        }
    }

    private static void AddContents(IList<Meai.AIContent> contents, ChatStreamEventMessage? message, string callIdPrefix)
    {
        if (message is null)
        {
            return;
        }

        if (!string.IsNullOrWhiteSpace(message.Content))
        {
            contents.Add(new Meai.TextContent(message.Content)
            {
                RawRepresentation = message,
            });
        }

        if (!string.IsNullOrWhiteSpace(message.Thinking))
        {
            contents.Add(new Meai.TextReasoningContent(message.Thinking)
            {
                RawRepresentation = message,
            });
        }

        if (message.Images is { Count: > 0 } images)
        {
            foreach (var image in images)
            {
                contents.Add(new Meai.DataContent(Convert.FromBase64String(image), "image/*")
                {
                    RawRepresentation = message,
                });
            }
        }

        if (message.ToolCalls is { Count: > 0 } toolCalls)
        {
            for (var i = 0; i < toolCalls.Count; i++)
            {
                var toolCall = toolCalls[i];
                contents.Add(new Meai.FunctionCallContent(
                    callId: $"{callIdPrefix}-tool-{i}",
                    name: toolCall.Function?.Name ?? string.Empty,
                    arguments: ToArgumentsDictionary(toolCall.Function?.Arguments))
                {
                    RawRepresentation = toolCall,
                });
            }
        }
    }

    private static Meai.ChatRole ToChatRole(ChatResponseMessageRole? role) =>
        role == ChatResponseMessageRole.Assistant ? Meai.ChatRole.Assistant : Meai.ChatRole.Assistant;

    private static Meai.ChatRole ToChatRole(string? role) =>
        role switch
        {
            "assistant" => Meai.ChatRole.Assistant,
            "system" => Meai.ChatRole.System,
            "tool" => Meai.ChatRole.Tool,
            _ => Meai.ChatRole.User,
        };

    private static ChatMessageRole ToOllamaRole(Meai.ChatRole role) =>
        role.Value switch
        {
            "assistant" => ChatMessageRole.Assistant,
            "system" => ChatMessageRole.System,
            "tool" => ChatMessageRole.Tool,
            "developer" => ChatMessageRole.System,
            _ => ChatMessageRole.User,
        };

    private static Meai.ChatFinishReason? ToFinishReason(string? doneReason) =>
        doneReason switch
        {
            null or "" => null,
            "stop" => Meai.ChatFinishReason.Stop,
            "length" => Meai.ChatFinishReason.Length,
            "tool_calls" => Meai.ChatFinishReason.ToolCalls,
            "content_filter" => Meai.ChatFinishReason.ContentFilter,
            _ => new Meai.ChatFinishReason(doneReason),
        };

    private static Meai.UsageDetails? CreateUsageDetails(ChatResponse response)
    {
        if (response.PromptEvalCount is null && response.EvalCount is null)
        {
            return null;
        }

        return new Meai.UsageDetails
        {
            InputTokenCount = response.PromptEvalCount,
            OutputTokenCount = response.EvalCount,
            TotalTokenCount =
                response.PromptEvalCount is int inputTokens && response.EvalCount is int outputTokens
                    ? inputTokens + outputTokens
                    : null,
        };
    }

    private static Meai.UsageDetails? CreateUsageDetails(ChatStreamEvent response)
    {
        var inputTokenCount = GetInt(response.AdditionalProperties, "prompt_eval_count");
        var outputTokenCount = GetInt(response.AdditionalProperties, "eval_count");
        if (inputTokenCount is null && outputTokenCount is null)
        {
            return null;
        }

        return new Meai.UsageDetails
        {
            InputTokenCount = inputTokenCount,
            OutputTokenCount = outputTokenCount,
            TotalTokenCount =
                inputTokenCount is int inputTokens && outputTokenCount is int outputTokens
                    ? inputTokens + outputTokens
                    : null,
        };
    }

    private static Dictionary<string, object?>? CreateResponseAdditionalProperties(ChatResponse response)
    {
        var properties = CopyOutputAdditionalProperties(response.AdditionalProperties) ?? [];
        AddIfNotNull(properties, "done", response.Done);
        AddIfNotNull(properties, "done_reason", response.DoneReason);
        AddIfNotNull(properties, "total_duration", response.TotalDuration);
        AddIfNotNull(properties, "load_duration", response.LoadDuration);
        AddIfNotNull(properties, "prompt_eval_duration", response.PromptEvalDuration);
        AddIfNotNull(properties, "eval_duration", response.EvalDuration);
        AddIfNotNull(properties, "logprobs", response.Logprobs);
        return properties.Count > 0 ? properties : null;
    }

    private static Dictionary<string, object?>? CreateResponseUpdateAdditionalProperties(ChatStreamEvent response)
    {
        var properties = CopyOutputAdditionalProperties(response.AdditionalProperties) ?? [];
        AddIfNotNull(properties, "done", response.Done);
        return properties.Count > 0 ? properties : null;
    }

    private static Dictionary<string, object>? CopyInputAdditionalProperties(IEnumerable<KeyValuePair<string, object?>>? additionalProperties)
    {
        if (additionalProperties is null)
        {
            return null;
        }

        var copy = new Dictionary<string, object>(StringComparer.Ordinal);
        foreach (var pair in additionalProperties)
        {
            copy[pair.Key] = pair.Value!;
        }

        return copy.Count > 0 ? copy : null;
    }

    private static Dictionary<string, object?>? CopyOutputAdditionalProperties(IEnumerable<KeyValuePair<string, object>>? additionalProperties)
    {
        if (additionalProperties is null)
        {
            return null;
        }

        var copy = new Dictionary<string, object?>(StringComparer.Ordinal);
        foreach (var pair in additionalProperties)
        {
            copy[pair.Key] = pair.Value;
        }

        return copy.Count > 0 ? copy : null;
    }

    private static Dictionary<string, object?>? ToArgumentsDictionary(object? arguments)
    {
        return arguments switch
        {
            null => null,
            JsonElement jsonElement when jsonElement.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonElement jsonElement when jsonElement.ValueKind == JsonValueKind.Object => ConvertToDictionary(jsonElement),
            IDictionary<string, object?> dictionary => new Dictionary<string, object?>(dictionary, StringComparer.Ordinal),
            _ => ConvertToDictionary(JsonSerializer.SerializeToElement(arguments, SourceGenerationContext.Default.Object)),
        };
    }

    private static string ToBase64(Meai.DataContent content)
    {
        if (content.Data is { } data)
        {
            return Convert.ToBase64String(data.ToArray());
        }

        throw new NotSupportedException("Ollama requires image content to be provided as in-memory data.");
    }

    private static string ToToolResultText(Meai.FunctionResultContent functionResult)
    {
        if (functionResult.Result is JsonElement jsonElement)
        {
            return jsonElement.ValueKind == JsonValueKind.String
                ? jsonElement.GetString() ?? string.Empty
                : jsonElement.GetRawText();
        }

        if (functionResult.Result is string text)
        {
            return text;
        }

        if (functionResult.Result is not null)
        {
            return JsonSerializer.Serialize(functionResult.Result, SourceGenerationContext.Default.Object);
        }

        return functionResult.Exception?.Message ?? string.Empty;
    }

    private static void AppendContent(StringBuilder builder, string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        if (builder.Length > 0)
        {
            builder.AppendLine();
        }

        builder.Append(text);
    }

    private static void AddIfNotNull(Dictionary<string, object?> properties, string name, object? value)
    {
        if (value is not null)
        {
            properties[name] = value;
        }
    }

    private static Meai.AdditionalPropertiesDictionary? CreateAdditionalPropertiesDictionary(
        Dictionary<string, object?>? properties) =>
        properties is { Count: > 0 }
            ? new Meai.AdditionalPropertiesDictionary(properties)
            : null;

    private static int? ToInt32(long? value, string parameterName)
    {
        if (value is null)
        {
            return null;
        }

        if (value < int.MinValue || value > int.MaxValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, value, "The value must fit into a 32-bit integer.");
        }

        return (int)value.Value;
    }

    private static Dictionary<string, object?> ConvertToDictionary(JsonElement element)
    {
        var dictionary = new Dictionary<string, object?>(StringComparer.Ordinal);
        foreach (var property in element.EnumerateObject())
        {
            dictionary[property.Name] = ConvertJsonValue(property.Value);
        }

        return dictionary;
    }

    private static object? ConvertJsonValue(JsonElement value)
    {
        return value.ValueKind switch
        {
            JsonValueKind.Object => ConvertToDictionary(value),
            JsonValueKind.Array => value.EnumerateArray().Select(ConvertJsonValue).ToList(),
            JsonValueKind.String => value.GetString(),
            JsonValueKind.Number when value.TryGetInt64(out var int64Value) => int64Value,
            JsonValueKind.Number when value.TryGetDouble(out var doubleValue) => doubleValue,
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            _ => value.ToString(),
        };
    }

    private static string? GetString(IDictionary<string, object>? additionalProperties, string name)
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

    private static int? GetInt(IDictionary<string, object>? additionalProperties, string name)
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
