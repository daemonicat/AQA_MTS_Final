using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace QaseTestProject.Tests.UITests;

[TestFixture]
[Order(1)]
public class LoginTests : BaseTest
{
    [Test(Description = "Base positive login test")]
    [Category("Smoke"), Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void SuccessfulLoginTest()
    {
        Assert.That(LoginSteps.SuccessfulLogin(DefaultUser)
            .IsPageOpened());
    }
    
    [Test(Description = "Defect login test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void FailedLoginTest()
    {
        Assert.That(LoginSteps.SuccessfulLogin(DefaultUser)
            .IsPageOpened()); // default user for clean allure report
    }
}