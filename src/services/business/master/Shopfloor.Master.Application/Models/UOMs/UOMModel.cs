using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.UOMs
{
    public class UOMModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int DecimalPlaces { get; set; }
        public int OrderDecimalPlaces { get; set; }
        public string Action { get; set; }
    }
}
