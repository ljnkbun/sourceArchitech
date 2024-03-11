using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingRouting : BaseEntity
    {
        public SewingRouting()
        {
            SewingRoutingBOLs = new HashSet<SewingRoutingBOL>();
        }
        public int SewingIEDId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string WFXOperationCode { get; set; }
        public string WFXOperationName { get; set; }
        public int LineNumber { get; set; }
        public decimal SMV { get; set; }
        public Status Status { get; set; }
        public bool Deleted { get; set; }
        public virtual SewingIED SewingIED { get; set; }
        public virtual ICollection<SewingRoutingBOL> SewingRoutingBOLs { get; set; }
    }
}
