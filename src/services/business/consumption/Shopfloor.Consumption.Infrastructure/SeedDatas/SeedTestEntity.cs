using Shopfloor.Consumption.Domain.Enums;
using Shopfloor.Consumption.Infrastructure.Contexts;

namespace Shopfloor.Consumption.Infrastructure.SeedDatas
{
    public static class SeedTestEntity
    {
        public static async Task SeedTestEntityAsync(ConsumptionContext context)
        {
            await context.TestEntities.AddAsync(new()
            {
                Property01 = "Property01",
                Property02 = "Property02",
                Type = TestClassType.Type1,
                IsActive = true,
            });
            await context.SaveChangesAsync();
        }
    }
}