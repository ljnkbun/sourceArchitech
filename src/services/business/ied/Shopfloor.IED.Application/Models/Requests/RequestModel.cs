using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.Requests
{
    public class RequestModel : BaseModel
    {
        public string RequestNo { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public string StatusComment { get; set; }
        public decimal? ExpectedQty { get; set; }
        public int RequestTypeId { get; set; }
        public bool Deleted { get; set; }
    }
}
