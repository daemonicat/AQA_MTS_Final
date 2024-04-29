using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using Bogus;
using QaseTestProject.Fakers;
using QaseTestProject.Models.API;

namespace QaseTestProject.Tests.APITests;

public class ProjectTests : BaseApiTest
{
    private static Faker<Project> Project => new ProjectFaker();
    private readonly Project _project = Project.Generate();
    
    [Test(Description = "Create entity (project) test")]
    [Order(1)]
    [Category("Smoke"), Category("Regression"), Category("POST")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("NFE")]
    [AllureSeverity(SeverityLevel.blocker)]
    public async Task AddProjectTest()
    {
        Logger.Info(_project);

        var actualProject = await ProjectService.CreateNewProject(_project);
        Logger.Info($"_project.Status = {actualProject.Status}");
        Logger.Info($"actualProject.Result.Code = {actualProject.Result?.Code}");

        Assert.That(actualProject.Status, Is.EqualTo(true));
    }

    [Test(Description = "Get missing entity (project) test")]
    [Order(2)]
    [Category("Regression"), Category("GET")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("AFE")]
    [AllureSeverity(SeverityLevel.critical)]
    public void GetMissingProjectTest()
    {
        const string code = "CODE2";

        var actualProject = ProjectService.GetProjectByCode(code);

        Logger.Info(
            $"Response Status = {actualProject.Result.Status}. Error message: {actualProject.Result.ErrorMessage}");
        Assert.Multiple(() =>
        {
            Assert.That(actualProject.Result.Status, Is.EqualTo(false));
            Assert.That(actualProject.Result.ErrorMessage, Is.EqualTo("Project not found"));
        });
    }

    [Test(Description = "Delete entity (project) test")]
    [Order(3)]
    [Category("Regression"), Category("DELETE")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("NFE")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void DeleteProjectTest()
    {
        var actualProject = ProjectService.DeleteProjectByCode(_project.Code);

        Logger.Info($"Response Status = {actualProject.Result.Status}.");
        Assert.That(actualProject.Result.Status, Is.EqualTo(true));
    }
}