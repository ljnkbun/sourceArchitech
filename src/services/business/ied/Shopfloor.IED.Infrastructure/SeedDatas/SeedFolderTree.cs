using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.SeedDatas
{
    public static class SeedFolderTree
    {
        public static async Task SeedAsync(IEDContext context)
        {
            var FolderTrees = new List<FolderTree>()
            {
                new()
                {
                    Name = "Task",
                    ParentId = null,
                    Level = 1,
                    DivisionType = DivisionType.Sewing,
                    ItemType = ItemType.Task,
                    IsActive = true
                },
                new()
                {
                    Name = "Macro",
                    ParentId = null,
                    Level = 1,
                    DivisionType = DivisionType.Sewing,
                    ItemType = ItemType.Macro,
                    IsActive = true
                },
                new()
                {
                    Name = "Operation",
                    ParentId = null,
                    Level = 1,
                    DivisionType = DivisionType.Sewing,
                    ItemType = ItemType.Operation,
                    IsActive = true
                },
                new()
                {
                    Name = "Feature",
                    ParentId = null,
                    Level = 1,
                    DivisionType = DivisionType.Sewing,
                    ItemType = ItemType.Feature,
                    IsActive = true
                }
            };

            foreach (var item in FolderTrees)
            {
                context.FolderTrees.Add(item);
            }

            await context.SaveChangesAsync();


        }
    }
}