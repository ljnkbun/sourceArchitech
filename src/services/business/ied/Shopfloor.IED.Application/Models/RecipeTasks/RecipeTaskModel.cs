using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.RecipeTasks
{
    public class RecipeTaskModel : BaseModel
    {
        public int RecipeId { get; set; }

        public int DyeingProcessId { get; set; }

        public string DyeingProcessName { get; set; }

        public int DyeingOperationId { get; set; }

        public string DyeingOperationName { get; set; }

        public string DyeingProcessCode { get; set; }

        public decimal Ratio { get; set; }

        public string DyeingOperationCode { get; set; }

        public string MachineCode { get; set; }

        public string MachineName { get; set; }

        public decimal Time { get; set; }

        public decimal Temperature { get; set; }
    }
}