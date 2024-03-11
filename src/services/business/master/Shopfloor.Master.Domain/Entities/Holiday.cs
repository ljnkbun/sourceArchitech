using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Holiday : BaseEntity
    {
        public DateTime? Date { get; set; }
		public string Description { get; set; }
    }
}
