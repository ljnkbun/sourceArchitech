using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.WeavingIEDs
{
    public class WeavingIEDParameter : RequestParameter
    {
        public int? RequestDivisionId { get; set; }
        public string RequestNo { get; set; }
        public string Comment { get; set; }
        public Status? Status { get; set; }
        public bool? Deleted { get; set; }
    }
}
