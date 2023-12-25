using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.RequestDivisionProcesses
{
    public class RequestDivisionProcessModel : BaseModel
    {
        public int RequestDivisionId { get; set; }
        public int ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int LineNumber { get; set; }
        public Status Status { get; set; }
    }
}
