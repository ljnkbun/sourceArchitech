using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.RecipeTasks
{
    public class RecipeTaskParameter : RequestParameter
    {
        public int? RecipeId { get; set; }

        public int? DyeingProcessId { get; set; }

        public string DyeingProcessName { get; set; }

        public int? DyeingOperationId { get; set; }

        public string DyeingOperationName { get; set; }

        public decimal? Ratio { get; set; }

        public string DyeingProcessCode { get; set; }

        public string DyeingOperationCode { get; set; }

        public string MachineCode { get; set; }

        public string MachineName { get; set; }

        public decimal? Time { get; set; }

        public decimal? Temperature { get; set; }
    }
}