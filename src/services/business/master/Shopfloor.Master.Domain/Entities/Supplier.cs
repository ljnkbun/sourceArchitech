using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string WFXSupplierId { get; set; }

        public string Name { get; set; }
    }
}