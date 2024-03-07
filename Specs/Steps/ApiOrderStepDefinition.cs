namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class ApiOrderStepDefinition
{
    private readonly API _api;

    public ApiOrderStepDefinition(API api)
    {
        _api = api;
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
}