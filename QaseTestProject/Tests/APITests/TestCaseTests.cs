using Bogus;
using QaseTestProject.Fakers;
using QaseTestProject.Models.API;

namespace QaseTestProject.Tests.APITests;

public class TestCaseTests : BaseApiTest
{
    private const string ProjectCode = "TESTCODE";
    private static Faker<TestCase> TestCase => new TestCaseFaker();
    private readonly TestCase _testCase = TestCase.Generate();

    [Test]
    [Order(1)]
    [Category("Smoke")]
    [Category("Regression")]
    [Category("NFE")]
    [Category("POST")]
    public async Task CreateNewTestCaseTest()
    {
        var actualTestCase = await TestCaseService.CreateNewTestCase(_testCase, ProjectCode);

        Assert.Multiple(() =>
            {
                Assert.That(actualTestCase.Status, Is.EqualTo(true));
                Assert.That(actualTestCase.Result.Id, Is.Not.EqualTo(0));
            }
        );
        _testCase.Id = actualTestCase.Result.Id;
        Logger.Info("CreateNewTestCaseTest is successful");
    }

    [Test]
    [Order(2)]
    [Category("Regression")]
    [Category("AFE")]
    [Category("PATCH")]
    public async Task UpdateTestCaseTest()
    {
        var testCase = new TestCase();

        var actualTestCase = await TestCaseService.UpdateTestCase(testCase, ProjectCode, _testCase.Id);
        Assert.That(actualTestCase.Status, Is.EqualTo(false));
        Logger.Info("UpdateTestCaseTest is successful");
    }

    [Test]
    [Order(3)]
    [Category("Regression")]
    [Category("NFE")]
    [Category("GET")]
    public async Task GetTestCaseTest()
    {
        var actualTestCase = await TestCaseService.GetTestCase(ProjectCode, _testCase.Id);
        Assert.That(actualTestCase.Status, Is.EqualTo(true));
        Logger.Info("GetTestCaseTest is successful");
    }

    [Test]
    [Order(4)]
    [Category("Regression")]
    [Category("NFE")]
    [Category("DELETE")]
    public async Task DeleteTestCaseTest()
    {
        var actualTestCase = await TestCaseService.DeleteTestCase(ProjectCode, _testCase.Id);
        Assert.That(actualTestCase.Status, Is.EqualTo(true));
        Logger.Info("DeleteTestCaseTest is successful");
    }
}