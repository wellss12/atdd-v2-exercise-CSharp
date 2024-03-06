namespace ATDD.V2.Exercise.CSharp.Specs.PageObjects;

public class LoginPage
{
    private readonly Browser _browser;

    public LoginPage(Browser browser)
    {
        _browser = browser;
    }

    public void Login(string userName, string password)
    {
        _browser.InputByPlaceholder("用户名", userName);
        _browser.InputByPlaceholder("密码", password);
        _browser.ClickByText("登录");
    }

    public void Open() => _browser.Launch();
}