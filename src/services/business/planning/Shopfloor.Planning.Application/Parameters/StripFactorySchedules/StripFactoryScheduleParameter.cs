using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.StripFactorySchedules
{
    public class StripFactoryScheduleParameter : RequestParameter
    {
        public int? StripFactoryId { get; set; }
        public int? StripScheduleId { get; set; }
        public decimal? Quantity { get; set; }
        public string BatchNo { get; set; }
    }
}
