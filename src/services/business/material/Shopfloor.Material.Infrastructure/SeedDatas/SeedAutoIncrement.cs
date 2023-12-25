using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Infrastructure.Contexts;

namespace Shopfloor.Material.Infrastructure
{
    public static class SeedAutoIncrement
    {
        public static async Task SeedAsync(MaterialContext context)
        {
            var increments = new List<AutoIncrement>()
            {
                new()
                {
                    Type = AutoIncrementType.Buyer,
                    Separate = "/",
                    Index = 1,
                    IndexFormat = "D5",
                    IsActive = true
                },
                new()
                {
                    Type = AutoIncrementType.MaterialRequest,
                    Separate = "/",
                    Index = 1,
                    IndexFormat = "D5",
                    IsActive = true
                },
                new()
                {
                    Type = AutoIncrementType.PriceList,
                    Separate = "/",
                    Index = 1,
                    IndexFormat = "D5",
                    IsActive = true
                },
                new()
                {
                    Type = AutoIncrementType.Supplier,
                    Separate = "/",
                    Index = 1,
                    IndexFormat = "D5",
                    IsActive = true
                },
            };

            foreach (var item in increments)
            {
                bool isDuplicate = context.AutoIncrements.Any(c => c.Type == item.Type);
                if (!isDuplicate)
                {
                    context.AutoIncrements.Add(item);
                }
                else
                {
                    Console.WriteLine($"AutoIncrement with Type {item.Type} is a duplicate and not inserted.");
                }
            }

            await context.SaveChangesAsync();


        }
    }
}