using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingFeatureLibBOL : BaseEntity
    {
        public int SewingFeatureLibId { get; set; }
        public int? SewingOperationLibId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public FeatureBOLType Type { get; set; }
        public string Description { get; set; }
        public int LineNumber { get; set; }
        public string Freq { get; set; }
        public decimal SMV { get; set; }
        public decimal AllowedTime { get; set; }
        public string MachineName { get; set; }
        public decimal RPM { get; set; }
        public virtual SewingOperationLib SewingOperationLib { get; set; }
        public virtual SewingFeatureLib SewingFeatureLib { get; set; }

    }
}
