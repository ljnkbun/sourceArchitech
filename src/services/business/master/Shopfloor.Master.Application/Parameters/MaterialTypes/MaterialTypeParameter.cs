using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.MaterialTypes
{
    public class MaterialTypeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }

    }
}
