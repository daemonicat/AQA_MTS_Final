using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class BoundaryValueTests : BaseTest
{
    [Test(Description = "Minimum (2) Value test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void MinValueTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username!, Configurator.AppSettings.Password!);
        Assert.That(
            ProjectsSteps.CreateProject(
                    "name1", "co", "description text", "private", "All")
                .IsPageOpened);
    }
    
    [Test(Description = "Maximum (10) Value test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void MaxValueTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username!, Configurator.AppSettings.Password!);
        Assert.That(
            ProjectsSteps.CreateProject(
                    "name2", "codecodeco", "description text", "private", "All")
                .IsPageOpened);
    }
    
    [Test(Description = "Minimum Out of Bounds (1) Value Test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void MinOOBValueTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username!, Configurator.AppSettings.Password!);
        Assert.That(
            ProjectsSteps.FailNewProjectCreation("name3", "q", "description text", "private", "All").CheckMinCharsProjectCodeError());

    }
    
    [Test(Description = "Maximum Out of Bounds Value Test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void MaxOOBValueTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.AppSettings.Username!, Configurator.AppSettings.Password!);
        Assert.That(
            ProjectsSteps.FailNewProjectCreation("name4", "1234567891011", "description text", "private", "All").CheckMaxCharsProjectCodeError());
    }
}