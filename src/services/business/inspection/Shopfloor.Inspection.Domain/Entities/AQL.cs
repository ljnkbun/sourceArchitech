using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class AQL : BaseEntity
    {
        public int AQLVersionId { get; set; }
		public int LotSizeFrom { get; set; }
		public int LotSizeTo { get; set; }
		public int SampleSize { get; set; }
		public int? Accept { get; set; }
		public int? Reject { get; set; }
		public virtual AQLVersion AQLVersion { get; set; }
    }
}
