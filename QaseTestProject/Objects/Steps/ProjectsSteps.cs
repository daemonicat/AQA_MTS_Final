using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using QaseTestProject.Models.UI;
using QaseTestProject.Objects.Pages;

namespace QaseTestProject.Objects.Steps;

public class ProjectsSteps : BaseSteps
{
    private readonly CreateProjectDialogue _createProjectDialogue;
    private readonly ProjectsPage _projectsPage;

    public ProjectsSteps(IWebDriver driver) : base(driver)
    {
        _createProjectDialogue = new CreateProjectDialogue(Driver);
        _projectsPage = new ProjectsPage(Driver);
    }

    [AllureStep("Create new project")]
    public ProjectPage CreateProject(Project project)
    {
        _projectsPage.ClickCreateNewProjectButton();
        _createProjectDialogue.FillInNameField(project.Title);
        _createProjectDialogue.FillInProjectCode(project.Code);
        _createProjectDialogue.FillInProjectDescription(project.Description);
        if (project.ProjectAccessType == "public")
        {
            _createProjectDialogue.SetProjectAccessType(project.ProjectAccessType);
        }
        else
        {
            _createProjectDialogue.SetMemberAccessType(project.MemberAccessType);
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
    public CreateProjectDialogue FailNewProjectCreation(Project project)
    {
        _projectsPage.ClickCreateNewProjectButton();
        _createProjectDialogue.FillInNameField(project.Title);
        _createProjectDialogue.FillInProjectCode(project.Code);
        _createProjectDialogue.FillInProjectDescription(project.Description);
        if (project.ProjectAccessType == "public")
        {
            _createProjectDialogue.SetProjectAccessType(project.ProjectAccessType);
        }
        else
        {
            _createProjectDialogue.SetMemberAccessType(project.MemberAccessType);
        }
        
        _createProjectDialogue.ClickCreateProjectButton();

        return _createProjectDialogue;
    }
}