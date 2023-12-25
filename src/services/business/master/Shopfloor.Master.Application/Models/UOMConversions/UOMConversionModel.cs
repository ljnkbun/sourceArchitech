using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.UOMConversions
{
    public class UOMConversionModel : BaseModel
    {
        public int FromUOMId { get; set; }
        public int ToUOMId { get; set; }
        public decimal Value { get; set; }
        public string Action { get; set; } 
        public string FromUOMCode { get; set; }
        public string FromUOMName { get; set; }
        public string ToUOMCode { get; set; }
        public string ToUOMName { get; set; }
    }
}
