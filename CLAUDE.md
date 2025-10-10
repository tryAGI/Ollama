# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a fully generated C# SDK for the Ollama API, built using OpenAPI specifications. The core library targets multiple frameworks (netstandard2.0, net4.6.2, net8.0, net9.0) and emphasizes modern .NET features including nullability, trimming, and NativeAOT support.

## Build and Test Commands

### Building
```bash
dotnet build Ollama.sln
```

### Running Tests
```bash
# Run all tests
dotnet test Ollama.sln

# Run tests with GitHub Actions logger
dotnet test Ollama.sln --logger GitHubActions

# Run a single test
dotnet test --filter "FullyQualifiedName~Tests.Tools"
```

The integration tests are located in `src/tests/Ollama.IntegrationTests` and use MSTest with Testcontainers to spin up Ollama instances.

## Code Generation

**CRITICAL**: The `Generated/` directory (151 files) is auto-generated and should NEVER be manually edited. All generated code is created using the `autosdk.cli` tool based on the OpenAPI specification.

### Regenerating Code
```bash
cd src/libs/Ollama
./generate.sh
```

This script:
1. Downloads the latest OpenAPI spec from langchain_dart repository
2. Runs `FixOpenApiSpec` helper to preprocess the spec
3. Generates C# code using `autosdk generate` command

## Architecture

### Generated vs Manual Code

**Generated Code** (`src/libs/Ollama/Generated/`):
- `OllamaApiClient.g.cs` - Main client with endpoint clients as properties
- Endpoint clients: `CompletionsClient`, `ChatClient`, `EmbeddingsClient`, `ModelsClient`
- All API models, enums, converters, and serialization contexts
- Generated from `openapi.yaml` using AutoSDK

**Manual Code** (files at root of `src/libs/Ollama/`):
- `Chat.cs` - High-level chat abstraction with conversation history and tool calling
- `OllamaApiClientExtensions.cs` - Extension methods for improved ergonomics:
  - `Chat()` - Creates a new Chat instance
  - `WaitAsync()` - Combines streaming responses into single responses
  - `EnsureSuccessAsync()` - Ensures model pull operations succeed
- `Message.cs` - Partial class adding implicit string-to-Message conversion
- `Extensions/StringExtensions.cs` - Helper methods for creating messages and converting tools:
  - `AsUserMessage()`, `AsSystemMessage()`, `AsToolMessage()`, `AsAssistantMessage()`
  - `AsOllamaTools()` - Converts CSharpToJsonSchema tools to Ollama format
  - `AsJson()` - Serializes objects using source-generated context

### Client Structure

The `OllamaApiClient` exposes endpoint clients as properties:
- `client.Completions` - For completion generation
- `client.Chat` - For chat completions
- `client.Embeddings` - For embeddings
- `client.Models` - For model management (list, pull, push, delete, etc.)

### Streaming and Extension Methods

Key pattern: Most API methods return `IAsyncEnumerable<T>` for streaming. Extension methods in `OllamaApiClientExtensions.cs` provide:
- `WaitAsync()` methods that aggregate streams into single responses
- `GetAwaiter()` methods enabling direct `await` on enumerables
- This allows both streaming (`await foreach`) and non-streaming (`await`) usage

### Chat Abstraction

The `Chat` class provides:
- Conversation history management
- Automatic tool calling when `AutoCallTools = true`
- Tool registration via `AddToolService()`
- Simplified API via `SendAsync()`

### Tools Integration

Uses `CSharpToJsonSchema` for defining tools through C# interfaces:
1. Define interface with `[GenerateJsonSchema]` attribute
2. Use `[Description]` attributes for function/parameter descriptions
3. Convert using `service.AsTools().AsOllamaTools()`
4. Register calls using `service.AsCalls()`

See `src/tests/Ollama.IntegrationTests/WeatherTools.cs` for complete example.

## Helper Projects

- `src/helpers/FixOpenApiSpec/` - Preprocesses OpenAPI spec before generation
- `src/helpers/GenerateDocs/` - Documentation generation utility
- `src/helpers/TrimmingHelper/` - Tests trimming/NativeAOT compatibility

## Key Files

- `src/libs/Ollama/openapi.yaml` - OpenAPI specification source
- `src/libs/Ollama/generate.sh` - Code generation script
- `src/libs/Ollama/Ollama.csproj` - Main library project with multi-targeting
- `src/Directory.Build.props` - Shared build configuration

## Dependencies

Key runtime dependencies:
- `System.Text.Json` (9.0.8) - JSON serialization
- `CSharpToJsonSchema` (3.10.1) - Tool definition source generator
- `PolySharp` (1.15.0) - Polyfills for older frameworks

Test dependencies:
- MSTest for test framework
- Testcontainers for integration tests
- AwesomeAssertions for fluent assertions
