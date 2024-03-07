using ATDD.V2.Exercise.CSharp.ORM;
using ATDD.V2.Exercise.CSharp.ORM.Entities;
using ATDD.V2.Exercise.CSharp.Specs.PageObjects;
using FluentAssertions;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class OrderStepDefinition
{
    private readonly Browser _browser;
    private readonly WelcomePage _welcomePage;
    private readonly OrderPage _orderPage;
    private readonly MyDbContext _dbContext;

    public OrderStepDefinition(Browser browser, WelcomePage welcomePage, OrderPage orderPage, MyDbContext dbContext)
    {
        _browser = browser;
        _welcomePage = welcomePage;
        _orderPage = orderPage;
        _dbContext = dbContext;
    }

    [Given(@"存在如下订单:")]
    public async Task Given存在如下订单(Table table)
    {
        var orderMap = table.Rows[0].ToDictionary(t => t.Key, t => t.Value);
        var order = new Order
        {
            Code = orderMap["code"],
            ProductName = orderMap["productName"],
            Total = Convert.ToDecimal(orderMap["total"]),
            RecipientName = orderMap.TryGetValue("recipientName", out var recipientName) ? recipientName : null,
            RecipientMobile = orderMap.TryGetValue("recipientMobile", out var recipientMobile) ? recipientMobile : null,
            RecipientAddress = orderMap.TryGetValue("recipientAddress", out var recipientAddress) ? recipientAddress : null ,
            Status = orderMap["status"],
        };
        
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
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