using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Buyer : BaseEntity
    {
        public string WFXBuyerId { get; set; }

        public string Name { get; set; }
    }
}