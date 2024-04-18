using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using QaseTestProject.Objects.Pages;

namespace QaseTestProject.Objects.Steps;

public class CreateNewProjectSteps : BaseSteps
{
    private readonly CreateProjectDialogue _createProjectDialogue;
    private readonly ProjectsPage _projectsPage;
    
    public CreateNewProjectSteps (IWebDriver driver) : base(driver)
    {
        _createProjectDialogue = new CreateProjectDialogue(Driver);
        _projectsPage = new ProjectsPage(Driver);
    }

    [AllureStep("Create new project")]
    public ProjectPage CreateProject(string name, string code, string description, string projectAccessType, string? memberAccessType)
    {
        _projectsPage.ClickCreateNewProjectButton();
        _createProjectDialogue.FillInNameField(name);
        _createProjectDialogue.FillInProjectCode(code);
        _createProjectDialogue.FillInProjectDescription(description);
        _createProjectDialogue.SetProjectAccessType(projectAccessType);
        if (projectAccessType != "public") {_createProjectDialogue.SetMemberAccessType(memberAccessType!);}
        _createProjectDialogue.ClickCreateProjectButton();
        
        return new ProjectPage(Driver);
    }
}