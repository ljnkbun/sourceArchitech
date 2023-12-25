using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.Zones
{
    public class ZoneModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal ZoneSalary { get; set; }

    }
}
