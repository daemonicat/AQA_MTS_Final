using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using Bogus;
using QaseTestProject.Fakers;
using QaseTestProject.Models.API;

namespace QaseTestProject.Tests.APITests;

public class TestCaseTests : BaseApiTest
{
    private const string ProjectCode = "TESTCODE";
    private static Faker<TestCase> TestCase => new TestCaseFaker();
    private readonly TestCase _testCase = TestCase.Generate();

    [Test(Description = "Create entity (test case) test")]
    [Order(1)]
    [Category("Smoke"), Category("Regression"), Category("POST")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("NFE")]
    [AllureSeverity(SeverityLevel.blocker)]
    public async Task CreateNewTestCaseTest()
    {
        Logger.Info(_testCase);
        
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

    [Test(Description = "Update entity (test case) test")]
    [Order(2)]
    [Category("Regression"), Category("PATCH")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("AFE")]
    [AllureSeverity(SeverityLevel.critical)]
    public async Task UpdateTestCaseTest()
    {
        var testCase = new TestCase();

        var actualTestCase = await TestCaseService.UpdateTestCase(testCase, ProjectCode, _testCase.Id);
        Assert.That(actualTestCase.Status, Is.EqualTo(false));
        Logger.Info("UpdateTestCaseTest is successful");
    }

    [Test(Description = "Get entity (test case) test")]
    [Order(3)]
    [Category("Regression"), Category("GET")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("NFE")]
    [AllureSeverity(SeverityLevel.blocker)]
    public async Task GetTestCaseTest()
    {
        Logger.Info(_testCase);
        
        var actualTestCase = await TestCaseService.GetTestCase(ProjectCode, _testCase.Id);
        Assert.That(actualTestCase.Status, Is.EqualTo(true));
        Logger.Info("GetTestCaseTest is successful");
    }

    [Test(Description = "Delete entity (test case) test")]
    [Order(4)]
    [Category("Regression"), Category("DELETE")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("NFE")]
    [AllureSeverity(SeverityLevel.critical)]
    public async Task DeleteTestCaseTest()
    {
        Logger.Info(_testCase);
        
        var actualTestCase = await TestCaseService.DeleteTestCase(ProjectCode, _testCase.Id);
        Assert.That(actualTestCase.Status, Is.EqualTo(true));
        Logger.Info("DeleteTestCaseTest is successful");
    }
}