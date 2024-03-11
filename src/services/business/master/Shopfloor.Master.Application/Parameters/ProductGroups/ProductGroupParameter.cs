using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.ProductGroups
{
    public class ProductGroupParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
    }
}
