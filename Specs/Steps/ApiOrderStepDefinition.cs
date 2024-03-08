using ATDD.V2.Exercise.CSharp.ORM;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class ApiOrderStepDefinition
{
    private readonly API _api;
    private readonly MyDbContext _dbContext;

    public ApiOrderStepDefinition(API api, MyDbContext dbContext)
    {
        _api = api;
        _dbContext = dbContext;
    }

    [When(@"API查询订单时")]
    public Task WhenApi查询订单时()
    {
        return _api.Get("orders");
    }

    [Then(@"返回如下订单")]
    public void Then返回如下订单(string json)
    {
        _api.ResponseShouldMatchJson(json);
    }

    [When(@"API查询订单""(.*)""详情时")]
    public Task WhenApi查询订单详情时(string code)
    {
        return _api.Get($"orders/{code}");
    }

    [When(@"通过API发货订单""(.*)""，快递单号为""(.*)""")]
    public Task When通过api发货订单快递单号为(string code, string deliverNo)
    {
        var body = new Dictionary<string, object> { { "deliverNo", deliverNo } };
        return _api.Post($"orders/{code}/deliver", body);
    }

    [Then(@"订单""(.*)""已发货，快递单号为""(.*)""")]
    public void Then订单已发货快递单号为(string code, string deliverNo)
    {
        var order = _dbContext.Orders.AsNoTracking().SingleOrDefault(t => t.Code == code);
        order.Should().NotBeNull();
        order!.DeliverNo.Should().Be(deliverNo);
        order.Status.Should().Be("delivering");
    }
}