using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.ProductGroupUOMs
{
    public class ProductGroupUOMModel : BaseModel
    {
        public int UOMId { get; set; }
        public int ProductGroupId { get; set; }
    }
}