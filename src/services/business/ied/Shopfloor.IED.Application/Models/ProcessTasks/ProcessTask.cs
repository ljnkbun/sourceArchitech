using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.ProcessTasks
{
    public class ProcessTaskModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
