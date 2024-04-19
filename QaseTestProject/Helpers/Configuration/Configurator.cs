using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace QaseTestProject.Helpers.Configuration;

public static class Configurator
{
    private static readonly Lazy<IConfiguration> s_configuration;

    static Configurator()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException();
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");

        var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

        foreach (var appSettingFile in appSettingFiles)
        {
            builder.AddJsonFile(appSettingFile);
        }

        return builder.Build();
    }

    public static AppSettings AppSettings
    {
        get
        {
            var appSettings = new AppSettings();
            var child = s_configuration.Value.GetSection("AppSettings");

            appSettings.URL = child["URL"] ?? throw new SettingsException("No URL in appsettings.json");
            appSettings.Username = child["Username"] ?? throw new SettingsException("No Username in appsettings.json");
            appSettings.Password = child["Password"] ?? throw new SettingsException("No Password in appsettings.json");

            return appSettings;
        }
    }

    public static string? BrowserType => s_configuration.Value[nameof(BrowserType)];
    public static double WaitsTimeout => double.Parse(s_configuration.Value[nameof(WaitsTimeout)] ?? "120");
}