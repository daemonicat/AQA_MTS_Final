using NLog;
using QaseTestProject.Models;

namespace QaseTestProject.Tests.APITests;

public class ProjectTests : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project _project;

    [Test]
    [Order(1)]
    [Category("Smoke")]
    [Category("Regression")]
    public void AddProjectTest()
    {
        _project = new Project
        {
            Result =
            {
                Title = "APITest",
                Code = "Code1",
                Access = "all"
            }
        };
        
        _logger.Info(_project);

        var actualProject = ProjectService.CreateNewProject(_project);
        
        Assert.That(actualProject.Result.Result.Code, Is.EqualTo(_project.Result.Code));
    }
}