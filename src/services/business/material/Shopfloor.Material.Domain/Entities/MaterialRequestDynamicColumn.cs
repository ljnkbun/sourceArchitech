using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Domain.Entities
{
    public class MaterialRequestDynamicColumn : BaseEntity
    {
        public int MaterialRequestId { get; set; }

        public int DynamicColumnId { get; set; }

        public string Value { get; set; }

        public MaterialRequest MaterialRequest { get; set; }

        public DynamicColumn DynamicColumn { get; set; }
    }
}
