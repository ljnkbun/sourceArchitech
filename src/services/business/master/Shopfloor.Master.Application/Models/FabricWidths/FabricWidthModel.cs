using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.FabricWidths
{
    public class FabricWidthModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Inseam { get; set; }
    }
}
