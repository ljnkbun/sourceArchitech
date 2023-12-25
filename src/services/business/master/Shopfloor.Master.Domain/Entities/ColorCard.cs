using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class ColorCard : BaseMasterEntity
    {
        public int GroupId { get; set; }
        public string Reference { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string SelectColor { get; set; }
        public string PictureURL { get; set; }
    }
}
