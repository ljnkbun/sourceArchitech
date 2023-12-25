using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Domain.Entities
{
    public class MOQMSQRoudingOptionItem : BaseEntity
    {
        public int MaterialRequestId { get; set; }

        public string Type { get; set; }

        public decimal From { get; set; }

        public decimal To { get; set; }

        public decimal Qty { get; set; }

        public virtual MaterialRequest MaterialRequest { get; set; }
    }
}