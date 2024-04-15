using OpenQA.Selenium;
using QaseTestProject.Helpers.Configuration;
using QaseTestProject.Objects.Pages;

namespace QaseTestProject.Objects.Steps;

public class LoginSteps : BaseSteps
{
    private readonly LoginPage _loginPage;
    
    public LoginSteps(IWebDriver driver) : base(driver)
    {
        _loginPage = new LoginPage(Driver);
    }
    
    public void Login(string username, string password)
    {
        _loginPage.EmailInput.SendKeys(username);
        _loginPage.PasswordInput.SendKeys(password);
        _loginPage.SignInButton.Click();
    }
}