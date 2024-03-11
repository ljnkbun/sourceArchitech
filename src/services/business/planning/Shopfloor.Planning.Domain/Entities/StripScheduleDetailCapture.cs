using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class StripScheduleDetailCapture : BaseEntity
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public int StripScheduleCaptureId { get; set; }

        public virtual StripScheduleCapture StripScheduleCapture { get; set; }
    }
}
