using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingFeatureBOL : BaseEntity
    {
        public int SewingFeatureId { get; set; }
        public int SewingOperationId { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal SMV { get; set; }
        public decimal AllowedTime { get; set; }
        public string MachineName { get; set; }
        public decimal RPM { get; set; }
        public virtual SewingOperation SewingOperation { get; set; }
        public virtual SewingFeature SewingFeature { get; set; }

    }
}
