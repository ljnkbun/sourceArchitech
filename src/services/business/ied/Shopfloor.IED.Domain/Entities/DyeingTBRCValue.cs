using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingTBRCValue : BaseEntity
    {
        public int DyeingTBRChemicalId { get; set; }

        public int DyeingTBRVersionId { get; set; }

        public decimal Value { get; set; }

        public virtual DyeingTBRVersion DyeingTBRVersion { get; set; }
    }
}