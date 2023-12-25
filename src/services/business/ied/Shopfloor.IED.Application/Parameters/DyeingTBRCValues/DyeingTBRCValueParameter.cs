using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DyeingTBRCValues
{
    public class DyeingTBRCValueParameter : RequestParameter
    {
        public int? DyeingTBRChemicalId { get; set; }

        public int? DyeingTBRVersionId { get; set; }

        public decimal? Value { get; set; }
    }
}