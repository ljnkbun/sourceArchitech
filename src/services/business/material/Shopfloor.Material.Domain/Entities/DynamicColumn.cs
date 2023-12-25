using Shopfloor.Core.Models.Entities;
using Shopfloor.Material.Domain.Enums;

namespace Shopfloor.Material.Domain.Entities
{
    public class DynamicColumn : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public FieldType FieldType { get; set; }

        public bool IsContent { get; set; }

        public bool IsRequired { get; set; }

        public string CategoryCode { get; set; }

        public int DisplayIndex { get; set; }

        public List<DynamicColumnContent> DynamicColumnContents { get; set; }

        public List<MaterialRequestDynamicColumn> MaterialRequestDynamicColumns { get; set; }
    }
}