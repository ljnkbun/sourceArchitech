using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Staples
{
    public class StapleParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
