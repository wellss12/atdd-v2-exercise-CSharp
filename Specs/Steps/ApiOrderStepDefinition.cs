using System.Text;
using System.Text.Json;
using ATDD.V2.Exercise.CSharp.ORM.Entities;
using Newtonsoft.Json.Linq;
using FluentAssertions.Json;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class ApiOrderStepDefinition
{
    private readonly LoginStepDefinition _loginStep;
    private string? _response;

    public ApiOrderStepDefinition(LoginStepDefinition loginStep)
    {
        _loginStep = loginStep;
    }

    [When(@"API查询订单时")]
    public async Task WhenApi查询订单时()
    {
        await _loginStep.Given存在用户名为和密码为的用户("test", "test");
        
        var httpClient = new HttpClient();
        var user = new User { UserName = "test", Password = "test" };
        var json = JsonSerializer.Serialize(user, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var token = (await httpClient.PostAsync("http://localhost:10081/users/login", content))
            .Headers.GetValues("token");
        httpClient.DefaultRequestHeaders.Add("token", token);

        var response = await httpClient.GetAsync("http://localhost:10081/api/orders");
        _response = await response.Content.ReadAsStringAsync();
    }

    [Then(@"返回如下订单")]
    public void Then返回如下订单(string json)
    {
        // https://stackoverflow.com/questions/52645603/how-to-compare-two-json-objects-using-c-sharp
        var expected = JToken.Parse(json);
        var actual = JToken.Parse(_response);
        actual.Should().BeEquivalentTo(expected);
    }
}