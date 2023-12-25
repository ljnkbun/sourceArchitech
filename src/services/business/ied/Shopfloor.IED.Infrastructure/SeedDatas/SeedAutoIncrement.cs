using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.SeedDatas
{
    public static class SeedAutoIncrement
    {
        public static async Task SeedAsync(IEDContext context)
        {
            var increments = new List<AutoIncrement>()
            {
                new()
                {
                    Type = AutoIncrementType.Request,
                    Separate = "/",
                    Index = 1,
                    IndexFormat = "D5",
                    IsActive = true
                },
                new()
                {
                    Type = AutoIncrementType.RC,
                    Separate = "",
                    Index = 2,
                    IndexFormat = "D5",
                    IsActive = true
                },
                new()
                {
                    Type = AutoIncrementType.RTB,
                    Separate = "",
                    Index = 3,
                    IndexFormat = "D5",
                    IsActive = true
                },
                new()
                {
                    Type = AutoIncrementType.RCP,
                    Separate = "",
                    Index = 4,
                    IndexFormat = "D5",
                    IsActive = true
                }
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