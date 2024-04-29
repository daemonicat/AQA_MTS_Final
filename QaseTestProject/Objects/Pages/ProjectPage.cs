using OpenQA.Selenium;
using QaseTestProject.Elements;

namespace QaseTestProject.Objects.Pages;

public class ProjectPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By CreateNewCaseButtonBy = By.XPath("//div[@id='application-content']//span[text()='Create new case']/..");
    private static readonly By DataMenuButtonBy = By.XPath("//div[@id='application-content']//div[2]/button");
    private static readonly By ImportDataButtonBy = By.XPath("//a[text()='Import data']");
    private static readonly By ChooseFileButtonBy = By.XPath("//input[@type='file']");
    private static readonly By ImportTestsButtonBy = By.XPath("//div[@id='modals']//button[@type='submit']");
    private static readonly By ErrorTextPopUpBy = By.XPath("//span[text()='Data is invalid.']");

    private static readonly By SuccessTextPopUpBy =
        By.XPath("//div[@role='alert']//span[contains(text(), 'successfully imported!')]");

    private Button CreateNewCaseButton => new(Driver, CreateNewCaseButtonBy);
    private Button DataMenuButton => new(Driver, DataMenuButtonBy);
    private Button ImportDataButton => new(Driver, ImportDataButtonBy);
    private Button ChooseFileButton => new(Driver, ChooseFileButtonBy);
    private Button ImportTestsButton => new(Driver, ImportTestsButtonBy);
    private IWebElement ErrorTextPopUp => WaitsHelper.WaitForExists(ErrorTextPopUpBy);
    private IWebElement SuccessTextPopUp => WaitsHelper.WaitForExists(SuccessTextPopUpBy);

    public override bool IsPageOpened()
    {
        return CreateNewCaseButton.Displayed;
    }

    public ProjectPage ClickDataMenuButton()
    {
        DataMenuButton.Click();
        return this;
    }

    public ProjectPage ClickImportDataButton()
    {
        ImportDataButton.Click();
        return this;
    }

    public ProjectPage ClickChooseFileButton(string path)
    {
        ChooseFileButton.SendKeys(path);
        return this;
    }

    public ProjectPage ClickImportTestsButton()
    {
        ImportTestsButton.Click();
        return this;
    }

    public bool ErrorTextPopUpDisplayed() => ErrorTextPopUp.Displayed;
    public bool SuccessTextPopUpDisplayed() => SuccessTextPopUp.Displayed;
}