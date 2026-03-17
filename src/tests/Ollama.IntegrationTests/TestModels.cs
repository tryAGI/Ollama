namespace Ollama.IntegrationTests;

internal static class TestModels
{
    public static string Chat => Get("OLLAMA_TEST_CHAT_MODEL", "llama3.2:1b");

    public static string Embeddings => Get("OLLAMA_TEST_EMBEDDINGS_MODEL", "all-minilm");

    public static string Reader => Get("OLLAMA_TEST_READER_MODEL", "reader-lm:latest");

    private static string Get(string name, string fallback)
    {
        var value = System.Environment.GetEnvironmentVariable(name);
        return string.IsNullOrWhiteSpace(value) ? fallback : value;
    }
}
