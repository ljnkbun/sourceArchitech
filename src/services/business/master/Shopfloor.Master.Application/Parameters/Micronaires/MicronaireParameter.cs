using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Micronaires
{
    public class MicronaireParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
