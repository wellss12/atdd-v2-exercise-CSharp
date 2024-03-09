namespace ATDD.V2.Exercise.CSharp.Specs.PageObjects;

public class LoginPage(Browser browser)
{
    public void Login(string userName, string password)
    {
        browser.InputByPlaceholder("用户名", userName);
        browser.InputByPlaceholder("密码", password);
        browser.ClickByText("登录");
    }

    public void Open() => browser.Launch();
}