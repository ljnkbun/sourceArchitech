using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingSubOperationWFXBOL : BaseEntity
    {
        public int SewingSubOperationWFXId { get; set; }
        public int? SewingOperationId { get; set; }
        public int? SewingFeatureId { get; set; }
        public SubOperationWFXBOLType Type { get; set; }
        public int LineNumber { get; set; }
        public virtual SewingSubOperationWFX SewingSubOperationWFX { get; set; }
        public virtual SewingOperation SewingOperation { get; set; }
        public virtual SewingFeature SewingFeature { get; set; }

    }
}
