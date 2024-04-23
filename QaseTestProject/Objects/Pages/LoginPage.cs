using OpenQA.Selenium;

namespace QaseTestProject.Objects.Pages;

public class LoginPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By EmailInputBy = By.Name("email");
    private static readonly By PasswordInputBy = By.Name("password");
    private static readonly By SignInButtonBy = By.CssSelector("button[type = 'submit']");

    private static readonly By ErrorAlertBy =
        By.XPath("//div[@id='app']//span[text()='These credentials do not match our records.']");

    public IWebElement EmailInput => WaitsHelper.WaitForExists(EmailInputBy);
    public IWebElement PasswordInput => WaitsHelper.WaitForExists(PasswordInputBy);
    public IWebElement SignInButton => WaitsHelper.WaitForExists(SignInButtonBy);
    public IWebElement ErrorAlert => WaitsHelper.WaitForVisibilityLocatedBy(ErrorAlertBy);

    public override bool IsPageOpened() => SignInButton.Displayed;
}