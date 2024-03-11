using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.StripFactoryScheduleDetails
{
    public class StripFactoryScheduleDetailModel : BaseModel
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public int StripFactoryScheduleId { get; set; }
    }
}
