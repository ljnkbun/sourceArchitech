using Shopfloor.Core.Models.Parameters;
using Shopfloor.Material.Domain.Enums;

namespace Shopfloor.Material.Application.Parameters.DynamicColumns
{
    public class DynamicColumnParameter : RequestParameter
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public FieldType? FieldType { get; set; }

        public bool? IsContent { get; set; }

        public bool? IsRequired { get; set; }

        public string CategoryCode { get; set; }

        public int? DisplayIndex { get; set; }

        public DateTime? CreatedFrom { get; set; }

        public DateTime? CreatedTo { get; set; }
    }
}