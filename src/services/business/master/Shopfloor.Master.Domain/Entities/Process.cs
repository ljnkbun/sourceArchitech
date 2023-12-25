using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Process : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
