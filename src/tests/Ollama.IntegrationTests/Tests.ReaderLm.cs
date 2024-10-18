namespace Ollama.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task ReaderLm()
    {
#if DEBUG
        await using var container = await Environment.PrepareAsync(EnvironmentType.Local, "reader-lm:latest");
#else
        await using var container = await Environment.PrepareAsync(EnvironmentType.Container, "reader-lm:latest");
#endif

        var enumerable = container.ApiClient.Completions.GenerateCompletionAsync(
            "reader-lm:latest", 
            """
            <html>
              <body>
                <h3>Why is the sky blue?</h3>
                <p>The sky appears blue because of the way light from the sun is reflected by the atmosphere. The atmosphere is made up of gases, including nitrogen and oxygen, which scatter light in all directions. This scattering causes the sunlight to appear as a rainbow of colors, with red light scattered more than other colors.
                </p>
              </body>
            </html>
            """);
        await foreach (var response in enumerable)
        {
            Console.Write(response.Response);
        }
        
        // ### Why is the sky blue?
        // 
        // The sky appears blue because of the way light from the sun is reflected by the atmosphere. The atmosphere is made up of gases, including nitrogen and oxygen, which scatter light in all directions. This scattering causes the sunlight to appear as a rainbow of colors, with red light scattered more than other colors.
    }
}