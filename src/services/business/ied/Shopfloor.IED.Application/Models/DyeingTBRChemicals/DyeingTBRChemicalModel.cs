using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.DyeingTBRChemicals
{
    public class DyeingTBRChemicalModel : BaseModel
    {
        public int DyeingTBRTaskId { get; set; }
        public int ChemicalId { get; set; }
        public string ChemicalCode { get; set; }
        public string ChemicalName { get; set; }
        public string ChemicalSubCategory { get; set; }
        public string Unit { get; set; }
    }
}