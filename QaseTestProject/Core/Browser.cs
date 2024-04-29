using OpenQA.Selenium;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Core;

public class Browser
{
    public IWebDriver Driver { get; }

    public Browser()
    {
        Driver = Configurator.BrowserType?.ToLower() switch
        {
            "chrome" => new DriverFactory().GetChromeDriver(),
            _ => null
        } ?? throw new InvalidOperationException("Browser is not supported.");

        Driver.Manage().Window.Maximize();
        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}