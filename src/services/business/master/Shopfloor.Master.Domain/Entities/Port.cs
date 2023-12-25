using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Port : BaseMasterEntity
    {
        public bool PortOfLoading { get; set; }
        public bool PortOfDischarge { get; set; }
        public bool PortOfReceiptByPreCarrier { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

    }
}
