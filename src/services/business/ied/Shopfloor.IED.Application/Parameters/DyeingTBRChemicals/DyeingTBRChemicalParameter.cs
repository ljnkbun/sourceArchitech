using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DyeingTBRChemicals
{
    public class DyeingTBRChemicalParameter : RequestParameter
    {
        public int? DyeingTBRTaskId { get; set; }
        public int? ChemicalId { get; set; }
        public string ChemicalCode { get; set; }
        public string ChemicalName { get; set; }
        public string Unit { get; set; }
    }
}