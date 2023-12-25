using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingTBRTask : BaseEntity
    {
        public DyeingTBRTask()
        {
            DyeingTBTaskChemicals = new HashSet<DyeingTBRChemical>();
        }

        public int DyeingTBRecipeId { get; set; }
        public int DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int DyeingOperationId { get; set; }
        public string DyeingOperationName { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public decimal Temperature { get; set; }
        public int Minute { get; set; }
        public virtual DyeingTBRecipe DyeingTBRecipe { get; set; }
        public virtual ICollection<DyeingTBRChemical> DyeingTBTaskChemicals { get; set; }
    }
}