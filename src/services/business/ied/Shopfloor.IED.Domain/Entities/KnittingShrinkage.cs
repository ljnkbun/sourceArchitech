using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class KnittingShrinkage : BaseEntity
    {
        public KnittingShrinkage()
        {
            KnittingGreiges = new HashSet<KnittingGreige>();
        }
        public string Name { get; set; }
        public ICollection<KnittingGreige> KnittingGreiges { get; set; }
    }
}
