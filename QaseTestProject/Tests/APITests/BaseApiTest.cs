using Allure.NUnit;
using NLog;
using QaseTestProject.Clients;
using QaseTestProject.Services;

namespace QaseTestProject.Tests.APITests;

[AllureNUnit]
public class BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected ProjectService ProjectService;
    
    [OneTimeSetUp]
    public void SetUpApi()
    {
        var client = new RestClientExtended();
        ProjectService = new ProjectService(client);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        ProjectService.Dispose();
    }
}