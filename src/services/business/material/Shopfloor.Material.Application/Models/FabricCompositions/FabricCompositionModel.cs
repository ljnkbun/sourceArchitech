using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.FabricCompositions
{
    public class FabricCompositionModel : BaseModel
    {
        public int MaterialRequestId { get; set; }

        public string ContentNameDesc { get; set; }

        public decimal Percentage { get; set; }
    }
}