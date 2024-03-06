using Microsoft.EntityFrameworkCore;

namespace ATDD.V2.Exercise.CSharp.Specs.Hooks;

[Binding]
public sealed class DataClearHooks
{
    [BeforeScenario(Order = 0)]
    [Scope(Tag = "db")]
    public async Task ClearData(MyDbContext dbContext)
    {
        await dbContext.Database.ExecuteSqlInterpolatedAsync($"TRUNCATE TABLE users");
        await dbContext.Database.ExecuteSqlInterpolatedAsync($"TRUNCATE TABLE orders");
    }
}