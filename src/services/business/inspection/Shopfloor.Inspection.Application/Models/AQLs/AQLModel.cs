using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Application.Models.AQLs
{
    public class AQLModel : BaseModel
    {
        public int? AQLVersionId { get; set; }
		public int? LotSizeFrom { get; set; }
		public int? LotSizeTo { get; set; }
		public int? SampleSize { get; set; }
		public int? Accept { get; set; }
		public int? Reject { get; set; }
    }
}
