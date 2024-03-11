using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Application.Models.PORDetails;
using Shopfloor.Planning.Application.Models.StripFactories;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Models.StripFactoryDetails
{
    public class StripFactoryDetailModel : BaseModel
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PorType? TypePORDetail { get; set; }
        public int PorDetailId { get; set; }
        public virtual PORDetailModel PORDetailModel { get; set; }
        public int StripFactoryId { get; set; }
        public virtual StripFactoryModel StripFactoryModel { get; set; }
    }
}
