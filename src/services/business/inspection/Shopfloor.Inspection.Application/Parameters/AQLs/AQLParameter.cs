using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.AQLs
{
    public class AQLParameter : RequestParameter
    {
        public int? AQLVersionId { get; set; }
		public int? LotSizeFrom { get; set; }
		public int? LotSizeTo { get; set; }
		public int? SampleSize { get; set; }
		public int? Accept { get; set; }
		public int? Reject { get; set; }
    }
}
