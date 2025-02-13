using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using QaseTestProject.Models;
using QaseTestProject.Models.Enums;

namespace QaseTestProject.Helpers.Configuration;

public static class Configurator
{
    private static readonly Lazy<IConfiguration> SConfiguration;

    static Configurator()
    {
        SConfiguration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                       throw new InvalidOperationException();
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
            var child = SConfiguration.Value.GetSection("AppSettings");

            appSettings.URL = child["URL"] ?? throw new SettingsException("No URL in appsettings.json");
            appSettings.URI = child["URI"] ?? throw new SettingsException("No URI in appsettings.json");
            appSettings.Token = child["Token"] ?? throw new SettingsException("No Token in appsettings.json");


            return appSettings;
        }
    }

    public static List<User> Users
    {
        get
        {
            var users = new List<User>();
            var child = SConfiguration.Value.GetSection("Users");

            foreach (var section in child.GetChildren())
            {
                var user = new User()
                {
                    Email = section["Username"] ?? throw new SettingsException("No Username in appsettings.json"),
                    Password = section["Password"] ?? throw new SettingsException("No Password in appsettings.json")
                };

                user.UserType = section["UserType"] switch
                {
                    "Default" => UserType.Default,
                    "Broken" => UserType.Broken,
                    _ => user.UserType
                };

                users.Add(user);
            }

            return users;
        }
    }

    public static User DefaultUser =>
        Users.Find(x => x.UserType == UserType.Default) ?? throw new SettingsException("No such user");
    public static User BrokenUser =>
        Users.Find(x => x.UserType == UserType.Broken) ?? throw new SettingsException("No such user");

    public static string? BrowserType => SConfiguration.Value[nameof(BrowserType)];
    public static double WaitsTimeout => double.Parse(SConfiguration.Value[nameof(WaitsTimeout)] ?? "15");
}