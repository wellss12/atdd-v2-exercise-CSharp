using Microsoft.EntityFrameworkCore;

namespace ATDD.V2.Exercise.CSharp.Specs.Hooks;

[Binding]
public sealed class DataClearHooks
{
    [BeforeScenario]
    [Scope(Tag = "db")]
    public async Task ClearData(MyDbContext dbContext)
    {
        await dbContext.Database.ExecuteSqlInterpolatedAsync($"TRUNCATE TABLE users");
    }
}