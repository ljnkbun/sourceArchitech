using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Holidays
{
    public class HolidayParameter : RequestParameter
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
		public string Description { get; set; }
    }
}
