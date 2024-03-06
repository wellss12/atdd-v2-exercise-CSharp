namespace ATDD.V2.Exercise.CSharp.Specs.PageObjects;

public class OrderPage
{
    private readonly Browser _browser;

    public OrderPage(Browser browser)
    {
        _browser = browser;
    }

    public void CreateOrder(Dictionary<string, string> orderMap)
    {
        _browser.ClickByText("录入订单");

        foreach (var (key, value) in orderMap.Where(t => t.Key is not "状态"))
        {
            _browser.InputByPlaceholder(key, value);
        }

        _browser.SelectTextByPlaceholder("状态", orderMap["状态"]);
        _browser.ClickByText("提交");
    }
}