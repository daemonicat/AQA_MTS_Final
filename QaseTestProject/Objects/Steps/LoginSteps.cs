using OpenQA.Selenium;
using QaseTestProject.Objects.Pages;

namespace QaseTestProject.Objects.Steps;

public class LoginSteps : BaseSteps
{
    private readonly LoginPage _loginPage;
    
    public LoginSteps(IWebDriver driver) : base(driver)
    {
        _loginPage = new LoginPage(Driver);
    }
    
    public ProjectsPage SuccessfulLogin(string username, string password)
    {
        _loginPage.EmailInput.SendKeys(username);
        _loginPage.PasswordInput.SendKeys(password);
        _loginPage.SignInButton.Click();

        return new ProjectsPage(Driver);
    }
    
    public LoginPage UnsuccessfulLogin(string username, string password)
    {
        _loginPage.EmailInput.SendKeys(username);
        _loginPage.PasswordInput.SendKeys(password);
        _loginPage.SignInButton.Click();

        return _loginPage;
    }
}