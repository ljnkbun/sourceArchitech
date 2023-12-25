using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.SeedDatas
{
    public static class SeedCategory
    {
        public static async Task SeedAsync(MasterContext context)
        {
            var categories = new List<Category>()
            {
                new()
                {
                    Code = "APPAREL",
                    Name = "Apparel",
                    IsActive = true
                },
                new()
                {
                    Code = "FIBER",
                    Name = "Fiber",
                    IsActive = true
                },
                new()
                {
                    Code = "FIXEDASSET",
                    Name = "FixedAsset",
                    IsActive = true
                },
                new()
                {
                    Code = "MISCELLANEOUS",
                    Name = "Miscellaneous",
                    IsActive = true
                },
                new()
                {
                    Code = "SERVICES",
                    Name = "Services",
                    IsActive = true
                },
                new()
                {
                    Code = "FABRIC",
                    Name = "Textiles/Fabric",
                    IsActive = true
                },
                new()
                {
                    Code = "TRIMS",
                    Name = "Trims",
                    IsActive = true
                },
                new()
                {
                    Code = "YARNS",
                    Name = "Yarns",
                    IsActive = true
                },
            };

            foreach (var categoryToAdd in categories)
            {
                bool isDuplicate = context.Categories.Any(c => c.Code == categoryToAdd.Code);
                if (!isDuplicate)
                {
                     context.Categories.Add(categoryToAdd);
                }
                else
                {
                    Console.WriteLine($"Category with code {categoryToAdd.Code} is a duplicate and not inserted.");
                }
            }

            await context.SaveChangesAsync();


        }
    }
}