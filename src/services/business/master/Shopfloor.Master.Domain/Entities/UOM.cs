using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class UOM : BaseMasterEntity
    {
        public int DecimalPlaces { get; set; }
        public int OrderDecimalPlaces { get; set; }
        public string Action { get; set; }
        public UOM()
        {
            FromUOMConversions = new HashSet<UOMConversion>();
            ToUOMConversions = new HashSet<UOMConversion>();
        }
        public virtual ICollection<UOMConversion> FromUOMConversions { get; set; }
        public virtual ICollection<UOMConversion> ToUOMConversions { get; set; }

    }
}
