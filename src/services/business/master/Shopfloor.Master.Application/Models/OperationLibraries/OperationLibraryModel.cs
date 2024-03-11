using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.OperationLibraries
{
    public class OperationLibraryModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessCode { get; set; }
    }
}
