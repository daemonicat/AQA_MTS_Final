using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class CreateNewProjectTest : BaseTest
{
    [Test(Description = "Create entity (new project) test")]
    [Category("Smoke")]
    [Category("Regression")]
    [AllureSeverity(SeverityLevel.critical)]
    public void CreateProjectTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username!, Configurator.AppSettings.Password!);
        Assert.That(
            ProjectsSteps.CreateProject(
                    "name", "code", "description text", "private", "All")
                .IsPageOpened);
    }
}