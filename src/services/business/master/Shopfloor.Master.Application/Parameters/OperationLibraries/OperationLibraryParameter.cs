using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.OperationLibraries
{
    public class OperationLibraryParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ProcessId { get; set; }
    }
}
