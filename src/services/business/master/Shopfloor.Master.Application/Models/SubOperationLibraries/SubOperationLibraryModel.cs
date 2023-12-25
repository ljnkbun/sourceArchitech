using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.SubOperationLibraries
{
    public class SubOperationLibraryModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int OperationLibraryId { get; set; }
        public string OperationLibraryName { get; set; }
        public string OperationLibraryCode { get; set; }
    }
}
