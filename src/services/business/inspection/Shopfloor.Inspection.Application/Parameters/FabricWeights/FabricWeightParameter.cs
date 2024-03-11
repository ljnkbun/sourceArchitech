using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.FabricWeights
{
    public class FabricWeightParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
    }
}
