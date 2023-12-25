using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.WeavingIEDs
{
    public class WeavingIEDModel : BaseModel
    {
        public int RequestDivisionId { get; set; }
        public string RequestNo { get; set; }
        public string Comment { get; set; }
        public Status Status { get; set; }
        public bool Deleted { get; set; }
    }
}
