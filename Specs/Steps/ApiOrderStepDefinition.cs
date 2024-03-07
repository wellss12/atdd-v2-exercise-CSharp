using System.Text;
using System.Text.Json;
using ATDD.V2.Exercise.CSharp.ORM;
using ATDD.V2.Exercise.CSharp.ORM.Entities;
using FluentAssertions.Json;
using Newtonsoft.Json.Linq;

namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class API
{
    private readonly MyDbContext _dbContext;
    private readonly HttpClient _httpClient;
    private string _response;

    public API(MyDbContext dbContext, HttpClient httpClient)
    {
        _dbContext = dbContext;
        _httpClient = httpClient;
    }

    [BeforeScenario("api-login")]
    public async Task Login()
    {
        var user = new User { UserName = "test", Password = "test" };
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        var json = JsonSerializer.Serialize(user, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var token = (await _httpClient.PostAsync("http://localhost:10081/users/login", content))
            .Headers.GetValues("token");

        _httpClient.DefaultRequestHeaders.Add("token", token);
    }

    public async Task Get(string path)
    {
        var responseMessage = await _httpClient.GetAsync($"http://localhost:10081/api/{path}");
        _response = await responseMessage.Content.ReadAsStringAsync();
    }

    public void ResponseShouldMatchJson(string json)
    {
        // https://stackoverflow.com/questions/52645603/how-to-compare-two-json-objects-using-c-sharp
        var expected = JToken.Parse(json);
        var actual = JToken.Parse(_response);
        actual.Should().BeEquivalentTo(expected);
    }
}

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
}