using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using QaseTestProject.Models;
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
    public ProjectsPage SuccessfulLogin(User? user)
    {
        Logger.Info("Successful Login:");
        
        _loginPage.EmailInput.SendKeys(user.Email);
        Logger.Info("EmailInput.SendKeys");
        
        _loginPage.PasswordInput.SendKeys(user.Password);
        Logger.Info("PasswordInput.SendKeys");
        
        _loginPage.SignInButton.Click();
        Logger.Info("SignInButton.Click");

        return new ProjectsPage(Driver);
    }

    [AllureStep]
    public LoginPage UnsuccessfulLogin(User? user)
    {
        Logger.Info("Successful Login:");
        
        _loginPage.EmailInput.SendKeys(user.Email);
        Logger.Info("EmailInput.SendKeys");
        
        _loginPage.PasswordInput.SendKeys(user.Password);
        Logger.Info("PasswordInput.SendKeys");
        
        _loginPage.SignInButton.Click();
        Logger.Info("SignInButton.Click");

        return _loginPage;
    }
}