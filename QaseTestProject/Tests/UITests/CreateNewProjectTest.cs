using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;
using QaseTestProject.Models.UI;

namespace QaseTestProject.Tests.UITests;

public class CreateNewProjectTest : BaseTest
{
    [Test(Description = "Create entity (new project) test")]
    [Category("Smoke")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void CreateProjectTest()
    {
        var projectInput = new Project.Builder()
            .SetTitle("ATProject")
            .SetCode("TESTATCODE")
            .SetDescription("That's a description, right?")
            .SetProjectAccessType("public")
            .Build();
        
        LoginSteps.SuccessfulLogin(Configurator.Default.Username, Configurator.Default.Password);
        Assert.That(
            ProjectsSteps.CreateProject(projectInput)
                .IsPageOpened);
    }
}