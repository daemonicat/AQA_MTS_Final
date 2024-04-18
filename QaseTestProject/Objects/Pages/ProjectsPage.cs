using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class ProjectsPage : BasePage
{
    private static readonly By CreateNewProjectButtonBy = By.Id("createButton");
    private static readonly By ProjectMenuButtonBy = By.CssSelector("tbody tr:nth-last-child(1) td:nth-last-child(1) div button");
    private static readonly By RemoveProjectButtonBy = By.XPath("//button[text()='Remove']");
    private static readonly By DeleteProjectButtonBy = By.XPath("//div[@id='modals']//span[text()='Delete project']/..");

    public ProjectsPage(IWebDriver driver) : base(driver)
    {
    }

    public IWebElement CreateNewProjectButton => WaitsHelper.WaitForExists(CreateNewProjectButtonBy);
    public IWebElement ProjectMenuButton => WaitsHelper.WaitForExists(ProjectMenuButtonBy);
    public IWebElement RemoveProjectButton => WaitsHelper.WaitForExists(RemoveProjectButtonBy);
    public IWebElement DeleteProjectButton => WaitsHelper.WaitForExists(DeleteProjectButtonBy);
    
    public override bool IsPageOpened() => CreateNewProjectButton.Displayed;
    
    public void ClickCreateNewProjectButton() => CreateNewProjectButton.Click();
    public void ClickProjectMenuButton() => ProjectMenuButton.Click();
    public void ClickRemoveProjectButton() => RemoveProjectButton.Click();
    public void ClickDeleteProjectButton() => DeleteProjectButton.Click();
}