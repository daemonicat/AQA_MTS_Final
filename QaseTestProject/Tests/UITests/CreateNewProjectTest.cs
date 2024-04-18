using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class CreateNewProjectTest : BaseTest
{
    [Test]
    [Category("Regression")]
    public void CreateProjectTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username!, Configurator.AppSettings.Password!);
        Thread.Sleep(5000);
        Assert.That(
            CreateNewProjectSteps.CreateProject("name", "code", "description text", "public", "All").IsPageOpened);
    }
}