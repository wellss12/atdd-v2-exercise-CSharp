using ATDD.V2.Exercise.CSharp.ORM;
using ATDD.V2.Exercise.CSharp.ORM.Entities;
using ATDD.V2.Exercise.CSharp.Specs.PageObjects;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class OrderStepDefinition(Browser browser, WelcomePage welcomePage, OrderPage orderPage, MyDbContext dbContext)
{
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
            DeliverNo = orderMap.TryGetValue("deliverNo", out var deliverNo) ? deliverNo : null ,
            DeliveredAt = orderMap.TryGetValue("deliveredAt", out var deliveredAt) ? DateTime.Parse(deliveredAt) : null 
        };
        
        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync();
    }

    [When(@"用如下数据录入订单")]
    public void When用如下数据录入订单(Table table)
    {
        var orderMap = table.Rows[0].ToDictionary(t => t.Key, t => t.Value);
        welcomePage.GotoOrderPage();
        orderPage.CreateOrder(orderMap);
    }

    [Then(@"显示如下订单")]
    public void Then显示如下订单(Table table)
    {
        foreach (var header in table.Header)
        {
            browser.ShouldHaveText(header);
        }
    }
}