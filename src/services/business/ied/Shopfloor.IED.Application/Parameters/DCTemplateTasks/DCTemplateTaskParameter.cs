using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DCTemplateTasks
{
    public class DCTemplateTaskParameter : RequestParameter
    {
        public int? DCTemplateId { get; set; }
        public int? DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int? DyeingOpreationId { get; set; }
        public string DyeingOpreationName { get; set; }
        public int? LineNumber { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public string Temperature { get; set; }
        public int? Minute { get; set; }
    }
}