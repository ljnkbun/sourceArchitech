using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.SeedDatas
{
    public static class SeedAutoIncrement
    {
        public static async Task SeedAsync(PlanningContext context)
        {
            var increments = new List<AutoIncrement>()
            {
                new()
                {
                    Type = AutoIncrementType.JO,
                    Separate = "/",
                    Index = 1,
                    IndexFormat = "D6",
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