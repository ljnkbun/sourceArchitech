using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingFeatureLibs
{
    public class SewingFeatureLibModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int SewingComponentId { get; set; }
        public decimal LabourCost { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal TotalSMV { get; set; }
        public int FolderTreeId { get; set; }
        public bool Deleted { get; set; }
    }
}
