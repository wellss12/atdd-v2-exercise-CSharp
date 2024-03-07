using System.Text;
using System.Text.Json;
using ATDD.V2.Exercise.CSharp.ORM.Entities;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class TestStepDefinitions
{
    private readonly Browser _browser;
    private HttpResponseMessage _response;

    public TestStepDefinitions(Browser browser)
    {
        _browser = browser;
    }

    [When(@"通过API以用户名为""(.*)""和密码为""(.*)""登录时")]
    public async Task When通过api以用户名为和密码为登录时(string userName, string password)
    {
        var httpClient = new HttpClient();
        var user = new User { UserName = userName, Password = password };
        var json = JsonSerializer.Serialize(user, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        _response = await httpClient.PostAsync("http://localhost:10081/users/login", content);
    }

    [Then(@"打印Token")]
    public void Then打印Token()
    {
        Console.WriteLine(_response.Headers.GetValues("token").First());
    }

    [When(@"当在 Yahoo 搜索关键字""(.*)""")]
    public void When当在Yahoo搜索关键字(string keyword)
    {
        var webDriver = GetWebDriver();
        webDriver.Navigate().GoToUrl("https://www.yahoo.com");
        var searchInput = webDriver.FindElementByCssSelector("#header-search-input");
        var searchButton = webDriver.FindElementByCssSelector("#header-desktop-search-button");
        searchInput.SendKeys(keyword);
        searchButton.Click();

        Thread.Sleep(5000);
    }


    [Then(@"那么打印 Yahoo 为您找到的相关结果数")]
    public void Then那么打印Yahoo为您找到的相关结果数()
    {
        var result = GetWebDriver().FindElementByCssSelector("#cols > ol > li.last > div > div > aside > span").Text;
        Console.WriteLine(result);
    }

    [Then(@"测试环境")]
    public void Then测试环境()
    {
        var webDriver = GetWebDriver();
        webDriver.Navigate().GoToUrl("http://host.docker.internal:10081/");
        var target = webDriver.FindElement(By.XPath("//*[text()='登录']"));
        target.Should().NotBeNull();
    }


    private RemoteWebDriver GetWebDriver()
    {
        return _browser.GetWebDriver();
    }
}