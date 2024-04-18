using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class LoginTest : BaseTest
{
    [Test(Description = "Base positive login test")]
    [Category("Smoke")]
    [Category("Regression")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void SuccessfulLoginTest()
    {
        Assert.That(LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username!, Configurator.AppSettings.Password!)
            .IsPageOpened());
    }
}