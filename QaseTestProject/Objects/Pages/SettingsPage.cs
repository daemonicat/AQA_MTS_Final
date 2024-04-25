using OpenQA.Selenium;
using QaseTestProject.Elements;

namespace QaseTestProject.Objects.Pages;

public class SettingsPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By TitleLabelBy = By.XPath("//h1[text()='Project settings']");
    private static readonly By DeleteProjectButtonBy = By.XPath("//span[text()=' Delete project']");
    private static readonly By DeleteProjectFinalButtonBy =
        By.XPath("//div[@id='modals']//span[text()='Delete project']/..");

    private IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    private Button DeleteProjectButton => new(Driver, DeleteProjectButtonBy);
    private Button DeleteProjectFinalButton => new(Driver, DeleteProjectFinalButtonBy);

    public override bool IsPageOpened()
    {
        return TitleLabel.Text.Trim().Equals("Projects");
    }

    public SettingsPage ClickDeleteProjectButton()
    {
        DeleteProjectButton.Click();
        return this;
    }

    public SettingsPage ClickDeleteProjectFinalButton()
    {
        DeleteProjectFinalButton.Click();
        return this;
    }
}