using Shopfloor.Core.Models.Parameters;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Parameters.ProblemTimelines
{
    public class ProblemTimelineParameter : RequestParameter
    {
        public string NameVN { get; set; }
		public string NameEN { get; set; }
		public int? DivisonId { get; set; }
		public string DivisonName { get; set; }
		public int? ProcessId { get; set; }
		public string ProcessName { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public int? SubCategoryId { get; set; }
		public string SubCategoryName { get; set; }
		public InspectionType? InspectionType { get; set; }
    }
}
