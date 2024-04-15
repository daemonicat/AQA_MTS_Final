using OpenQA.Selenium;
using QaseTestProject.Helpers;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Objects.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; set; }
    protected WaitsHelper WaitsHelper { get; set; }

    public BasePage(IWebDriver driver, bool openPageByUrl = true)
    {
        Driver = driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
    }
}