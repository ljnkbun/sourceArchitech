using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class Formula : BaseMasterEntity
    {
        public string Description { get; set; }
        public string Expression { get; set; }
        public string ProcessCode { get; set; }
    }
}
