using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Infrastructure.Contexts;

namespace Shopfloor.Inspection.Infrastructure.SeedDatas
{
    public static class SeedTestEntity
    {
        public static async Task SeedTestEntityAsync(InspectionContext context)
        {
            await context.SaveChangesAsync();
        }
    }
}