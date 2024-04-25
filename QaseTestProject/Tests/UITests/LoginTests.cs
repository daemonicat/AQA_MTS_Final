using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class LoginTests : BaseTest
{
    [Test(Description = "Base positive login test")]
    [Category("Smoke")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void SuccessfulLoginTest()
    {
        Assert.That(LoginSteps.SuccessfulLogin(Configurator.Default.Username, Configurator.Default.Password)
            .IsPageOpened());
    }
    
    [Test(Description = "Defect login test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.blocker)]
    [Ignore("Ignore a test")]
    public void FailedLoginTest()
    {
        Assert.That(LoginSteps.SuccessfulLogin("Testeam@ail.com", Configurator.Default.Password)
            .IsPageOpened());
    }
}