using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Application.Models.FourPointsSystems
{
    public class FourPointsSystemModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ProductGroup { get; set; }

    }
}
