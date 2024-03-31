using Microsoft.Extensions.Configuration;

namespace MoxfieldToMCMWants;

public class Settings
{
    public Settings()
    {
        IConfiguration config = LoadAppSettings();
        // Get values from the config given their key and their target type.
        ChromeDriverPath = config.GetRequiredSection("ChromeDriverDirectory").Get<string>();
    }

    public string? ChromeDriverPath { get; set; }

    private IConfiguration LoadAppSettings()
    {
        // Build a config object, using env vars and JSON providers.
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    }
}
