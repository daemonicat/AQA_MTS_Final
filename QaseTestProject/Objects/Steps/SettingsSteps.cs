using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using QaseTestProject.Objects.Pages;

namespace QaseTestProject.Objects.Steps;

public class SettingsSteps : BaseSteps
{
    private readonly SettingsPage _settingsPage;
    private readonly ProjectsPage _projectsPage;
    
    public SettingsSteps(IWebDriver driver) : base(driver)
    {
        _settingsPage = new SettingsPage(Driver);
        _projectsPage = new ProjectsPage(Driver);
    }
    
    [AllureStep("Delete project by code")]
    public ProjectsPage DeleteProject(string projectCode)
    {
        Logger.Info("Delete project:");
        _projectsPage.IsPageOpened();
        Logger.Info("IsPageOpened done");
        
        Driver.Navigate().GoToUrl($"https://app.qase.io/project/{projectCode}/settings/general");
        Logger.Info($"GoToUrl = https://app.qase.io/project/{projectCode}/settings/general");
        
        _settingsPage.ClickDeleteProjectButton();
        Logger.Info("ClickDeleteProjectButton done");
        
        _settingsPage.ClickDeleteProjectFinalButton();
        Logger.Info("ClickDeleteProjectFinalButton done");
        Logger.Info("Delete project finished");
        
        return _projectsPage;
    }
}