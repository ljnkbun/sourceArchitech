using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.SeedDatas
{
    public static class SeedSubCategory
    {
        public static async Task SeedAsync(MasterContext context)
        {
            var SubCategorys = new List<SubCategory>()
            {
                new()
                {
                    Code = "EMB-TRIMS",
                    Name = "EMB-TRIMS",
                    ProductGroupId = 1,
                    IsActive = true
                },
                new()
                {
                    Code = "PACKING TRIMS",
                    Name = "PACKING TRIMS",
                    ProductGroupId =2,
                    IsActive = true
                },
                new()
                {
                    Code = "SEWING STRIMS",
                    Name = "SEWING STRIMS",
                    ProductGroupId = 3,
                    IsActive = true
                },
                new()
                {
                    Code = "THREAD",
                    Name = "THREAD",
                    ProductGroupId = 4,
                    IsActive = true
                },
            };
            await context.SubCategories.AddRangeAsync(SubCategorys);
            await context.SaveChangesAsync();
        }
    }
}