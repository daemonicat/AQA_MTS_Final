using OpenQA.Selenium;

namespace QaseTestProject.Elements;

public class Input
{
    private readonly UIElement _uiElement;

    public Input(IWebDriver webDriver, By by) => _uiElement = new UIElement(webDriver, by);

    public Input(IWebDriver webDriver, IWebElement webElement) => _uiElement = new UIElement(webDriver, webElement);
    
    public void Clear() => _uiElement.Clear();
    public void Click() => _uiElement.Click();
        
    public void SendKeys(string text) => _uiElement.SendKeys(text);
}