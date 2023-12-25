using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingOperationWFXVersion : BaseEntity
    {
        public SewingOperationWFXVersion()
        {
            SewingSubOperationWFXs = new HashSet<SewingSubOperationWFX>();
        }
        public int SewingOperationWFXId { get; set; }
        public int Version { get; set; }
        public virtual SewingOperationWFX SewingOperationWFX { get; set; }
        public ICollection<SewingSubOperationWFX> SewingSubOperationWFXs { get; set; }
    }
}
