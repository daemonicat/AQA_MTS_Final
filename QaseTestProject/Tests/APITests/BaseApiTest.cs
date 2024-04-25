using Allure.NUnit;
using Allure.NUnit.Attributes;
using NLog;
using QaseTestProject.Clients;
using QaseTestProject.Helpers;
using QaseTestProject.Services;

namespace QaseTestProject.Tests.APITests;

[AllureSuite("API Tests")]
[AllureNUnit]
public class BaseApiTest
{
    protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
    protected ProjectService ProjectService;
    protected TestCaseService TestCaseService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var client = new RestClientExtended();
        ProjectService = new ProjectService(client);
        TestCaseService = new TestCaseService(client);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        ProjectService.Dispose();
        TestCaseService.Dispose();
    }
}