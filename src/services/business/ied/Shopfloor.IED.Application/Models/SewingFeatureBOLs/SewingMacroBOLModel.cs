using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingFeatureBOLs
{
    public class SewingFeatureBOLModel : BaseModel
    {
        public int SewingOperationId { get; set; }
        public int SewingFeatureId { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal SMV { get; set; }
        public decimal AllowedTime { get; set; }
        public string MachineName { get; set; }
        public decimal RPM { get; set; }
    }
}
