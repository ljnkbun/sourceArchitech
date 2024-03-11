using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingBundles
{
    public class SewingBundleModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }
}