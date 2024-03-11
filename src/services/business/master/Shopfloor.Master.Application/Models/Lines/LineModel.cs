using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.Lines
{
    public class LineModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Worker { get; set; }
        public int? WFXLineId { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
    }
}
