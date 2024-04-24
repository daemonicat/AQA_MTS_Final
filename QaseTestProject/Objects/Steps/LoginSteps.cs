using Allure.NUnit.Attributes;
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

    [AllureStep]
    public ProjectsPage SuccessfulLogin(string username, string password)
    {
        Logger.Info("Successful Login:");
        
        _loginPage.EmailInput.SendKeys(username);
        Logger.Info("EmailInput.SendKeys");
        
        _loginPage.PasswordInput.SendKeys(password);
        Logger.Info("PasswordInput.SendKeys");
        
        _loginPage.SignInButton.Click();
        Logger.Info("SignInButton.Click");

        return new ProjectsPage(Driver);
    }

    [AllureStep]
    public LoginPage UnsuccessfulLogin(string username, string password)
    {
        Logger.Info("Successful Login:");
        
        _loginPage.EmailInput.SendKeys(username);
        Logger.Info("EmailInput.SendKeys");
        
        _loginPage.PasswordInput.SendKeys(password);
        Logger.Info("PasswordInput.SendKeys");
        
        _loginPage.SignInButton.Click();
        Logger.Info("SignInButton.Click");

        return _loginPage;
    }
}