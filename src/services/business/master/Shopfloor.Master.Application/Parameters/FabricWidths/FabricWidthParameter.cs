using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.FabricWidths
{
    public class FabricWidthParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Inseam { get; set; }
    }
}
