using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingRouting : BaseEntity
    {
        public WeavingRouting()
        {
            WeavingOperations = new HashSet<WeavingOperation>();
        }

        public int WeavingIEDId { get; set; }
        public int LineNumber { get; set; }
        public string WeavingProcess { get; set; }
        public string WeavingProcessCode { get; set; }
        public virtual WeavingIED WeavingIED { get; set; }
        public virtual ICollection<WeavingOperation> WeavingOperations { get; set; }
    }
}