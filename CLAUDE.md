# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a fully generated C# SDK for the Ollama API, built using OpenAPI specifications. The core library targets multiple frameworks (netstandard2.0, net4.6.2, net8.0, net9.0) and emphasizes modern .NET features including nullability, trimming, and NativeAOT support.

## Build and Test Commands

### Building
```bash
dotnet build Ollama.slnx
```

### Running Tests
```bash
# Run all tests
dotnet test Ollama.slnx

# Run tests with GitHub Actions logger
dotnet test Ollama.slnx --logger GitHubActions

# Run a single test
dotnet test --filter "FullyQualifiedName~Tests.Tools"
```

The integration tests are located in `src/tests/Ollama.IntegrationTests` and use MSTest with Testcontainers to spin up Ollama instances.

## Code Generation

**CRITICAL**: The `Generated/` directory is auto-generated and should NEVER be manually edited. All generated code is created using the `autosdk.cli` tool based on the OpenAPI specification.

### Regenerating Code
```bash
cd src/libs/Ollama
./generate.sh
```

This script:
1. Downloads the latest official OpenAPI spec from the Ollama repository
2. Writes it to `src/libs/Ollama/openapi.yaml`
3. Generates C# code using `autosdk generate`

## Architecture

### Generated vs Manual Code

**Generated Code** (`src/libs/Ollama/Generated/`):
- `OllamaApiClient.g.cs` - Main client
- Flat endpoint methods such as `GenerateAsync()`, `GenerateAsStreamAsync()`, `ChatAsync()`, `ChatAsStreamAsync()`, `PullAsync()`, `PullAsStreamAsync()`, `EmbedAsync()`, and `ListAsync()`
- All API models, enums, converters, and serialization contexts
- Generated from `openapi.yaml` using AutoSDK

**Manual Code** (files at root of `src/libs/Ollama/`):
- `Chat.cs` - High-level chat abstraction with conversation history and tool calling
- `OllamaApiClientExtensions.cs` - Extension methods for improved ergonomics:
  - `Chat()` - Creates a new Chat instance
  - `WaitAsync()` - Combines streaming responses into single responses
  - `EnsureSuccessAsync()` - Ensures streamed model operations succeed
- `ChatMessage.cs` - Partial class adding implicit string-to-`ChatMessage` conversion
- `Extensions/StringExtensions.cs` - Helper methods for creating messages and converting tools:
  - `AsUserMessage()`, `AsSystemMessage()`, `AsToolMessage()`, `AsAssistantMessage()`
  - `AsOllamaTools()` - Converts CSharpToJsonSchema tools to Ollama format
  - `AsJson()` - Serializes objects using source-generated context

### Client Structure

The `OllamaApiClient` exposes a flat method surface generated directly from the official Ollama spec:
- `client.GenerateAsync()` / `client.GenerateAsStreamAsync()`
- `client.ChatAsync()` / `client.ChatAsStreamAsync()`
- `client.PullAsync()` / `client.PullAsStreamAsync()`
- `client.EmbedAsync()`, `client.ListAsync()`, `client.ShowAsync()`, `client.PsAsync()`, and other model-management methods

### Streaming and Extension Methods

Key pattern: operations that support both JSON and NDJSON have two generated methods. Extension methods in `OllamaApiClientExtensions.cs` provide:
- `WaitAsync()` methods that aggregate NDJSON streams into single responses
- `GetAwaiter()` methods enabling direct `await` on streamed enumerables
- `EnsureSuccessAsync()` for streamed pull/create/push status events

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
