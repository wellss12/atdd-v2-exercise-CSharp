
namespace ATDD.V2.Exercise.CSharp.Specs.Steps;

[Binding]
public class OrderStepDefinition
{
    private readonly Browser _browser;

    public OrderStepDefinition(Browser browser)
    {
        _browser = browser;
    }

    [When(@"用如下数据录入订单")]
    public void When用如下数据录入订单(Table table)
    {
        _browser.ClickByText("订单");
        _browser.ClickByText("录入订单");
        
        var tableRow = table.Rows[0];
        foreach (var header in table.Header.Where(header => header != "状态"))
        {
            _browser.InputByPlaceholder(tableRow[header], header);
        }
        
        _browser.SelectTextByPlaceholder(tableRow["状态"], "状态");
        _browser.ClickByText("提交");
    }

    [Then(@"显示如下订单")]
    public void Then显示如下订单(Table table)
    {
        foreach (var header in table.Header)
        {
            _browser.ShouldHaveText(header);
        }
    }
}