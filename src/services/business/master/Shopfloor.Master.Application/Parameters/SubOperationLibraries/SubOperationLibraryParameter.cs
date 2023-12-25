using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.SubOperationLibraries
{
    public class SubOperationLibraryParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? OperationLibraryId { get; set; }
    }
}
