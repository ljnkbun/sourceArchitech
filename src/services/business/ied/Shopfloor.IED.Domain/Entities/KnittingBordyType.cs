using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class KnittingBodyType : BaseEntity
    {
        public KnittingBodyType()
        {
            KnittingGreiges = new HashSet<KnittingGreige>();
        }
        public string Name { get; set; }
        public ICollection<KnittingGreige> KnittingGreiges { get; set; }
    }
}
