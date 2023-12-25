using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.FolderTrees
{
    public class FolderTreeParameter : RequestParameter
    {
        public string Name { get; set; }
        public byte? Level { get; set; }
        public int? ParentId { get; set; }
        public ItemType? ItemType { get; set; }
        public DivisionType? DivisionType { get; set; }
    }
}
