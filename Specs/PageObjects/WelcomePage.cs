namespace ATDD.V2.Exercise.CSharp.Specs.PageObjects;

public class WelcomePage
{
    private readonly Browser _browser;

    public WelcomePage(Browser browser)
    {
        _browser = browser;
    }

    public void GotoOrderPage() => _browser.ClickByText("订单");
}