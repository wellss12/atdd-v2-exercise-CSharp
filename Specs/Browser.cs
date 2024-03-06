using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ATDD.V2.Exercise.CSharp.Specs;

public class Browser
{
    private RemoteWebDriver? _webDriver;

    public void ClickByText(string text)
        => WaitElement($"//*[text()='{text}']").Click();

    public void InputByPlaceholder(string userName, string placeholder)
        => WaitElement($"//*[@placeholder='{placeholder}']").SendKeys(userName);

    public void ShouldHaveText(string text)
        => WaitElement($"//*[text()='{text}']").Should().NotBeNull();

    private IWebElement WaitElement(string xpathExpression)
    {
        // 等到元素加載完成再執行後續動作
        return new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(10))
            .Until(driver => driver.FindElement(By.XPath(xpathExpression)));
    }

    public void QuitWebDriver()
    {
        if (_webDriver is not null)
        {
            _webDriver.Quit();
            _webDriver = null;
        }
    }

    public RemoteWebDriver GetWebDriver()
        => _webDriver ??= new RemoteWebDriver(new Uri("http://web-driver.tool.net:4444"), new ChromeOptions());

    public void Launch(string path = "")
    {
        GetWebDriver()
            .Navigate()
            .GoToUrl($"http://host.docker.internal:10081/{path}");
    }
}