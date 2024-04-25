using Allure.Net.Commons;

namespace QaseTestProject.Helpers;

public class BaseGeneralTest
{
    [OneTimeSetUp]
    public static void GlobalSetup()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
    }
}