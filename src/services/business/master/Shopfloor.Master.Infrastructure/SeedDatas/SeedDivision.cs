using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.SeedDatas
{
    public static class SeedDivision
    {
        public static async Task SeedAsync(MasterContext context)
        {
            var divisions = new List<Division>()
            {
                new()
                {
                    Code = "sew",
                    Name = "Sewing",
                    IsActive = true
                },
                new()
                {
                    Code = "dye",
                    Name = "Dyeing",
                    IsActive = true
                },
                new()
                {
                    Code = "weave",
                    Name = "Weaving",
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
                    Code = "knit",
                    Name = "Knitting",
                    IsActive = true
                },
                new()
                {
                    Code = "spin",
                    Name = "Spinning",
                    IsActive = true
                }
            };

            foreach (var divisionToAdd in divisions)
            {
                bool isDuplicate = context.Divisions.Any(c => c.Code == divisionToAdd.Code);
                if (!isDuplicate)
                {
                     context.Divisions.Add(divisionToAdd);
                }
                else
                {
                    Console.WriteLine($"Division with code {divisionToAdd.Code} is a duplicate and not inserted.");
                }
            }

            await context.SaveChangesAsync();


        }
    }
}