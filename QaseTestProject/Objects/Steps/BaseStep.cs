using OpenQA.Selenium;

namespace QaseTestProject.Objects.Steps;

public class BaseStep(IWebDriver driver)
{
    protected readonly IWebDriver Driver = driver;
}