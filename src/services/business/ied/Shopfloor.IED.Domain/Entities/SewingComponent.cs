using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingComponent : BaseMasterEntity
    {
        public virtual ICollection<SewingFeatureLib> SewingFeatureLibs { get; set; }
        public virtual ICollection<SewingOperationLib> SewingOperationLibs { get; set; }
    }
}
