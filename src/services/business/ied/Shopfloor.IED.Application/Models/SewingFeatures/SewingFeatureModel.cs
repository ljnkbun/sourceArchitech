using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingFeatures
{
    public class SewingFeatureModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal LabourCost { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal TotalSMV { get; set; }
        public bool Deleted { get; set; }
    }
}
