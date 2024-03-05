namespace ATDD.V2.Exercise.CSharp.Specs.Hooks;

[Binding]
public sealed class WebDriverHooks
{
    [AfterScenario]
    [Scope(Tag = "web")]
    public static void QuitWebDriver(Browser browser)
    {
        browser.QuitWebDriver();
    }
}