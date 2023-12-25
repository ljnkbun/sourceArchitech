using Shopfloor.Production.Domain.Enums;
using Shopfloor.Production.Infrastructure.Contexts;

namespace Shopfloor.Production.Infrastructure.SeedDatas
{
    public static class SeedTestEntity
    {
        public static async Task SeedTestEntityAsync(ProductionContext context)
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