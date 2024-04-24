using OpenQA.Selenium;
using QaseTestProject.Helpers;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Objects.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; }
    protected WaitsHelper WaitsHelper { get; }

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
    }

    public abstract bool IsPageOpened();
}