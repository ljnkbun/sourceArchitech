using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class RequestType : BaseMasterEntity
    {
        public RequestType()
        {
            Requests = new HashSet<Request>();
        }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
