using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.OperationLibraries
{
    public class OperationLibraryModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProcessLibraryId { get; set; }
        public string ProcessLibraryName { get; set; }
        public string ProcessLibraryCode { get; set; }
    }
}
