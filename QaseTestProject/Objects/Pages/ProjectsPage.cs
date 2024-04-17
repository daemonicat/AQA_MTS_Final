using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class ProjectsPage : BasePage
{
    private static readonly By CreateNewProjectButtonBy = By.Id("createButton");
    private static readonly By RemoveProjectButtonBy = By.CssSelector("button.EehRY_.Wy99v3.fwhtHZ");
    private static readonly By DeleteProjectButtonBy = By.CssSelector("button.G1dmaA.X8bxUI.IAcAWv");

    public ProjectsPage(IWebDriver driver, bool openPageByUrl = true) : base(driver)
    {
    }

    public IWebElement CreateNewProjectButton => WaitsHelper.WaitForExists(CreateNewProjectButtonBy);
    public IWebElement RemoveProjectButton => WaitsHelper.WaitForExists(RemoveProjectButtonBy);
    public IWebElement DeleteProjectButton => WaitsHelper.WaitForExists(DeleteProjectButtonBy);
    
    public override bool IsPageOpened() => CreateNewProjectButton.Displayed;
    
    public void ClickCreateNewProjectButton() => CreateNewProjectButton.Click();
    public void ClickRemoveProjectButton() => RemoveProjectButton.Click();
    public void ClickDeleteProjectButton() => DeleteProjectButton.Click();
}