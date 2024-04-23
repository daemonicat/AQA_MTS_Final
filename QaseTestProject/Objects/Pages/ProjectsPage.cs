using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class ProjectsPage : BasePage
{
    private static readonly By CreateNewProjectButtonBy = By.Id("createButton");

    private static readonly By ProjectMenuButtonBy =
        By.CssSelector("tbody tr:nth-last-child(1) td:nth-last-child(1) div button");

    private static readonly By RemoveProjectButtonBy = By.XPath("//button[text()='Remove']");

    private static readonly By DeleteProjectButtonBy =
        By.XPath("//div[@id='modals']//span[text()='Delete project']/..");

    private static readonly By OpenFirstProjectBy = By.XPath("//div[@id='application-content']//tbody/tr[1]/td[2]//a");

    public ProjectsPage(IWebDriver driver) : base(driver)
    {
    }

    private IWebElement CreateNewProjectButton => WaitsHelper.WaitForExists(CreateNewProjectButtonBy);
    private IWebElement ProjectMenuButton => WaitsHelper.WaitForExists(ProjectMenuButtonBy);
    private IWebElement RemoveProjectButton => WaitsHelper.WaitForExists(RemoveProjectButtonBy);
    private IWebElement DeleteProjectButton => WaitsHelper.WaitForExists(DeleteProjectButtonBy);
    private IWebElement OpenFirstProject => WaitsHelper.WaitForExists(OpenFirstProjectBy);
    public override bool IsPageOpened() => CreateNewProjectButton.Displayed;
    public void ClickCreateNewProjectButton() => CreateNewProjectButton.Click();
    public void ClickProjectMenuButton() => ProjectMenuButton.Click();
    public void ClickRemoveProjectButton() => RemoveProjectButton.Click();
    public void ClickDeleteProjectButton() => DeleteProjectButton.Click();
    public void ClickOpenFirstProject() => OpenFirstProject.Click();
}