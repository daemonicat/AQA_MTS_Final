using OpenQA.Selenium;
using QaseTestProject.Elements;

namespace QaseTestProject.Objects.Pages;

public class CreateProjectDialogue(IWebDriver driver) : BasePage(driver)
{
    private static readonly By ProjectNameBy = By.Id("project-name");
    private static readonly By ProjectCodeBy = By.Id("project-code");
    private static readonly By ProjectDescriptionBy = By.Name("description-area");
    private static readonly By ProjectAccessPrivateBy = By.XPath("//input[@type='radio'][@value='private']");
    private static readonly By ProjectAccessPublicBy = By.XPath("//input[@type='radio'][@value='public']");
    private static readonly By MemberAccessAllBy = By.XPath("//input[@type='radio'][@value='all']");
    private static readonly By MemberAccessGroupBy = By.XPath("//input[@type='radio'][@value='group']");
    private static readonly By MemberAccessNoneBy = By.XPath("//input[@type='radio'][@value='none']");
    private static readonly By CreateProjectButtonBy = By.XPath("//button[@type='submit']");

    private static readonly By MinCharsProjectCodeErrorBy =
        By.XPath("//div[text()='The code must be at least 2 characters.']");

    private static readonly By MaxCharsProjectCodeErrorBy =
        By.XPath("//div[text()='The code may not be greater than 10 characters.']");

    private Input ProjectName => new(Driver, ProjectNameBy);
    private Input ProjectCode => new(Driver, ProjectCodeBy);
    private Input ProjectDescription => new(Driver, ProjectDescriptionBy);
    private IWebElement ProjectAccessPrivate => WaitsHelper.WaitForVisibilityLocatedBy(ProjectAccessPrivateBy);
    private IWebElement ProjectAccessPublic => WaitsHelper.WaitForExists(ProjectAccessPublicBy);
    private IWebElement MemberAccessAll => WaitsHelper.WaitForExists(MemberAccessAllBy);
    private IWebElement MemberAccessGroup => WaitsHelper.WaitForExists(MemberAccessGroupBy);
    private IWebElement MemberAccessNone => WaitsHelper.WaitForVisibilityLocatedBy(MemberAccessNoneBy);
    private Button CreateProjectButton => new(Driver, CreateProjectButtonBy);
    private IWebElement MinCharsProjectCodeError => WaitsHelper.WaitForExists(MinCharsProjectCodeErrorBy);
    private IWebElement MaxCharsProjectCodeError => WaitsHelper.WaitForExists(MaxCharsProjectCodeErrorBy);

    public override bool IsPageOpened()
    {
        return CreateProjectButton.Displayed;
    }

    public CreateProjectDialogue FillInNameField(string name)
    {
        ProjectName.SendKeys(name);
        return this;
    }

    public CreateProjectDialogue FillInProjectCode(string code)
    {
        ProjectCode.Clear();
        ProjectCode.SendKeys(code);
        return this;
    }

    public CreateProjectDialogue FillInProjectDescription(string desc)
    {
        ProjectDescription.SendKeys(desc);
        return this;
    }

    public CreateProjectDialogue ClickCreateProjectButton()
    {
        CreateProjectButton.Click();
        return this;
    }

    public CreateProjectDialogue SetProjectAccessType(string projectAccessType)
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
        
        return this;
    }

    public CreateProjectDialogue SetMemberAccessType(string memberAccessType)
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
        
        return this;
    }

    public bool CheckMinCharsProjectCodeError() => MinCharsProjectCodeError.Displayed;
    public bool CheckMaxCharsProjectCodeError() => MaxCharsProjectCodeError.Displayed;
}