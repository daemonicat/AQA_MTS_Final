using QaseTestProject.Helpers.Configuration;
using QaseTestProject.Objects.Pages;

namespace QaseTestProject.Tests.UITests;

public class LoginTest : BaseTest
{
    [Test]
    [Category("Smoke")]
    [Category("Regression")]
    public void SuccessfulLoginTest()
    {
        var projectPage = new ProjectsPage(Driver);
        LoginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
        
        Assert.That(projectPage.CreateNewProjectButton.Displayed);
    }
}