using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Application.Models.StripFactoryScheduleDetails;

namespace Shopfloor.Planning.Application.Models.StripFactorySchedules
{
    public class CalculateStripFactoryScheduleModel : BaseModel
    {
        public int StripFactoryId { get; set; }
        public int? StripScheduleId { get; set; }
        public decimal? Quantity { get; set; }
        public string BatchNo { get; set; }
        public virtual ICollection<CalculateStripFactoryScheduleDetailModel> StripFactoryScheduleDetails { get; set; }
    }
}
