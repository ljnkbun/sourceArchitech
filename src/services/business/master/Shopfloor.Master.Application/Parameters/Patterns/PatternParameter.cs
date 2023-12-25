using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Patterns
{
    public class PatternParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
