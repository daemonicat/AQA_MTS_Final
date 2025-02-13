using NLog;
using OpenQA.Selenium;

namespace QaseTestProject.Objects.Steps;

public class BaseSteps(IWebDriver driver)
{
    protected readonly IWebDriver Driver = driver;
    protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
}