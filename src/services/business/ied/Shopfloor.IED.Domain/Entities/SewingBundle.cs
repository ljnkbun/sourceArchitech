using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingBundle : BaseMasterEntity
    {
        public SewingBundle()
        {
            SewingTaskLibs = new HashSet<SewingTaskLib>();
        }
        public decimal Quantity { get; set; }
        public virtual ICollection<SewingTaskLib> SewingTaskLibs { get; set; }
    }
}