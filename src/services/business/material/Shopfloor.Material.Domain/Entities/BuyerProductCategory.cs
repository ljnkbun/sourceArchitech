using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Domain.Entities
{
    public class BuyerProductCategory : BaseEntity
    {
        public int BuyerId { get; set; }

        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }

        public Buyer Buyer { get; set; }
    }
}