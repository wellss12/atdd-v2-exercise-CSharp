namespace ATDD.V2.Exercise.CSharp.Specs.PageObjects;

public class WelcomePage(Browser browser)
{
    public void GotoOrderPage() => browser.ClickByText("订单");
}