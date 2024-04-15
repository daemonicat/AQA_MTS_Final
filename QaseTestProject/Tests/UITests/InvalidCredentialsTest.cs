using QaseTestProject.Helpers.Configuration;
using QaseTestProject.Objects.Pages;
using QaseTestProject.Objects.Steps;

namespace QaseTestProject.Tests.UITests;

public class InvalidCredentialsTest : BaseTest
{
    [Test]
    [Category("Regression")]
    public void InvalidLoginTest()
    {
        var loginPage = new LoginPage(Driver);
        LoginSteps.Login("blah@blah.com", "definitelyWrongPassword");
        
        Assert.That(loginPage.ErrorAlert.Text, Is.EqualTo("These credentials do not match our records."));
    }
}