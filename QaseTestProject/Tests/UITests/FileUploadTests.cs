using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace QaseTestProject.Tests.UITests;

public class FileUploadTests : BaseTest
{
    [Test(Description = "Upload test cases test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("NFE")]
    [AllureSeverity(SeverityLevel.critical)]
    public void UploadFilePositiveTest()
    {
        LoginSteps.SuccessfulLogin(DefaultUser);
        Assert.That(
            ProjectSteps.ImportTests("testdata.json").SuccessTextPopUpDisplayed
        );
    }
    
    [Test(Description = "Fail to upload test cases test")]
    [Category("Regression")]
    [AllureOwner("Dmitry Kuzmin")]
    [AllureFeature("AFE")]
    [AllureSeverity(SeverityLevel.critical)]
    public void UploadFileNegativeTest()
    {
        LoginSteps.SuccessfulLogin(DefaultUser);
        
        Assert.That(
            ProjectSteps.ImportTests("testdatanegative.json").ErrorTextPopUpDisplayed
        );
    }
}