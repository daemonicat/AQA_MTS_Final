namespace QaseTestProject.Tests.UITests;

public class InvalidCredentialsTest : BaseTest
{
    [Test]
    [Category("Regression")]
    public void InvalidLoginTest()
    {
        Assert.That(
            LoginSteps.UnsuccessfulLogin("blah@blah.com", "definitelyWrongPassword")
                .ErrorAlert.Text.Trim(),
            Is.EqualTo("These credentials do not match our records."));
    }
}