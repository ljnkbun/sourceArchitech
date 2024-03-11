using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.KnittingRoutings
{
    public class KnittingRoutingParameter : RequestParameter
    {
        public int? KnittingIEDId { get; set; }
        public int? LineNumber { get; set; }
        public string KnittingProcess { get; set; }
        public string KnittingProcessCode { get; set; }
        public string KnittingOperationCode { get; set; }
        public string KnittingOperation { get; set; }
        public int? MachineTypeId { get; set; }
        public string MachineTypeName { get; set; }
    }
}
