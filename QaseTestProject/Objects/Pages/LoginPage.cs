using OpenQA.Selenium;
using QaseTestProject.Elements;

namespace QaseTestProject.Objects.Pages;

public class LoginPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By EmailInputBy = By.Name("email");
    private static readonly By PasswordInputBy = By.Name("password");
    private static readonly By SignInButtonBy = By.CssSelector("button[type = 'submit']");

    private static readonly By ErrorAlertBy =
        By.XPath("//div[@id='app']//span[text()='These credentials do not match our records.']");

    public Input EmailInput => new(Driver, EmailInputBy);
    public Input PasswordInput => new(Driver, PasswordInputBy);
    public Button SignInButton => new(Driver, SignInButtonBy);
    public IWebElement ErrorAlert => WaitsHelper.WaitForVisibilityLocatedBy(ErrorAlertBy);

    public override bool IsPageOpened() => SignInButton.Displayed;
}