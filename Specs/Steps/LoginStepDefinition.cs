﻿using ATDD.V2.Exercise.CSharp.ORM;
using ATDD.V2.Exercise.CSharp.ORM.Entities;
using ATDD.V2.Exercise.CSharp.Specs.PageObjects;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public sealed class LoginStepDefinition(MyDbContext dbContext, LoginPage loginPage, Browser browser)
{
    [Given(@"存在用户名为""(.*)""和密码为""(.*)""的用户")]
    public async Task Given存在用户名为和密码为的用户(string userName, string password)
    {
        await dbContext.Users.AddAsync(new User { UserName = userName, Password = password });
        await dbContext.SaveChangesAsync();
    }

    [When(@"以用户名为""(.*)""和密码为""(.*)""登录时")]
    public void When以用户名为和密码为登录时(string userName, string password)
    {
        loginPage.Open();
        loginPage.Login(userName, password);
    }

    [Then(@"""(.*)""登录成功")]
    public void Then登录成功(string userName)
    {
        browser.ShouldHaveText($"Welcome {userName}");
    }

    [Then(@"登录失败的错误信息是""(.*)""")]
    public void Then登录失败的错误信息是(string errorMessage)
    {
        browser.ShouldHaveText(errorMessage);
    }
    
    [BeforeScenario("ui-login")]
    public async Task UiLogin()
    {
        await Given存在用户名为和密码为的用户("test", "test");
        When以用户名为和密码为登录时("test", "test");
    }
}