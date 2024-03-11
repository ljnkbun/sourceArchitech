using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.FourPointsSystems
{
    public class FourPointsSystemParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ProductGroup { get; set; }

    }
}
