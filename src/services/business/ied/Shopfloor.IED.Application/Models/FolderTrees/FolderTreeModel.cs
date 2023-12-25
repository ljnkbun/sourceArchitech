using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.FolderTrees
{
    public class FolderTreeModel : BaseModel
    {
        public string Name { get; set; }
        public byte Level { get; set; }
        public int? ParentId { get; set; }
        public ItemType ItemType { get; set; }
        public DivisionType DivisionType { get; set; }
    }
}
