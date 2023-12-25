using Shopfloor.Core.Models.Entities;
using Shopfloor.Material.Domain.Enums;

namespace Shopfloor.Material.Application.Models.DynamicColumns
{
    public class DynamicColumnModel : BaseModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public FieldType FieldType { get; set; }

        public bool IsContent { get; set; }

        public bool IsRequired { get; set; }

        public string CategoryCode { get; set; }

        public int DisplayIndex { get; set; }
    }
}