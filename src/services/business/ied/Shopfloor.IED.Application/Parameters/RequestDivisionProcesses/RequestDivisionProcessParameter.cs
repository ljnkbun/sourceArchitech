using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.RequestDivisionProcesses
{
    public class RequestDivisionProcessParameter : RequestParameter
    {
        public int? RequestDivisionId { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int? LineNumber { get; set; }
        public Status Status { get; set; }
    }
}
