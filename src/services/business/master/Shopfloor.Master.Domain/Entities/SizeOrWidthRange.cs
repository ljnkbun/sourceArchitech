using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class SizeOrWidthRange : BaseMasterEntity
    {
        public int SortOrder { get; set; }
        public string Inseam { get; set; }

    }
}
