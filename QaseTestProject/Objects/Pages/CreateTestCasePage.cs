using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class CreateTestCasePage : BasePage
{
    //WIP
    private static readonly By SaveTestCaseButtonBy = By.Id("save-case");
    private static readonly By SaveAndCreateButtonBy = By.CssSelector("button.G1dmaA.fU0Xn2.IAcAWv");
    private static readonly By SetStatusBy = By.Id("0-status");
    private static readonly By SetSuiteBy = By.Id("suite");
    private static readonly By SetSeverityBy = By.Id("0-severity");
    private static readonly By SetPriorityBy = By.Id("0-priority");
    private static readonly By SetTypeBy = By.Id("0-type");
    private static readonly By SetLayerBy = By.Id("0-layer");
    private static readonly By SetIsFlakyBy = By.Id("0-is_flaky");
    private static readonly By SetBehaviorBy = By.Id("0-behavior");
    private static readonly By SetIsManualBy = By.Id("0-isManual");
    private static readonly By ToBeAutomatedCheckboxBy = By.Id("0-isToBeAutomated");
    
    public CreateTestCasePage(IWebDriver driver) : base(driver)
    {
    }
    
    public IWebElement SaveTestCaseButton => WaitsHelper.WaitForExists(SaveTestCaseButtonBy);
    public IWebElement SaveAndCreateButton => WaitsHelper.WaitForExists(SaveAndCreateButtonBy);
    public IWebElement SetStatus => WaitsHelper.WaitForExists(SetStatusBy);
    public IWebElement SetSuite => WaitsHelper.WaitForExists(SetSuiteBy);
    public IWebElement SetSeverity => WaitsHelper.WaitForExists(SetSeverityBy);
    public IWebElement SetPriority => WaitsHelper.WaitForExists(SetPriorityBy);
    public IWebElement SetType => WaitsHelper.WaitForExists(SetTypeBy);
    public IWebElement SetLayer => WaitsHelper.WaitForExists(SetLayerBy);
    public IWebElement SetIsFlaky => WaitsHelper.WaitForExists(SetIsFlakyBy);
    public IWebElement SetBehavior => WaitsHelper.WaitForExists(SetBehaviorBy);
    public IWebElement SetIsManual => WaitsHelper.WaitForExists(SetIsManualBy);
    public IWebElement ToBeAutomatedCheckbox => WaitsHelper.WaitForExists(ToBeAutomatedCheckboxBy);
    

    public override bool IsPageOpened()
    {
        return SaveTestCaseButton.Displayed;
    }
}