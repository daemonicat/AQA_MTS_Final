using OpenQA.Selenium;
using QaseTestProject.Core;
using QaseTestProject.Helpers;
using QaseTestProject.Helpers.Configuration;
using QaseTestProject.Objects.Steps;

namespace QaseTestProject.Tests.UITests;

[Parallelizable(scope: ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }
    protected WaitsHelper WaitsHelper { get; private set; }

    protected LoginSteps LoginSteps;
    protected CreateNewProjectSteps CreateNewProjectSteps;

    [SetUp]
    public void FactoryDriverTest()
    {
        Driver = new Browser().Driver!;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

        LoginSteps = new LoginSteps(Driver);
        CreateNewProjectSteps = new CreateNewProjectSteps(Driver);
        
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}