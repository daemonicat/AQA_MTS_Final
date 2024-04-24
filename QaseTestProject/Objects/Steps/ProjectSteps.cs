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
        Logger.Info("Import Tests:");

        var location = Assembly.GetExecutingAssembly().Location;
        var assemblyPath = Path.GetDirectoryName(location) ?? throw new Exception("Wrong assembly path");
        var filePath = Path.Combine(assemblyPath, "Resources", fileName);
        Logger.Info("Path.Combine done");

        _projectsPage.ClickOpenFirstProject();
        Logger.Info("ClickOpenFirstProject done");

        _projectPage.ClickDataMenuButton();
        Logger.Info("ClickDataMenuButton done");

        _projectPage.ClickImportDataButton();
        Logger.Info("ClickImportDataButton done");

        _projectPage.ClickChooseFileButton(filePath);
        Logger.Info("ClickChooseFileButton done");

        _projectPage.ClickImportTestsButton();
        Logger.Info("ClickImportTestsButton done");
        Logger.Info("Import Tests finished");

        return _projectPage;
    }
}