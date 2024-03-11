using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class Request : BaseEntity
    {
        public Request()
        {
            RequestDivisions = new HashSet<RequestDivision>();
        }
        public string RequestNo { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public string StatusComment { get; set; }
        public decimal? ExpectedQty { get; set; }
        public bool Deleted { get; set; }
        public int RequestTypeId { get; set; }
        public virtual RequestType RequestType { get; set; }
        public virtual ICollection<RequestDivision> RequestDivisions { get; set; }
    }
}
