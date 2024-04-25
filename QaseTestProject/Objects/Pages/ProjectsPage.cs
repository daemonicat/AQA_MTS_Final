using OpenQA.Selenium;
using QaseTestProject.Elements;

namespace QaseTestProject.Objects.Pages;

public class ProjectsPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By CreateNewProjectButtonBy = By.Id("createButton");
    private static readonly By OpenFirstProjectBy = By.XPath("//div[@id='application-content']//tbody/tr[1]/td[2]//a");

    private Button CreateNewProjectButton => new(Driver, CreateNewProjectButtonBy);
    private Button OpenFirstProject => new(Driver, OpenFirstProjectBy);

    public override bool IsPageOpened() => CreateNewProjectButton.Displayed;
    public void ClickCreateNewProjectButton() => CreateNewProjectButton.Click();
    public void ClickOpenFirstProject() => OpenFirstProject.Click();
}