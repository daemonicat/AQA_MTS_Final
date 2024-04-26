using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using QaseTestProject.Core;
using QaseTestProject.Helpers;
using QaseTestProject.Helpers.Configuration;
using QaseTestProject.Models;
using QaseTestProject.Objects.Steps;

namespace QaseTestProject.Tests.UITests;

[Parallelizable(scope: ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureSuite("UI Tests")]
[AllureNUnit]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }
    protected WaitsHelper WaitsHelper { get; private set; }

    protected LoginSteps LoginSteps;
    protected ProjectsSteps ProjectsSteps;
    protected ProjectSteps ProjectSteps;
    protected SettingsSteps SettingsSteps;

    protected User? DefaultUser { get; private set; }
    protected User? BrokenUser { get; private set; }

    [SetUp]
    public void FactoryDriverTest()
    {
        Driver = new Browser().Driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

        LoginSteps = new LoginSteps(Driver);
        ProjectsSteps = new ProjectsSteps(Driver);
        ProjectSteps = new ProjectSteps(Driver);
        SettingsSteps = new SettingsSteps(Driver);

        DefaultUser = Configurator.DefaultUser;
        BrokenUser = Configurator.BrokenUser;

        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != NUnit.Framework.Interfaces.TestStatus.Passed ||
                TestContext.CurrentContext.Result.Outcome.Status != NUnit.Framework.Interfaces.TestStatus.Skipped)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var screenshotBytes = screenshot.AsByteArray;

                AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }
        }
        catch
        {
            // ignored
        }

        Driver.Quit();
    }
}