using ATDD.V2.Exercise.CSharp.Specs.Steps;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ATDD.V2.Exercise.CSharp.Specs.PageObjects;

public class LoginPage
{
    private readonly TestStepDefinitions _testStepDefinitions;

    public LoginPage(TestStepDefinitions testStepDefinitions)
    {
        _testStepDefinitions = testStepDefinitions;
    }

    public void Login(string userName, string password)
    {
        var webDriverWait = new WebDriverWait(_testStepDefinitions.GetWebDriver(), TimeSpan.FromSeconds(10));
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
        _testStepDefinitions.GetWebDriver().Navigate().GoToUrl("http://host.docker.internal:10081/");
    }

    public void ShouldHaveText(string text)
    {
        // 主要是為了避免元素未加载完成就開始 Assert
        var webDriverWait = new WebDriverWait(_testStepDefinitions.GetWebDriver(), TimeSpan.FromSeconds(10));
        webDriverWait
            .Until(driver => driver.FindElement(By.XPath($"//*[text()='{text}']")))
            .Should()
            .NotBeNull();
    }
}