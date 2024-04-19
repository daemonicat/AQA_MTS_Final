using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class ProjectPage : BasePage
{
    private static readonly By CreateNewCaseButtonBy = By.Id("create-case-button");
    private static readonly By DataMenuButtonBy = By.XPath("//div[@id='application-content']//div[2]/button");
    private static readonly By ImportDataButtonBy = By.XPath("//a[text()='Import data']");
    private static readonly By ChooseFileButtonBy = By.XPath("//input[@type='file']");
    private static readonly By ImportTestsButtonBy = By.XPath("//div[@id='modals']//button[@type='submit']");
    private static readonly By ErrorTextPopUpBy = By.XPath("//span[text()='Data is invalid.']");

    private static readonly By SuccessTextPopUpBy =
        By.XPath("//div[@role='alert']//span[contains(text(), 'successfully imported!')]");

    public ProjectPage(IWebDriver driver) : base(driver)
    {
    }

    private IWebElement CreateNewCaseButton => WaitsHelper.WaitForExists(CreateNewCaseButtonBy);
    private IWebElement DataMenuButton => WaitsHelper.WaitForExists(DataMenuButtonBy);
    private IWebElement ImportDataButton => WaitsHelper.WaitForExists(ImportDataButtonBy);
    private IWebElement ChooseFileButton => WaitsHelper.WaitForExists(ChooseFileButtonBy);
    private IWebElement ImportTestsButton => WaitsHelper.WaitForExists(ImportTestsButtonBy);
    private IWebElement ErrorTextPopUp => WaitsHelper.WaitForExists(ErrorTextPopUpBy);
    private IWebElement SuccessTextPopUp => WaitsHelper.WaitForExists(SuccessTextPopUpBy);

    public override bool IsPageOpened()
    {
        return CreateNewCaseButton.Displayed;
    }

    public void ClickDataMenuButton() => DataMenuButton.Click();
    public void ClickImportDataButton() => ImportDataButton.Click();
    public void ClickChooseFileButton(string path) => ChooseFileButton.SendKeys(path);
    public void ClickImportTestsButton() => ImportTestsButton.Click();
    public bool ErrorTextPopUpDisplayed() => ErrorTextPopUp.Displayed;
    public bool SuccessTextPopUpDisplayed() => SuccessTextPopUp.Displayed;
}