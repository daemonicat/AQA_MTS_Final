using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class DeleteProjectTest : BaseTest
{
    [Test(Description = "Delete entity (project) test")]
    [Category("Regression")]
    [AllureSeverity(SeverityLevel.critical)]
    public void RemoveProjectTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username!, Configurator.AppSettings.Password!);
        Assert.That(ProjectsSteps.DeleteLastProject().IsPageOpened);
    }
}