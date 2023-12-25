using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Factory : BaseMasterEntity
    {
        public int? DivisionId { get; set; }
        public virtual Division Divsion { get; set; }
    }
}
