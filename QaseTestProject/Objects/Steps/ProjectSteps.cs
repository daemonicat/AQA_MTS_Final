using System.Reflection;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using QaseTestProject.Objects.Pages;

namespace QaseTestProject.Objects.Steps;

public class ProjectSteps : BaseSteps
{
    private readonly ProjectsPage _projectsPage;
    private readonly ProjectPage _projectPage;

    public ProjectSteps(IWebDriver driver) : base(driver)
    {
        _projectsPage = new ProjectsPage(Driver);
        _projectPage = new ProjectPage(Driver);
    }

    [AllureStep("Import Tests")]
    public ProjectPage ImportTests(string fileName)
    {
        Logger.Info("Import Tests started");

        var location = Assembly.GetExecutingAssembly().Location;
        var assemblyPath = Path.GetDirectoryName(location) ?? throw new Exception("Wrong assembly path");
        var filePath = Path.Combine(assemblyPath, "Resources", fileName);

        _projectsPage.ClickOpenFirstProject();

        _projectPage
            .ClickDataMenuButton()
            .ClickImportDataButton()
            .ClickChooseFileButton(filePath)
            .ClickImportTestsButton();
        
        Logger.Info("Import Tests finished");

        return _projectPage;
    }
}