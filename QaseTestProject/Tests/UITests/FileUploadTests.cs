using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using QaseTestProject.Helpers.Configuration;

namespace QaseTestProject.Tests.UITests;

public class FileUploadTests : BaseTest
{
    [Test(Description = "Upload test cases test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void UploadFilePositiveTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.Default.Username, Configurator.Default.Password);
        Assert.That(
            ProjectSteps.ImportTests("testdata.json").SuccessTextPopUpDisplayed
        );
    }
    
    [Test(Description = "Fail to upload test cases test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureSeverity(SeverityLevel.critical)]
    public void UploadFileNegativeTest()
    {
        LoginSteps.SuccessfulLogin(Configurator.Default.Username, Configurator.Default.Password);
        
        Assert.That(
            ProjectSteps.ImportTests("testdatanegative.json").ErrorTextPopUpDisplayed
        );
    }
}