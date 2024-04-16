using OpenQA.Selenium;
using QaseTestProject.Objects.Pages;

namespace QaseTestProject.Objects.Steps;

public class CreateNewProjectSteps : BaseSteps
{
    private readonly CreateProjectDialogue _createProjectDialogue;
    
    public CreateNewProjectSteps (IWebDriver driver) : base(driver)
    {
        _createProjectDialogue = new CreateProjectDialogue(Driver);
    }

    public ProjectPage CreateProject(string name, string code, string accessType, string memberType)
    {
        return new ProjectPage(Driver);
    }
}