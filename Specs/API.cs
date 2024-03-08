using System.Text;
using System.Text.Json;
using ATDD.V2.Exercise.CSharp.ORM;
using ATDD.V2.Exercise.CSharp.ORM.Entities;
using FluentAssertions.Json;
using Newtonsoft.Json.Linq;

namespace ATDD.V2.Exercise.CSharp.Specs;

[Binding]
public class API
{
    private readonly MyDbContext _dbContext;
    private readonly HttpClient _httpClient;
    private HttpResponseMessage _responseMessage;

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

        await Post("users/login", user);

        _httpClient.DefaultRequestHeaders.Add("token", _responseMessage.Headers.GetValues("token"));
    }

    public async Task Get(string path)
    {
        _responseMessage = await _httpClient.GetAsync($"http://localhost:10081/api/{path}");
    }

    public async Task ResponseShouldMatchJson(string json)
    {
        // https://stackoverflow.com/questions/52645603/how-to-compare-two-json-objects-using-c-sharp
        var expected = JToken.Parse(json);
        var actual = JToken.Parse(await _responseMessage.Content.ReadAsStringAsync());
        actual.Should().BeEquivalentTo(expected);
    }

    public async Task Post(string path, object body)
    {
        var json = JsonSerializer.Serialize(body, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        _responseMessage = await _httpClient.PostAsync($"http://localhost:10081/{path}", content);
    }
}