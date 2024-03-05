namespace ATDD.V2.Exercise.CSharp.Specs.PageObjects;

[Binding]
public class LoginPage
{
    private readonly Browser _browser;

    public LoginPage(Browser browser)
    {
        _browser = browser;
    }

    public void Login(string userName, string password)
    {
        _browser.InputByPlaceholder(userName, "用户名");
        _browser.InputByPlaceholder(password, "密码");
        _browser.ClickByText("登录");
    }

    public void Open() => _browser.Launch();
}