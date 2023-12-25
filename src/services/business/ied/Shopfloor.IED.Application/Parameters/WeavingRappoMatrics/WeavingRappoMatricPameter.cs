using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.WeavingRappoMatrics
{
    public class WeavingRappoMatricParameter : RequestParameter
    {
        public int? WeavingRappoId { get; set; }
        public int? RowIndex { get; set; }
        public int? ColumnIndex { get; set; }
        public int? LoopIndex { get; set; }
        public int? HorizontalYarnId { get; set; }
        public int? VerticleYarnId { get; set; }
        public int? BackgroundType { get; set; }
        public bool? Deleted { get; set; }
    }
}
