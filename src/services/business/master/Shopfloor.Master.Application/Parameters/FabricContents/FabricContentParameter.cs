using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.FabricContents
{
    public class FabricContentParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
