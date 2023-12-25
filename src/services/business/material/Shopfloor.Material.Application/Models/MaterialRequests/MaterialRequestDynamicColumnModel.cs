using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.MaterialRequests
{
    public class MaterialRequestDynamicColumnModel : BaseModel
    {
        public int MaterialRequestId { get; set; }

        public int DynamicColumnId { get; set; }

        public string Value { get; set; }
    }
}