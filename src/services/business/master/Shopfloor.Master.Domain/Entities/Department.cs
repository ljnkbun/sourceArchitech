using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Department : BaseMasterEntity
    {
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }

    }
}
