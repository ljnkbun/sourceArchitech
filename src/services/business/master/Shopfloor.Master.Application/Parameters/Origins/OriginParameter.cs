using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Origins
{
    public class OriginParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
