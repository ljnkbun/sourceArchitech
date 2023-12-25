using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.MaterialTypeMapProductGroups
{
    public class MaterialTypeMapProductGroupParameter : RequestParameter
    {
        public int? ProductGroupId { get; set; }
        public int? MaterialTypeId { get; set; }
    }
}
