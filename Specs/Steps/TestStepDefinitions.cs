using System.Text;
using System.Text.Json;
using ATDD.V2.Exercise.CSharp.Specs.PageObjects;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class TestStepDefinitions
{
    private readonly MyDbContext _dbContext;
    private readonly LoginPage _loginPage;
    private HttpResponseMessage _response;
    private RemoteWebDriver? _webDriver;

    public TestStepDefinitions(MyDbContext dbContext)
    {
        _dbContext = dbContext;
        _loginPage = new LoginPage(this);
    }

    [Given(@"存在用户名为""(.*)""和密码为""(.*)""的用户")]
    public async Task Given存在用户名为和密码为的用户(string userName, string password)
    {
        var allUsers = await _dbContext.Users.ToListAsync();
        if (allUsers.Any())
        {
            _dbContext.Users.RemoveRange(allUsers);
        }

        await _dbContext.Users.AddAsync(new User { UserName = userName, Password = password });
        await _dbContext.SaveChangesAsync();
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
        var result = _webDriver!.FindElementByCssSelector("#cols > ol > li.last > div > div > aside > span").Text;
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

    [AfterScenario]
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

    [When(@"以用户名为""(.*)""和密码为""(.*)""登录时")]
    public void When以用户名为和密码为登录时(string userName, string password)
    {
        _loginPage.OpenLoginPage();
        _loginPage.Login(userName, password);
    }

    [Then(@"""(.*)""登录成功")]
    public void Then登录成功(string userName)
    {
        _loginPage.ShouldHaveText($"Welcome {userName}");
    }

    [Then(@"登录失败的错误信息是""(.*)""")]
    public void Then登录失败的错误信息是(string errorMessage)
    {
        var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        webDriverWait
            .Until(driver => driver.FindElement(By.XPath($"//*[text()='{errorMessage}']")))
            .Should()
            .NotBeNull();
    }
}