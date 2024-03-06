using ATDD.V2.Exercise.CSharp.Specs.PageObjects;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class OrderStepDefinition
{
    private readonly Browser _browser;
    private readonly WelcomePage _welcomePage;
    private readonly OrderPage _orderPage;

    public OrderStepDefinition(Browser browser, WelcomePage welcomePage, OrderPage orderPage)
    {
        _browser = browser;
        _welcomePage = welcomePage;
        _orderPage = orderPage;
    }

    [When(@"用如下数据录入订单")]
    public void When用如下数据录入订单(Table table)
    {
        var orderMap = table.Rows[0].ToDictionary(t => t.Key, t => t.Value);
        _welcomePage.GotoOrderPage();
        _orderPage.CreateOrder(orderMap);
    }

    [Then(@"显示如下订单")]
    public void Then显示如下订单(Table table)
    {
        foreach (var header in table.Header)
        {
            _browser.ShouldHaveText(header);
        }
    }
}