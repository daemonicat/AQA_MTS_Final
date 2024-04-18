using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class CreateNewProjectTest : BaseTest
{
    [Test(Description = "Create entity (new project) test")]
    [Category("Smoke")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void CreateProjectTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username!, Configurator.AppSettings.Password!);
        Assert.That(
            ProjectsSteps.CreateProject(
                    "name0", "code", "description text", "private", "All")
                .IsPageOpened);
    }
}