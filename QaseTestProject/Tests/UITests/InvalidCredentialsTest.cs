using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace QaseTestProject.Tests.UITests;

public class InvalidCredentialsTest : BaseTest
{
    [Test(Description = "Negative login test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("AFE")]
    [AllureSeverity(SeverityLevel.critical)]
    public void InvalidLoginTest()
    {
        Assert.That(
            LoginSteps.UnsuccessfulLogin(BrokenUser)
                .ErrorAlert.Text.Trim(),
            Is.EqualTo("These credentials do not match our records."));
    }
}