using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingRoutingBOL : BaseEntity
    {
        public int SewingRoutingId { get; set; }
        public int? SewingOperationLibId { get; set; }
        public int? SewingFeatureLibId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public SewingRoutingType Type { get; set; }
        public string Description { get; set; }
        public int LineNumber { get; set; }
        public string Freq { get; set; }
        public decimal SMV { get; set; }
        public decimal TotalSMV { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public virtual SewingRouting SewingRouting { get; set; }
        public virtual SewingOperationLib SewingOperationLib { get; set; }
        public virtual SewingFeatureLib SewingFeatureLib { get; set; }

    }
}
