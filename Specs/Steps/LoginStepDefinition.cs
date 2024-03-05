using ATDD.V2.Exercise.CSharp.Specs.PageObjects;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public sealed class LoginStepDefinition
{
    private readonly Browser _browser;
    private readonly MyDbContext _dbContext;
    private readonly LoginPage _loginPage;

    public LoginStepDefinition(MyDbContext dbContext, LoginPage loginPage, Browser browser)
    {
        _dbContext = dbContext;
        _loginPage = loginPage;
        _browser = browser;
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
    
    [When(@"以用户名为""(.*)""和密码为""(.*)""登录时")]
    public void When以用户名为和密码为登录时(string userName, string password)
    {
        _loginPage.Open();
        _loginPage.Login(userName, password);
    }

    [Then(@"""(.*)""登录成功")]
    public void Then登录成功(string userName)
    {
        _browser.ShouldHaveText($"Welcome {userName}");
    }

    [Then(@"登录失败的错误信息是""(.*)""")]
    public void Then登录失败的错误信息是(string errorMessage)
    {
        var webDriverWait = new WebDriverWait(_browser.GetWebDriver(), TimeSpan.FromSeconds(10));
        webDriverWait
            .Until(driver => driver.FindElement(By.XPath($"//*[text()='{errorMessage}']")))
            .Should()
            .NotBeNull();
    }
}