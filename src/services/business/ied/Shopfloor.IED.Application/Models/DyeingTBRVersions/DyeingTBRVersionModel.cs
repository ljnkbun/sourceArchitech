using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.DyeingTBRVersions
{
    public class DyeingTBRVersionModel : BaseModel
    {
        public int DyeingTBRecipeId { get; set; }

        public int Version { get; set; }

        public DateTime DoTime { get; set; }

        public bool Approved { get; set; }
    }
}