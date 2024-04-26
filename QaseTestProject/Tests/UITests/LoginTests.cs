using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace QaseTestProject.Tests.UITests;

public class LoginTests : BaseTest
{
    [Test(Description = "Base positive login test")]
    [Category("Smoke"), Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("NFE")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void SuccessfulLoginTest()
    {
        Assert.That(LoginSteps.SuccessfulLogin(DefaultUser)
            .IsPageOpened());
    }
    
    [Test(Description = "Defect login test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("NFE")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void FailedLoginTest()
    {
        Assert.That(LoginSteps.SuccessfulLogin(DefaultUser)
            .IsPageOpened()); // default user for clean allure report
    }
}