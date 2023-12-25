﻿using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingTBRChemical : BaseEntity
    {
        public int DyeingTBRTaskId { get; set; }

        public int ChemicalId { get; set; }
        
        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string Unit { get; set; }

        public virtual DyeingTBRTask DyeingTBRTask { get; set; }
    }
}