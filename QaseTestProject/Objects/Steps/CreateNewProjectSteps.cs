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

    public ProjectPage CreateProject(string name, string code, string description, string projectAccessType, string? memberAccessType)
    {
        _projectsPage.ClickCreateNewProjectButton();
        Thread.Sleep(2000);
        _createProjectDialogue.FillInNameField(name);
        Thread.Sleep(2000);
        _createProjectDialogue.FillInProjectCode(code);
        Thread.Sleep(2000);
        _createProjectDialogue.FillInProjectDescription(description);
        Thread.Sleep(2000);
        _createProjectDialogue.SetProjectAccessType(projectAccessType);
        Thread.Sleep(2000);
        if (projectAccessType != "public") {_createProjectDialogue.SetMemberAccessType(memberAccessType!);}
        Thread.Sleep(2000);
        _createProjectDialogue.ClickCreateProjectButton();
        Thread.Sleep(2000);
        
        return new ProjectPage(Driver);
    }
}