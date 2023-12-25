using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.SeedDatas
{
    public static class SeedProcess
    {
        public static async Task SeedAsync(IEDContext context)
        {
            var ProcessTasks = new List<ProcessTask>()
            {
                new()
                {
                    Code = "ProcessTask Code",
                    Name = "ProcessTask Name",
                    IsActive = true
                },
                new()
                {
                    Code = "ProcessTask Code 1",
                    Name = "ProcessTask Name 1",
                    IsActive = true
                },
                new()
                {
                    Code = "ProcessTask Name 2",
                    Name = "ProcessTask Name 2",
                    IsActive = true
                }
            };

            foreach (var rout in ProcessTasks)
            {
                bool isDuplicate = context.ProcessTasks.Any(c => c.Code == rout.Code);
                if (!isDuplicate)
                {
                    context.ProcessTasks.Add(rout);
                }
                else
                {
                    Console.WriteLine($"ProcessTask with code {rout.Code} is a duplicate and not inserted.");
                }
            }

            await context.SaveChangesAsync();


        }
    }
}