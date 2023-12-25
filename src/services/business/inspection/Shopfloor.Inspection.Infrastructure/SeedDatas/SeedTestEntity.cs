using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Infrastructure.Contexts;

namespace Shopfloor.Inspection.Infrastructure.SeedDatas
{
    public static class SeedTestEntity
    {
        public static async Task SeedTestEntityAsync(InspectionContext context)
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