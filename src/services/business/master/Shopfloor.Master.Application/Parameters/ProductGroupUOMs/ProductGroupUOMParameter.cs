using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.ProductGroupUOMs
{
    public class ProductGroupUOMParameter : RequestParameter
    {
        public int? UOMId { get; set; }
        public int? ProductGroupId { get; set; }
    }
}