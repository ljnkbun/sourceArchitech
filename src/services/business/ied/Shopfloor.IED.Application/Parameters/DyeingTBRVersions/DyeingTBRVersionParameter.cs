using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DyeingTBRVersions
{
    public class DyeingTBRVersionParameter : RequestParameter
    {
        public int? DyeingTBRecipeId { get; set; }

        public int? Version { get; set; }

        public DateTime? DoTime { get; set; }

        public bool? Approved { get; set; }
    }
}