using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.DCTemplateTasks
{
    public class DCTemplateTaskModel : BaseModel
    {
        public int DCTemplateId { get; set; }
        public int TaskId { get; set; }
        public string TaskCode { get; set; }
        public string TaskName { get; set; }
        public string Temperature { get; set; }
        public int Minute { get; set; }
    }
}