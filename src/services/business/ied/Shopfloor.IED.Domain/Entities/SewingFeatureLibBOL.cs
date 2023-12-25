using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingFeatureLibBOL : BaseEntity
    {
        public int SewingFeatureLibId { get; set; }
        public int SewingOperationLibId { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal SMV { get; set; }
        public decimal AllowedTime { get; set; }
        public string MachineName { get; set; }
        public decimal RPM { get; set; }
        public virtual SewingOperationLib SewingOperationLib { get; set; }
        public virtual SewingFeatureLib SewingFeatureLib { get; set; }

    }
}
