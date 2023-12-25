using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingFeatureLibBOLs
{
    public class SewingFeatureLibBOLModel : BaseModel
    {
        public int SewingOperationLibId { get; set; }
        public int SewingFeatureLibId { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal SMV { get; set; }
        public decimal AllowedTime { get; set; }
        public string MachineName { get; set; }
        public decimal RPM { get; set; }
    }
}
