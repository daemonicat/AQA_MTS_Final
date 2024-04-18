using System.Net;
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
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string filePath = Path.Combine(assemblyPath, "Resources", fileName);

        _projectsPage.ClickOpenFirstProject();
        _projectPage.ClickDataMenuButton();
        _projectPage.ClickImportDataButton();
        _projectPage.ClickChooseFileButton(filePath);
        _projectPage.ClickImportTestsButton();

        return _projectPage;
    }
}