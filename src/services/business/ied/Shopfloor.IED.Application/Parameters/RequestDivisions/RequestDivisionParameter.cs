using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.RequestDivisions
{
    public class RequestDivisionParameter : RequestParameter
    {
        public int? RequestId { get; set; }
        public int? DivisionId { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public int? LineNumber { get; set; }
        public int? Status { get; set; }
    }
}
