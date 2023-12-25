using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.Ports
{
    public class PortModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool PortOfLoading { get; set; }
        public bool PortOfDischarge { get; set; }
        public bool PortOfReceiptByPreCarrier { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
