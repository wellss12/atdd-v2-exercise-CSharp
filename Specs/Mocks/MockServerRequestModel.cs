namespace ATDD.V2.Exercise.CSharp.Specs.Mocks;

public class MockServerRequestModel
{
    public HttpRequest HttpRequest { get; set; }
    public HttpResponse HttpResponse { get; set; }
    public Times Times { get; set; }
}

public class Times
{
    public int RemainingTimes { get; init; }
    public bool Unlimited => RemainingTimes == 0;
}