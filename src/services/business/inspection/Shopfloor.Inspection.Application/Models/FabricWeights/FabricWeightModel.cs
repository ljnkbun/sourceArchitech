using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Application.Models.AQLs;
using Shopfloor.Inspection.Application.Models.OneHundredPointSystems;

namespace Shopfloor.Inspection.Application.Models.FabricWeights
{
    public class FabricWeightModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<OneHundredPointSystemModel> OneHundredPointSystems { get; set; }
    }
}
