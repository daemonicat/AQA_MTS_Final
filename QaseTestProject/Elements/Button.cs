using OpenQA.Selenium;

namespace QaseTestProject.Elements;

public class Button
{
    private readonly UIElement _uiElement;

    public Button(IWebDriver webDriver, By by) => _uiElement = new UIElement(webDriver, by);

    public Button(IWebDriver webDriver, IWebElement webElement) => _uiElement = new UIElement(webDriver, webElement);
    
    public void Click() => _uiElement.Click();
    public void SendKeys(string text) => _uiElement.SendKeys(text);
    public bool Displayed => _uiElement.Displayed;
}