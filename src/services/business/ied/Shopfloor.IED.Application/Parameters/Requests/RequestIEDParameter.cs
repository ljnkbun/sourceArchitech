using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.Requests
{
    public class RequestIEDParameter : RequestParameter
    {
        public string RequestNo { get; set; }
        public string Description { get; set; }
        public RequestStatus? Status { get; set; }
        public string StatusComment { get; set; }
        public int? RequestTypeId { get; set; }
        public bool? Deleted { get; set; }

    }
}
