using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Application.Models.StripSchedulePlanningDetails;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Models.StripScheduleDetails
{
    public class StripScheduleDetailModel : BaseModel
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public int PorDetailId { get; set; }
        public PorType? TypePORDetail { get; set; }
        public int StripScheduleId { get; set; }
        public virtual ICollection<StripSchedulePlanningDetailModel> StripSchedulePlanningDetails { get; set; }
    }
}
