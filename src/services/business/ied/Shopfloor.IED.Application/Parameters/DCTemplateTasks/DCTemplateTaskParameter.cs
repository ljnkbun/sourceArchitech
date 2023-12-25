using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DCTemplateTasks
{
    public class DCTemplateTaskParameter : RequestParameter
    {
        public int? DCTemplateId { get; set; }
        public int? TaskId { get; set; }
        public string TaskCode { get; set; }
        public string TaskName { get; set; }
        public string Temperature { get; set; }
        public int? Minute { get; set; }
    }
}