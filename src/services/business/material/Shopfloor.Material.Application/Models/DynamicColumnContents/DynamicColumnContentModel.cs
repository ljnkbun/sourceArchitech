using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.DynamicColumnContents
{
    public class DynamicColumnContentModel : BaseModel
    {
        public int DynamicColumnId { get; set; }

        public string Code { get; set; }

        public string Content { get; set; }
    }
}