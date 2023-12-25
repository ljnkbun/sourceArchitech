using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.Buyers
{
    public class BuyerProductCategoryModel : BaseModel
    {
        public int BuyerId { get; set; }

        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }
    }
}