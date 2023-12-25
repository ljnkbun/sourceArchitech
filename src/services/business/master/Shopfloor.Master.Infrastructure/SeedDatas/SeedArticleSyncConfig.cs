using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.SeedDatas
{
    public static class SeedArticleSyncConfig
    {
        public static async Task SeedAsync(MasterContext context)
        {
            var data = new List<ArticleSyncConfig>()
            {
                new()
                {
                    Category="Yarns",
                    Enable=true,
                    IsActive = true
                },
                new()
                {
                     Category="Textiles/Fabric",
                    Enable=true,
                    IsActive = true
                },
                new()
                {
                     Category="Trims",
                    Enable=true,
                    IsActive = true
                },
                new()
                {
                    Category="Apparel",
                    Enable=true,
                    IsActive = true
                },
                new()
                {
                      Category="Fiber",
                    Enable=true,
                    IsActive = true
                },
                new()
                {
                    Category="Fixed Asset",
                    Enable=true,
                    IsActive = true
                },
                new()
                {
                     Category="Miscellaneous",
                    Enable=true,
                    IsActive = true
                },
                new()
                {
                     Category="Services",
                    Enable=true,
                    IsActive = true
                },
            };

            foreach (var r in data)
            {
                bool isDuplicate = context.ArticleSyncConfigs.Any(c => c.Category == r.Category);
                if (!isDuplicate)
                {
                    context.ArticleSyncConfigs.Add(r);
                }
                else
                {
                    Console.WriteLine($"ArticleSyncConfig with category {r.Category} is a duplicate and not inserted.");
                }
            }

            await context.SaveChangesAsync();


        }
    }
}