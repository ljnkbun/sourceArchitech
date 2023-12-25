using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class ProcessLibrary : BaseMasterEntity
    {
        public ProcessLibrary()
        {
            OperationLibraries = new List<OperationLibrary>();
        }
        public virtual ICollection<OperationLibrary> OperationLibraries { get; set; }

    }
}
