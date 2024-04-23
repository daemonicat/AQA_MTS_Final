using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class DeleteProjectTest : BaseTest
{
    [Test(Description = "Delete entity (project) test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void RemoveProjectTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.Default.Username, Configurator.Default.Password);
        Assert.That(ProjectsSteps.DeleteLastProject().IsPageOpened);
    }
}