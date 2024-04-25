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
        Logger.Info("Create Project started");
        
        _projectsPage.ClickCreateNewProjectButton();

        _createProjectDialogue
            .FillInNameField(project.Title)
            .FillInProjectCode(project.Code)
            .FillInProjectDescription(project.Description);

        if (project.ProjectAccessType == "public")
        {
            _createProjectDialogue.SetProjectAccessType(project.ProjectAccessType);
        }
        else
        {
            _createProjectDialogue.SetMemberAccessType(project.MemberAccessType);
        }

        _createProjectDialogue.ClickCreateProjectButton();
        Logger.Info("Create Project finished");
        
        return new ProjectPage(Driver);
    }

    [AllureStep("Fail new project creation")]
    public CreateProjectDialogue FailNewProjectCreation(Project project)
    {
        Logger.Info("Fail new project creation started");
        
        _projectsPage.ClickCreateNewProjectButton();

        _createProjectDialogue
            .FillInNameField(project.Title)
            .FillInProjectCode(project.Code)
            .FillInProjectDescription(project.Description);

        if (project.ProjectAccessType == "public")
        {
            _createProjectDialogue.SetProjectAccessType(project.ProjectAccessType);
        }
        else
        {
            _createProjectDialogue.SetMemberAccessType(project.MemberAccessType);
        }

        _createProjectDialogue.ClickCreateProjectButton();
        Logger.Info("Fail new project creation finished");

        return _createProjectDialogue;
    }
}