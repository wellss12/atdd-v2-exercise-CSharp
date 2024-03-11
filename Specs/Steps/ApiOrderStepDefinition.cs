using ATDD.V2.Exercise.CSharp.ORM;
using ATDD.V2.Exercise.CSharp.Specs.Mocks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class ApiOrderStepDefinition(API api, MyDbContext dbContext, MockServer mockServer)
{
    [When(@"API查询订单时")]
    public Task WhenApi查询订单时()
    {
        return api.Get("orders");
    }

    [Then(@"返回如下订单")]
    public Task Then返回如下订单(string json)
    {
        return api.ResponseShouldMatchJson(json);
    }

    [When(@"API查询订单""(.*)""详情时")]
    public Task WhenApi查询订单详情时(string code)
    {
        return api.Get($"orders/{code}");
    }

    [When(@"通过API发货订单""(.*)""，快递单号为""(.*)""")]
    public Task When通过api发货订单快递单号为(string code, string deliverNo)
    {
        var body = new Dictionary<string, object> { { "deliverNo", deliverNo } };
        return api.Post($"api/orders/{code}/deliver", body);
    }

    [Then(@"订单""(.*)""已发货，发货时间为""(.*)""，快递单号为""(.*)""")]
    public void Then订单已发货发货时间为快递单号为(string code, string dateTime, string deliverNo)
    {
        var order = dbContext.Orders.AsNoTracking().SingleOrDefault(t => t.Code == code);
        order.Should().NotBeNull();
        order!.DeliverNo.Should().Be(deliverNo);
        order.Status.Should().Be("delivering");
        order.DeliveredAt.Should().Be(DateTimeOffset.Parse(dateTime).DateTime);
    }

    [Then(@"订单""(.*)""已发货，快递单号为""(.*)""")]
    public void Then订单已发货快递单号为(string code, string deliverNo)
    {
        var order = dbContext.Orders.AsNoTracking().SingleOrDefault(t => t.Code == code);
        order.Should().NotBeNull();
        order!.DeliverNo.Should().Be(deliverNo);
        order.Status.Should().Be("delivering");
    }

    [Given(@"存在快递单""(.*)""的物流信息如下")]
    public Task Given存在快递单的物流信息如下(string deliverNo, string response)
    {
        return mockServer.SetJsonExpectationForGetRequest("/express/query", response, new Dictionary<string, string>
        {
            { "type", "auto" },
            { "appkey", "test" },
            { "number", deliverNo }
        });
    }

    [Given(@"当前时间为""(.*)""")]
    public Task Given当前时间为(string dateTime)
    {
        return mockServer.SetJsonExpectationForGetRequest("/clock",  $"\"{dateTime}\"");
    }
}