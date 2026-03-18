using Meai = Microsoft.Extensions.AI;

namespace Ollama;

public partial class OllamaClient : Meai.IEmbeddingGenerator<string, Meai.Embedding<float>>
{
    private Meai.EmbeddingGeneratorMetadata? _embeddingMetadata;

    object? Meai.IEmbeddingGenerator.GetService(Type serviceType, object? serviceKey)
    {
        ArgumentNullException.ThrowIfNull(serviceType);

        return
            serviceKey is not null ? null :
            serviceType == typeof(Meai.EmbeddingGeneratorMetadata) ? (_embeddingMetadata ??= new(nameof(OllamaClient), BaseUri)) :
            serviceType.IsInstanceOfType(this) ? this :
            null;
    }

    async Task<Meai.GeneratedEmbeddings<Meai.Embedding<float>>> Meai.IEmbeddingGenerator<string, Meai.Embedding<float>>.GenerateAsync(
        IEnumerable<string> values,
        Meai.EmbeddingGenerationOptions? options,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(values);

        var inputList = values.ToList();

        var request = new EmbedRequest
        {
            Model = options?.ModelId ?? string.Empty,
            Input = inputList.Count == 1
                ? new OneOf<string, IList<string>>(inputList[0])
                : new OneOf<string, IList<string>>(inputList),
        };

        if (options?.Dimensions is { } dimensions)
        {
            request.Dimensions = dimensions;
        }

        var response = await EmbedAsync(request, cancellationToken).ConfigureAwait(false);

        var embeddings = new Meai.GeneratedEmbeddings<Meai.Embedding<float>>();

        if (response.Embeddings is { } embeddingsList)
        {
            foreach (var embedding in embeddingsList)
            {
                var vector = new float[embedding.Count];
                for (var i = 0; i < embedding.Count; i++)
                {
                    vector[i] = (float)embedding[i];
                }

                embeddings.Add(new Meai.Embedding<float>(vector)
                {
                    ModelId = response.Model,
                });
            }
        }

        if (response.PromptEvalCount is not null)
        {
            embeddings.Usage = new Meai.UsageDetails
            {
                InputTokenCount = response.PromptEvalCount,
                TotalTokenCount = response.PromptEvalCount,
            };
        }

        return embeddings;
    }
}
