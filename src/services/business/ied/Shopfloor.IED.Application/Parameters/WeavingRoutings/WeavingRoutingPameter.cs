using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.WeavingRoutings
{
    public class WeavingRoutingParameter : RequestParameter
    {
        public int? WeavingIEDId { get; set; }
        public int? LineNumber { get; set; }
        public string WeavingProcess { get; set; }
        public string WeavingProcessCode { get; set; }
    }
}
