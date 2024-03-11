using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DyeingTBRChemicalValues
{
    public class DyeingTBRChemicalValueParameter : RequestParameter
    {
        public int? DyeingTBRChemicalId { get; set; }

        public int? VersionIndex { get; set; }

        public decimal? Value { get; set; }
    }
}