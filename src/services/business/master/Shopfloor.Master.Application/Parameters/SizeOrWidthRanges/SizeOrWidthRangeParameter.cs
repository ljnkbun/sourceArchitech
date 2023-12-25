using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.SizeOrWidthRanges
{
    public class SizeOrWidthRangeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
        public string Inseam { get; set; }
    }
}
