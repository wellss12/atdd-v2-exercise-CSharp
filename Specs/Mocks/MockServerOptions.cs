namespace ATDD.V2.Exercise.CSharp.Specs.Mocks;

public record MockServerOptions
{
    public string Host { get; set; }
    public string ResetUrl { get; set; }
    public string ExpectationUrl { get; set; }
}