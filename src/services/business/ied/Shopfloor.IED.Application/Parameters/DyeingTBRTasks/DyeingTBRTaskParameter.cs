using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DyeingTBRTasks
{
    public class DyeingTBRTaskParameter : RequestParameter
    {
        public int? DyeingTBRecipeId { get; set; }
        public int? DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int? DyeingOperationId { get; set; }
        public string DyeingOperationName { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public decimal? Temperature { get; set; }
        public int? Minute { get; set; }
    }
}