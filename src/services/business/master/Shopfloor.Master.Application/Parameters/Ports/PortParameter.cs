using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Ports
{
    public class PortParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? PortOfLoading { get; set; }
        public bool? PortOfDischarge { get; set; }
        public bool? PortOfReceiptByPreCarrier { get; set; }
        public int? CountryId { get; set; }
    }
}
