using NLog;
using QaseTestProject.Models;

namespace QaseTestProject.Tests.APITests;

public class ProjectTests : BaseApiTest
{
    [Test]
    [Order(1)]
    [Category("Smoke")]
    [Category("Regression")]
    [Category("NFE")]
    public async Task AddProjectTest()
    {
        var project = new Project
        {
            Title = "APITest",
            Code = "Code1",
            Access = "all"
        };

        Logger.Info(project);

        var actualProject = await ProjectService.CreateNewProject(project);
        Logger.Info($"_project.Status = {actualProject.Status}");
        Logger.Info($"actualProject.Result.Code = {actualProject.Result.Code}");

        Assert.That(true);
    }

    [Test]
    [Order(2)]
    [Category("Regression")]
    [Category("AFE")]
    public void GetMissingProjectTest()
    {
        const string code = "CODE1";

        var actualProject = ProjectService.GetProjectByCode(code);

        Logger.Info(
            $"Response Status = {actualProject.Result.Status}. Error message: {actualProject.Result.ErrorMessage}");
        Assert.Multiple(() =>
        {
            Assert.That(actualProject.Result.Status, Is.EqualTo(false));
            Assert.That(actualProject.Result.ErrorMessage, Is.EqualTo("Project not found"));
        });
    }

    [Test]
    [Order(3)]
    [Category("Regression")]
    [Category("NFE")]
    public void DeleteProjectTest()
    {
        const string code = "CODE1";

        var actualProject = ProjectService.DeleteProjectByCode(code);

        Logger.Info($"Response Status = {actualProject.Result.Status}.");
        Assert.That(actualProject.Result.Status, Is.EqualTo(true));
    }
}