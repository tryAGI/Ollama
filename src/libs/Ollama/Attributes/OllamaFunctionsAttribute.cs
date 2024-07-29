// ReSharper disable once CheckNamespace
namespace Ollama;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Interface)]
[System.Diagnostics.Conditional("OLLAMA_FUNCTIONS_ATTRIBUTES")]
public sealed class OllamaFunctionsAttribute : Attribute;