using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.DyeingTBRTasks
{
    public class DyeingTBRTaskModel : BaseModel
    {
        public int DyeingTBRecipeId { get; set; }
        public int DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int DyeingOperationId { get; set; }
        public string DyeingOperationName { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public decimal Temperature { get; set; }
        public int Minutes { get; set; }
        public bool Deleted { get; set; }
    }
}