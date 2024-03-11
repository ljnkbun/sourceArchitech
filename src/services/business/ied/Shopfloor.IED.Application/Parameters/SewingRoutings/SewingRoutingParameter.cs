using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.SewingRoutings
{
    public class SewingRoutingParameter : RequestParameter
    {
        public int? SewingIEDId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string WFXOperationCode { get; set; }
        public string WFXOperationName { get; set; }
        public int? LineNumber { get; set; }
        public decimal? SMV { get; set; }
        public bool? Deleted { get; set; }
    }
}
