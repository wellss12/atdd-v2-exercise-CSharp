using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ATDD.V2.Exercise.CSharp.Specs.PageObjects;

public class LoginPage
{
    private RemoteWebDriver? _webDriver;

    public void Login(string userName, string password)
    {
        var webDriverWait = new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(10));
        webDriverWait
            .Until(driver => driver.FindElement(By.XPath("//*[@placeholder='用户名']")))
            .SendKeys(userName);
        webDriverWait
            .Until(driver => driver.FindElement(By.XPath("//*[@placeholder='密码']")))
            .SendKeys(password);
        webDriverWait
            .Until(driver => driver.FindElement(By.XPath("//*[text()='登录']")))
            .Click();
    }

    public void OpenLoginPage()
    {
        GetWebDriver().Navigate().GoToUrl("http://host.docker.internal:10081/");
    }

    public void ShouldHaveText(string text)
    {
        // 主要是為了避免元素未加载完成就開始 Assert
        var webDriverWait = new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(10));
        webDriverWait
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
    {
        if (_webDriver is null)
        {
            _webDriver = new RemoteWebDriver(new Uri("http://web-driver.tool.net:4444"), new ChromeOptions());
        }

        return _webDriver;
    }
}