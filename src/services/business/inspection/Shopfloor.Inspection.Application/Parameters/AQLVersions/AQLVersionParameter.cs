using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.AQLVersions
{
    public class AQLVersionParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
    }
}
