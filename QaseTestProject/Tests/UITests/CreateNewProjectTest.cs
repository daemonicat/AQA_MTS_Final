using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class CreateNewProjectTest : BaseTest
{
    [Test(Description = "Create entity (new project) test")]
    [Category("Regression")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void CreateProjectTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username!, Configurator.AppSettings.Password!);
        Assert.That(
            CreateNewProjectSteps.CreateProject(
                    "name", "code", "description text", "public", "All")
                .IsPageOpened);
    }
}