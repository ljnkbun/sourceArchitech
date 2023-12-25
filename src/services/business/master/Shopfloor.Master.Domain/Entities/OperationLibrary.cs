using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class OperationLibrary : BaseMasterEntity
    {
        public OperationLibrary()
        {
            SubOperationLibraries = new HashSet<SubOperationLibrary>();
        }
        public virtual ICollection<SubOperationLibrary> SubOperationLibraries { get; set; }
        public int ProcessLibraryId { get; set; }
        public virtual ProcessLibrary ProcessLibrary { get; set; }
    }
}
