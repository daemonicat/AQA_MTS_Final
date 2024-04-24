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
        Logger.Info("Create Project:");
        
        _projectsPage.ClickCreateNewProjectButton();
        Logger.Info("ClickCreateNewProjectButton done");

        _createProjectDialogue.FillInNameField(project.Title);
        Logger.Info("FillInNameField done");

        _createProjectDialogue.FillInProjectCode(project.Code);
        Logger.Info("FillInProjectCode done");

        _createProjectDialogue.FillInProjectDescription(project.Description);
        Logger.Info("FillInProjectDescription done");

        if (project.ProjectAccessType == "public")
        {
            _createProjectDialogue.SetProjectAccessType(project.ProjectAccessType);
            Logger.Info("SetProjectAccessType done");
        }
        else
        {
            _createProjectDialogue.SetMemberAccessType(project.MemberAccessType);
            Logger.Info("SetMemberAccessType done");
        }

        _createProjectDialogue.ClickCreateProjectButton();
        Logger.Info("ClickCreateProjectButton done");
        Logger.Info("Create Project finished");
        
        return new ProjectPage(Driver);
    }

    [AllureStep("Fail new project creation")]
    public CreateProjectDialogue FailNewProjectCreation(Project project)
    {
        Logger.Info("Fail new project creation:");
        
        _projectsPage.ClickCreateNewProjectButton();
        Logger.Info("ClickCreateNewProjectButton done");

        _createProjectDialogue.FillInNameField(project.Title);
        Logger.Info("FillInNameField done");

        _createProjectDialogue.FillInProjectCode(project.Code);
        Logger.Info("FillInProjectCode done");

        _createProjectDialogue.FillInProjectDescription(project.Description);
        Logger.Info("FillInProjectDescription done");

        if (project.ProjectAccessType == "public")
        {
            _createProjectDialogue.SetProjectAccessType(project.ProjectAccessType);
            Logger.Info("SetProjectAccessType done");
        }
        else
        {
            _createProjectDialogue.SetMemberAccessType(project.MemberAccessType);
            Logger.Info("SetMemberAccessType done");
        }

        _createProjectDialogue.ClickCreateProjectButton();
        Logger.Info("ClickCreateProjectButton done");
        Logger.Info("Fail new project creation finished");

        return _createProjectDialogue;
    }
}