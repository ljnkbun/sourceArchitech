using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class RequestType : BaseNameEntity
    {
        public RequestType()
        {
            Requests = new HashSet<Request>();
            DyeingIEDs = new HashSet<DyeingIED>();
            WeavingIEDs = new HashSet<WeavingIED>();
        }
        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<DyeingIED> DyeingIEDs { get; set; }

        public virtual ICollection<WeavingIED> WeavingIEDs { get; set; }
    }
}
