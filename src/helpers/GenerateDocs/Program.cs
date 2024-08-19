var solutionDirectory = args.ElementAtOrDefault(0) ?? Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../.."));
var sampleDirectory = Path.Combine(solutionDirectory, "src", "tests", "Ollama.IntegrationTests");
var mkDocsPath = Path.Combine(solutionDirectory, "mkdocs.yml");

var newDir = Path.Combine(solutionDirectory, "docs", "samples");
Directory.CreateDirectory(newDir);

File.Copy(
    Path.Combine(solutionDirectory, "README.md"),
    Path.Combine(solutionDirectory, "docs", "index.md"),
    overwrite: true);

Console.WriteLine($"Generating samples from {sampleDirectory}...");
foreach (var path in Directory.EnumerateFiles(sampleDirectory, "Tests.*.cs", SearchOption.AllDirectories))
{
    var code = await File.ReadAllTextAsync(path);

    var start = code.IndexOf("\n    {", StringComparison.Ordinal);
    var end = code.IndexOf("\n    }", StringComparison.Ordinal);
    code = code.Substring(start + 4, end - start + 4);
    
    var lines = code.Split('\n')[1..^2];
    code = string.Join('\n', lines
        .Where(x => !x.Contains(".Should()"))
        .Select(x => x.Length > 8 ? x[8..] : string.Empty));

    code = code
        .Replace(
            "await using var container = await PrepareEnvironmentAsync(EnvironmentType.Container);",
            "using var api = new OllamaApiClient();")
        .Replace(
            "container.ApiClient",
            "api")
        ;
    
    var newPath = Path.Combine(newDir, $"{Path.GetExtension(Path.GetFileNameWithoutExtension(path)).TrimStart('.')}.md");
    await File.WriteAllTextAsync(newPath, $@"```csharp
{code}
```");
}

var mkDocs = await File.ReadAllTextAsync(mkDocsPath);
var newMkDocs = mkDocs.Replace(
    "# EXAMPLES #",
    $"- Examples:{string.Concat(Directory.EnumerateFiles(Path.Combine(solutionDirectory, "docs", "samples"), "*.md")
    .Select(x => $@"
  - {Path.GetFileNameWithoutExtension(x)}: samples/{Path.GetFileNameWithoutExtension(x)}.md"))}");
await File.WriteAllTextAsync(mkDocsPath, newMkDocs);

