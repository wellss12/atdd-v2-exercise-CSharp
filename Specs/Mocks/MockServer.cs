using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using Microsoft.Extensions.Options;

namespace ATDD.V2.Exercise.CSharp.Specs.Mocks;

[Binding]
public class MockServer
{
    private readonly HttpClient _httpClient;
    private readonly MockServerOptions _options;

    public MockServer(HttpClient httpClient, IOptions<MockServerOptions> mockServerOptions)
    {
        _options = mockServerOptions.Value;
        httpClient.BaseAddress = new Uri(_options.Host);
        _httpClient = httpClient;
    }

    [BeforeScenario(Order = 0)]
    public async Task Reset()
    {
        await _httpClient.PutAsync(_options.ResetUrl, new StringContent("{}", Encoding.UTF8, "application/json"));
    }

    public async Task SetJsonExpectationForGetRequest(
        string path,
        string response,
        int times = 0,
        Dictionary<string, string>? queryStringMap = null)
    {
        // https://www.mock-server.com/mock_server/creating_expectations.html
        var request = new MockServerRequestModel
        {
            HttpRequest = new HttpRequest
            {
                Method = "GET",
                Path = path,
                QueryStringParameters = queryStringMap ?? new Dictionary<string, string>()
            },
            Times = new Times { RemainingTimes = times },
            HttpResponse = new HttpResponse
            {
                Body = response,
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }
                }
            }
        };

        var body = JsonSerializer.Serialize(request, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var content = new StringContent(body, Encoding.UTF8, "application/json");
        var responseMessage = await _httpClient.PutAsync(_options.ExpectationUrl, content);
        responseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}