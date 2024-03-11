using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingComponentGroup : BaseMasterEntity
    {
        public SewingComponentGroup()
        {
            SewingMacroLibs = new HashSet<SewingMacroLib>();
        }
        public virtual ICollection<SewingMacroLib> SewingMacroLibs { get; set; }
    }
}
