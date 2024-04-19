using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using QaseTestProject.Objects.Pages;

namespace QaseTestProject.Objects.Steps;

public class ProjectsSteps : BaseSteps
{
    private readonly CreateProjectDialogue _createProjectDialogue;
    private readonly ProjectsPage _projectsPage;
    
    public ProjectsSteps (IWebDriver driver) : base(driver)
    {
        _createProjectDialogue = new CreateProjectDialogue(Driver);
        _projectsPage = new ProjectsPage(Driver);
    }

    [AllureStep("Create new project")]
    public ProjectPage CreateProject(string name, string code, string description, string projectAccessType, string memberAccessType)
    {
        _projectsPage.ClickCreateNewProjectButton();
        _createProjectDialogue.FillInNameField(name);
        _createProjectDialogue.FillInProjectCode(code);
        _createProjectDialogue.FillInProjectDescription(description);
        if (projectAccessType == "public")
        {
            _createProjectDialogue.SetProjectAccessType(projectAccessType);
        } else
        {
            _createProjectDialogue.SetMemberAccessType(memberAccessType);
        }
        _createProjectDialogue.ClickCreateProjectButton();
        
        return new ProjectPage(Driver);
    }

    [AllureStep("Delete last project")]
    public ProjectsPage DeleteLastProject()
    {
        _projectsPage.ClickProjectMenuButton();
        _projectsPage.ClickRemoveProjectButton();
        _projectsPage.ClickDeleteProjectButton();

        return _projectsPage;
    }
    
    [AllureStep("Fail new project creation")]
    public CreateProjectDialogue FailNewProjectCreation(string name, string code, string description, string projectAccessType, string memberAccessType)
    {
        _projectsPage.ClickCreateNewProjectButton();
        _createProjectDialogue.FillInNameField(name);
        _createProjectDialogue.FillInProjectCode(code);
        _createProjectDialogue.FillInProjectDescription(description);
        if (projectAccessType == "public")
        {
            _createProjectDialogue.SetProjectAccessType(projectAccessType);
        } else
        {
            _createProjectDialogue.SetMemberAccessType(memberAccessType);
        }
        
        _createProjectDialogue.ClickCreateProjectButton();
        
        return _createProjectDialogue;
    }
}