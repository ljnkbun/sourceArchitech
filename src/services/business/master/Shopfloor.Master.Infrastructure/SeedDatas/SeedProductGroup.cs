using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.SeedDatas
{
    public static class SeedProductGroup
    {
        public static async Task SeedAsync(MasterContext context)
        {
            var materialType = new List<MaterialType>()
            {
  new()
                {
                    Code = "EMB-TRIMS",
                    Name = "EMB-TRIMS",
                    IsActive = true
                },
                new()
                {
                    Code = "PACKING TRIMS",
                    Name = "PACKING TRIMS",
                    IsActive = true
                },
                new()
                {
                    Code = "SEWING STRIMS",
                    Name = "SEWING STRIMS",
                    IsActive = true
                },
                new()
                {
                    Code = "THREAD",
                    Name = "THREAD",
                    IsActive = true },
            };
            await context.MaterialTypes.AddRangeAsync(materialType);
            await context.SaveChangesAsync();
        }
    }
}