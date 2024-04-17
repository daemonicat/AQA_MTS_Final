using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class CreateProjectDialogue : BasePage
{
    private static readonly By ProjectNameBy = By.Id("project-name");
    private static readonly By ProjectCodeBy = By.Id("project-code");
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

    public void FillInNameField(string name) => ProjectName.SendKeys(name);
    public void FillInProjectCode(string code) => ProjectCode.SendKeys(code);
    public void FillInProjectDescription(string desc) => ProjectDescription.SendKeys(desc);
    public void ClickCreateProjectButton() => CreateProjectButton.Click();
    public void ClickCancelProjectButton() => CancelProjectButton.Click();

    public void SetProjectAccessType(string projectAccessType)
    {
        switch (projectAccessType)
        {
            case "public":
                ProjectAccessPublic.Click();
                break;
            case "private":
                ProjectAccessPrivate.Click();
                break;
            default:
                ProjectAccessPrivate.Click();
                break;
        }
    }

    public void SetMemberAccessType(string memberAccessType)
    {
        switch (memberAccessType)
        {
            case "All":
                MemberAccessAll.Click();
                break;
            case "Group":
                MemberAccessGroup.Click();
                break;
            case "None":
                MemberAccessNone.Click();
                break;
            default:
                MemberAccessNone.Click();
                break;
        }
    }
}