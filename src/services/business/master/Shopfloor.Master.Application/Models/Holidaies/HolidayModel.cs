using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.Holidays
{
    public class HolidayModel : BaseModel
    {
        public DateTime? Date { get; set; }
		public string Description { get; set; }
    }
}
