using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class ProjectPage : BasePage
{
    //WIP
    private static readonly By CreateNewCaseButtonBy = By.Id("create-case-button");
    private static readonly By ImportDataButtonBy = By.XPath("//a[text()='Import data']");
    private static readonly By ChooseFileButtonBy = By.XPath("//input[@type='file']");
    private static readonly By ImportTestsButtonBy = By.XPath("//button[@class='G1dmaA ecSEF_ IAcAWv' and @type='submit']");

    public ProjectPage(IWebDriver driver) : base(driver)
    {
    }

    public IWebElement CreateNewCaseButton => WaitsHelper.WaitForExists(CreateNewCaseButtonBy);
    public IWebElement ImportDataButton => WaitsHelper.WaitForExists(ImportDataButtonBy);
    public IWebElement ChooseFileButton => WaitsHelper.WaitForExists(ChooseFileButtonBy);
    public IWebElement ImportTestsButton => WaitsHelper.WaitForExists(ImportTestsButtonBy);

    public override bool IsPageOpened()
    {
        return CreateNewCaseButton.Displayed;
    }
}