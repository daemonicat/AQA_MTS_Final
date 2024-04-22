using QaseTestProject.Models;

namespace QaseTestProject.Tests.APITests;

public class TestCaseTests : BaseApiTest
{
    private const string ProjectCode = "TESTCODE";

    [Test]
    [Order(1)]
    [Category("Smoke")]
    [Category("Regression")]
    [Category("NFE")]
    public async Task CreateNewTestCaseTest()
    {
        var testCase = new TestCase()
        {
            Title = "MeowTest",
            Description = "Test description",
            Severity = 4,
            Priority = 1,
            Type = 1,
            Layer = 1,
            Behavior = 2,
            Automation = 0,
            Status = 0,
            AuthorId = 216468,
            CreatedAt = "2024-04-23T01:20:00",
            UpdatedAt = "2024-04-23T01:20:00"
        };

        Logger.Info(testCase);

        var actualTestCase = await TestCaseService.CreateNewTestCase(testCase, ProjectCode);
        Logger.Info($"_project.Status = {actualTestCase.Status}");
        Assert.Multiple(() =>
            {
                Assert.That(actualTestCase.Status, Is.EqualTo(true));
                Assert.That(actualTestCase.Result.Id, Is.Not.EqualTo(0));
            }
        );
    }
    
    //WIP
    [Test]
    [Order(2)]
    [Category("Smoke")]
    [Category("Regression")]
    [Category("NFE")]
    public async Task UpdateTestCaseTest()
    {
        var testCase = new TestCase()
        {
            Title = "MeowTest",
            Description = "Test description",
            Severity = 4,
            Priority = 1,
            Type = 1,
            Layer = 1,
        };

        Logger.Info(testCase);

        var actualTestCase = await TestCaseService.UpdateTestCase(testCase, ProjectCode, 3);
        Logger.Info($"_project.Status = {actualTestCase.Status}");
        Assert.Multiple(() =>
            {
                Assert.That(actualTestCase.Status, Is.EqualTo(true));
                Assert.That(actualTestCase.Result.Id, Is.Not.EqualTo(0));
            }
        );
    }
    
    // WIP
    [Test]
    [Order(3)]
    [Category("Smoke")]
    [Category("Regression")]
    [Category("NFE")]
    public async Task GetTestCaseTest()
    {
        var actualTestCase = await TestCaseService.GetTestCase("TESTCODE", 1);
        Logger.Info($"_project.Status = {actualTestCase.Status}");
        Assert.Multiple(() =>
            {
                Assert.That(actualTestCase.Status, Is.EqualTo(true));
                Assert.That(actualTestCase.Result.Id, Is.Not.EqualTo(0));
            }
        );
    }
}