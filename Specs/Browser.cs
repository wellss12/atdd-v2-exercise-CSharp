using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ATDD.V2.Exercise.CSharp.Specs;

[Binding]
public class Browser
{
    private RemoteWebDriver? _webDriver;

    public void ClickByText(string text)
    {
        new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(10))
            .Until(driver => driver.FindElement(By.XPath($"//*[text()='{text}']")))
            .Click();
    }

    public void InputByPlaceholder(string userName, string placeholder)
    {
        new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(10))
            .Until(driver => driver.FindElement(By.XPath($"//*[@placeholder='{placeholder}']")))
            .SendKeys(userName);
    }

    public void ShouldHaveText(string text)
    {
        // 主要是為了避免元素未加载完成就開始 Assert
        new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(10))
            .Until(driver => driver.FindElement(By.XPath($"//*[text()='{text}']")))
            .Should()
            .NotBeNull();
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

    public void Launch(string path = "") =>
        GetWebDriver()
            .Navigate()
            .GoToUrl($"http://host.docker.internal:10081/{path}");
}