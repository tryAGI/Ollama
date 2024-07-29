using System.Runtime.CompilerServices;

namespace Ollama.SnapshotTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifySourceGenerators.Initialize();
    }
}