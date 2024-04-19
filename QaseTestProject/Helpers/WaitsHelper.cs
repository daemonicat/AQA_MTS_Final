using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QaseTestProject.Helpers;

public class WaitsHelper(IWebDriver driver, TimeSpan timeout)
{
    private readonly WebDriverWait _wait = new(driver, timeout);

    public IWebElement WaitForVisibilityLocatedBy(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public IWebElement WaitForExists(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementExists(locator));
    }
}