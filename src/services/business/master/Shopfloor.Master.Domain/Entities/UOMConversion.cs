using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class UOMConversion : BaseEntity
    {
        public int FromUOMId { get; set; }
        public int ToUOMId { get; set; }
        public decimal Value { get; set; }
        public string Action { get; set; }
        public virtual UOM FromUOM { get; set; }
        public virtual UOM ToUOM { get; set; }

    }
}
