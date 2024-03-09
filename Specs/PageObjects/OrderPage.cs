namespace ATDD.V2.Exercise.CSharp.Specs.PageObjects;

public class OrderPage(Browser browser)
{
    public void CreateOrder(Dictionary<string, string> orderMap)
    {
        browser.ClickByText("录入订单");

        foreach (var (key, value) in orderMap.Where(t => t.Key is not "状态"))
        {
            browser.InputByPlaceholder(key, value);
        }

        browser.SelectTextByPlaceholder("状态", orderMap["状态"]);
        browser.ClickByText("提交");
    }
}