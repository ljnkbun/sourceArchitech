using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.FiberTypes
{
    public class FiberTypeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
