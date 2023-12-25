using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class SubOperationLibrary : BaseMasterEntity
    {
        public int OperationLibraryId { get; set; }
        public virtual OperationLibrary OperationLibrary { get; set; }
    }
}
