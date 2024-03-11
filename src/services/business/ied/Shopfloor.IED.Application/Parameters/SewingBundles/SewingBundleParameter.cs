using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingBundles
{
    public class SewingBundleParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Quantity { get; set; }
    }
}