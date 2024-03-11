using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingTBRChemicalValue : BaseEntity
    {
        public int DyeingTBRChemicalId { get; set; }

        public int VersionIndex { get; set; }

        public decimal Value { get; set; }

        public virtual DyeingTBRChemical DyeingTbrChemical { get; set; }
    }
}