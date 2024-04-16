using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class CreateProjectDialogue : BasePage
{
    private static readonly By ProjectNameBy = By.Name("project-name");
    private static readonly By ProjectCodeBy = By.Name("project-code");
    private static readonly By ProjectDescriptionBy = By.Name("description-area");
    private static readonly By ProjectAccessPrivateBy = By.CssSelector("input[type = 'radio'][@value='private']");
    private static readonly By ProjectAccessPublicBy = By.CssSelector("input[type = 'radio'][@value='public']");
    private static readonly By MemberAccessAllBy = By.CssSelector("input[type = 'radio'][@value='all']");
    private static readonly By MemberAccessGroupBy = By.CssSelector("input[type = 'radio'][@value='group']");
    private static readonly By MemberAccessNoneBy = By.CssSelector("input[type = 'radio'][@value='none']");
    private static readonly By CreateProjectButtonBy = By.XPath("//button[@type='submit']");
    private static readonly By CancelProjectButtonBy = By.XPath("//button[@type='button']");

    public CreateProjectDialogue(IWebDriver driver) : base(driver)
    {
    }

    public IWebElement ProjectName => WaitsHelper.WaitForExists(ProjectNameBy);
    public IWebElement ProjectCode => WaitsHelper.WaitForExists(ProjectCodeBy);
    public IWebElement ProjectDescription => WaitsHelper.WaitForExists(ProjectDescriptionBy);
    public IWebElement ProjectAccessPrivate => WaitsHelper.WaitForVisibilityLocatedBy(ProjectAccessPrivateBy);
    public IWebElement ProjectAccessPublic => WaitsHelper.WaitForExists(ProjectAccessPublicBy);
    public IWebElement MemberAccessAll => WaitsHelper.WaitForExists(MemberAccessAllBy);
    public IWebElement MemberAccessGroup => WaitsHelper.WaitForExists(MemberAccessGroupBy);
    public IWebElement MemberAccessNone => WaitsHelper.WaitForVisibilityLocatedBy(MemberAccessNoneBy);
    public IWebElement CreateProjectButton => WaitsHelper.WaitForExists(CreateProjectButtonBy);
    public IWebElement CancelProjectButton => WaitsHelper.WaitForExists(CancelProjectButtonBy);

    public override bool IsPageOpened()
    {
        return CreateProjectButton.Displayed;
    }
}