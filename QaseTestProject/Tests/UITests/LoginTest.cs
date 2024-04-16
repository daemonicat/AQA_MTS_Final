using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class LoginTest : BaseTest
{
    [Test]
    [Category("Smoke")]
    [Category("Regression")]
    public void SuccessfulLoginTest()
    {
        Assert.That(LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password)
            .IsPageOpened());
    }
}