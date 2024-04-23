using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;
using QaseTestProject.Models.UI;

namespace QaseTestProject.Tests.UITests;

public class BoundaryValueTests : BaseTest
{
    [Test(Description = "Minimum (2) Value test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void MinValueTest()
    {
        var projectInput = new Project.Builder()
            .SetTitle("ATProject")
            .SetCode("AT")
            .SetDescription("That's a description, right?")
            .SetProjectAccessType("public")
            .Build();
        
        LoginSteps.SuccessfulLogin(Configurator.Default.Username, Configurator.Default.Password);
        Assert.That(
            ProjectsSteps.CreateProject(
                    projectInput)
                .IsPageOpened);
    }
    
    [Test(Description = "Maximum (10) Value test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void MaxValueTest()
    {
        var projectInput = new Project.Builder()
            .SetTitle("ATProject")
            .SetCode("TENCHARSCO")
            .SetDescription("That's a description, right?")
            .SetProjectAccessType("public")
            .Build();
        
        LoginSteps.SuccessfulLogin(Configurator.Default.Username, Configurator.Default.Password);
        Assert.That(
            ProjectsSteps.CreateProject(
                    projectInput)
                .IsPageOpened);
    }
    
    [Test(Description = "Minimum Out of Bounds (1) Value Test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void MinOOBValueTest()
    {
        var projectInput = new Project.Builder()
            .SetTitle("ATProject")
            .SetCode("C")
            .SetDescription("That's a description, right?")
            .SetProjectAccessType("public")
            .SetMemberAccessType("all")
            .Build();
        
        LoginSteps.SuccessfulLogin(Configurator.Default.Username, Configurator.Default.Password);
        Assert.That(
            ProjectsSteps.FailNewProjectCreation(projectInput).CheckMinCharsProjectCodeError());

    }
    
    [Test(Description = "Maximum Out of Bounds Value Test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void MaxOOBValueTest()
    {
        var projectInput = new Project.Builder()
            .SetTitle("ATProject")
            .SetCode("TWELVECHARSC")
            .SetDescription("That's a description, right?")
            .SetProjectAccessType("public")
            .SetMemberAccessType("all")
            .Build();
        
        LoginSteps.SuccessfulLogin(Configurator.Default.Username, Configurator.Default.Password);
        Assert.That(
            ProjectsSteps.FailNewProjectCreation(projectInput).CheckMaxCharsProjectCodeError());
    }
}