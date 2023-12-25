using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Country : BaseMasterEntity
    {
        public Country()
        {
            Ports = new HashSet<Port>();
        }
        public virtual ICollection<Port> Ports { get; set; }
    }
}
