using OpenQA.Selenium;
using QaseTestProject.Elements;

namespace QaseTestProject.Objects.Pages;

public class ProjectsPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By CreateNewProjectButtonBy = By.Id("createButton");

    private static readonly By ProjectMenuButtonBy =
        By.CssSelector("tbody tr:nth-last-child(1) td:nth-last-child(1) div button");

    private static readonly By RemoveProjectButtonBy = By.XPath("//button[text()='Remove']");

    private static readonly By DeleteProjectButtonBy =
        By.XPath("//div[@id='modals']//span[text()='Delete project']/..");

    private static readonly By OpenFirstProjectBy = By.XPath("//div[@id='application-content']//tbody/tr[1]/td[2]//a");

    private Button CreateNewProjectButton => new Button(Driver, CreateNewProjectButtonBy);
    private Button ProjectMenuButton => new Button(Driver, ProjectMenuButtonBy);
    private Button RemoveProjectButton => new Button(Driver, RemoveProjectButtonBy);
    private Button DeleteProjectButton => new Button(Driver, DeleteProjectButtonBy);
    private IWebElement OpenFirstProject => WaitsHelper.WaitForExists(OpenFirstProjectBy);
    public override bool IsPageOpened() => CreateNewProjectButton.Displayed;
    public void ClickCreateNewProjectButton() => CreateNewProjectButton.Click();
    public void ClickProjectMenuButton() => ProjectMenuButton.Click();
    public void ClickRemoveProjectButton() => RemoveProjectButton.Click();
    public void ClickDeleteProjectButton() => DeleteProjectButton.Click();
    public void ClickOpenFirstProject() => OpenFirstProject.Click();
}