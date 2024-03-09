namespace ATDD.V2.Exercise.CSharp.Specs.Mocks;

public class HttpRequest
{
    public string Method { get; set; }
    public string Path { get; set; }
    public Dictionary<string, string> QueryStringParameters { get; set; }
}