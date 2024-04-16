using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class ProjectPage : BasePage
{
    private static readonly By CreateNewCaseButtonBy = By.Id("create-case-button");

    public ProjectPage(IWebDriver driver) : base(driver)
    {
    }

    public IWebElement CreateNewCaseButton => WaitsHelper.WaitForExists(CreateNewCaseButtonBy);

    public override bool IsPageOpened()
    {
        return CreateNewCaseButton.Displayed;
    }
}