using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.WeavingRappoMarks
{
    public class WeavingRappoMarkParameter : RequestParameter
    {
        public int? WeavingRappoId { get; set; }
        public int? ColumnNo { get; set; }
        public int? PatternIndex { get; set; }
        public bool? Type { get; set; }
    }
}
