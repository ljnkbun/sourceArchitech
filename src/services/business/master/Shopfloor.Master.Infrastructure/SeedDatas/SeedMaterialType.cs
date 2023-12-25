using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.SeedDatas
{
    public static class SeedMaterialType
    {
        public static async Task SeedAsync(MasterContext context)
        {
            var materialTypes = new List<MaterialType>()
            {
                new()
                {
                    Code = "1",
                    Name= "MaterialTypeNameS1",
                    IsActive = true
                },
                new()
                {
                    Code = "2",
                    Name= "MaterialTypeNameS2",
                    IsActive = true
                },
                new()
                {
                    Code = "3",
                    Name= "MaterialTypeNameS3",
                    IsActive = true
                },
                new()
                {
                    Code = "4",
                    Name= "MaterialTypeNameS4",
                    IsActive = true
                },
            };
            await context.MaterialTypes.AddRangeAsync(materialTypes);
            await context.SaveChangesAsync();
        }
    }
}