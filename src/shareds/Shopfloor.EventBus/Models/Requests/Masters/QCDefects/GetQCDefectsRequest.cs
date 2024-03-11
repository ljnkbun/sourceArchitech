using Shopfloor.EventBus.Definations;

namespace Shopfloor.EventBus.Models.Requests
{
    public class GetQCDefectsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? QCDefecTypeId { get; set; }
		public int? ParrentId { get; set; }
		public string NameEN { get; set; }
		public int? DivisonId { get; set; }
		public string DivisonName { get; set; }
		public int? ProcessId { get; set; }
		public string ProcessName { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string SubCategoryId { get; set; }
		public string SubCategoryName { get; set; }
		public int Level { get; set; }
		public InspectionType? InspectionType { get; set; }
    }
}
