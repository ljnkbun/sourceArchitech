using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.SizeOrWidthRanges
{
    public class SizeOrWidthRangeModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Inseam { get; set; }
    }
}
