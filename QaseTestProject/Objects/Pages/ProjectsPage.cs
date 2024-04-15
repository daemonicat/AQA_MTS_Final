using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class ProjectsPage : BasePage
{
    private static readonly By CreateNewProjectButtonBy = By.Id("createButton");

    public ProjectsPage(IWebDriver driver, bool openPageByUrl = true) : base(driver, openPageByUrl)
    {
    }

    public IWebElement CreateNewProjectButton => WaitsHelper.WaitForExists(CreateNewProjectButtonBy);
}