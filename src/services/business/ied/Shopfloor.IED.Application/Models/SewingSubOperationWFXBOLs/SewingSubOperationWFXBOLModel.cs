using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.SewingSubOperationWFXBOLs
{
    public class SewingSubOperationWFXBOLModel
    {
        public int? SewingOperationId { get; set; }
        public int? SewingFeatureId { get; set; }
        public SubOperationWFXBOLType Type { get; set; }
        public int LineNumber { get; set; }
    }
}
