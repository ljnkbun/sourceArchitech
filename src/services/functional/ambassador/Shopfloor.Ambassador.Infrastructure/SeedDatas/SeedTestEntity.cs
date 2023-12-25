using Shopfloor.Ambassador.Domain.Enums;
using Shopfloor.Ambassador.Infrastructure.Contexts;

namespace Shopfloor.Ambassador.Infrastructure.SeedDatas
{
    public static class SeedTestEntity
    {
        public static async Task SeedTestEntityAsync(AmbassadorContext context)
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