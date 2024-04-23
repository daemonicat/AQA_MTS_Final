using QaseTestProject.Models.API;

namespace QaseTestProject.Tests.APITests;

public class TestCaseTests : BaseApiTest
{
    private const string ProjectCode = "TESTCODE";
    private int _testCaseId;

    [Test]
    [Order(1)]
    [Category("Smoke")]
    [Category("Regression")]
    [Category("NFE")]
    public async Task CreateNewTestCaseTest()
    {
        var testCase = new TestCase
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

        var actualTestCase = await TestCaseService.CreateNewTestCase(testCase, ProjectCode);

        Assert.Multiple(() =>
            {
                Assert.That(actualTestCase.Status, Is.EqualTo(true));
                Assert.That(actualTestCase.Result.Id, Is.Not.EqualTo(0));
            }
        );
        _testCaseId = actualTestCase.Result.Id;
        Logger.Info("CreateNewTestCaseTest is successful");
    }

    [Test]
    [Order(2)]
    [Category("Regression")]
    [Category("AFE")]
    public async Task UpdateTestCaseTest()
    {
        var testCase = new TestCase();

        var actualTestCase = await TestCaseService.UpdateTestCase(testCase, ProjectCode, _testCaseId);
        Assert.That(actualTestCase.Status, Is.EqualTo(false));
        Logger.Info("UpdateTestCaseTest is successful");
    }

    [Test]
    [Order(3)]
    [Category("Regression")]
    [Category("NFE")]
    public async Task GetTestCaseTest()
    {
        var actualTestCase = await TestCaseService.GetTestCase(ProjectCode, _testCaseId);
        Assert.That(actualTestCase.Status, Is.EqualTo(true));
        Logger.Info("GetTestCaseTest is successful");
    }

    [Test]
    [Order(4)]
    [Category("Regression")]
    [Category("NFE")]
    public async Task DeleteTestCaseTest()
    {
        var actualTestCase = await TestCaseService.DeleteTestCase(ProjectCode, _testCaseId);
        Assert.That(actualTestCase.Status, Is.EqualTo(true));
        Logger.Info("DeleteTestCaseTest is successful");
    }
}