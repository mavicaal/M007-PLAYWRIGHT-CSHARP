using Microsoft.Extensions.Configuration;

namespace PlaywrightTests.Config;

public class ConfigurationManager
{
    private readonly IConfiguration _configuration;

    public PlaywrightSettings PlaywrightSettings { get; }
    public ApplicationSettings ApplicationSettings { get; }

    public ConfigurationManager()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        PlaywrightSettings = _configuration.GetSection("Playwright").Get<PlaywrightSettings>() 
            ?? new PlaywrightSettings();
        ApplicationSettings = _configuration.GetSection("Application").Get<ApplicationSettings>() 
            ?? new ApplicationSettings();
    }

    public T GetSection<T>(string sectionName) where T : new()
    {
        return _configuration.GetSection(sectionName).Get<T>() ?? new T();
    }
}
